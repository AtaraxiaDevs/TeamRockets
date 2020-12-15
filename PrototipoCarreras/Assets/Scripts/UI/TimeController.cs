using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class TimeController : NetworkBehaviour
{
    public UIManager uIManager;   

    //Arrays
 
    public List<float> tiempoGeneral;
    public List<float> tiempoMejor;
    public List<float> tiempoUltimaVuelta;
    public Dictionary<int,float> tiemposClas;

    public float totalTime;

    private List<PlayerTime> _jugadores= new List<PlayerTime>();

    //Control Tiempo
    private float _auxTiempo;
    private float _vueltaRapida = 0;
    private float _comienzoClas;

    private bool _vueltaClasificatoria = false;
    //Exclusión mutua
    private readonly object _EMJugadores= new object();
    private readonly object _EMClas = new object();

    //Metodos



    //Inician los tiempos cuando se inicia la carrera

    public void InicioTiempos(List<PlayerInfo> playerInfos)
    {
        tiempoGeneral = new List<float>();
        tiempoMejor = new List<float>();
        tiempoUltimaVuelta = new List<float>();

        _auxTiempo = UnityEngine.Time.time;
        totalTime = _auxTiempo;
        lock (_EMJugadores)
        {
            for (int i = 0; i < playerInfos.Count; i++)
            {
                _jugadores.Add(new PlayerTime(_auxTiempo, playerInfos[i].ID, playerInfos[i].ConnClient));
                tiempoGeneral.Add(0);
                tiempoMejor.Add(0);
                tiempoUltimaVuelta.Add(0);
            }
        }
    }
    //Cuando finaliza la carrera se pasan los ids de los jugadores con sus respectivos mejores tiempos
    public void FinalTiempos(out float total,out List<int> ids, out float[] mejoresTiempos)
    {
        totalTime = UnityEngine.Time.time - totalTime;
        total = totalTime;
        mejoresTiempos = tiempoMejor.ToArray();
        ids = new List<int>();
        lock (_EMJugadores)
        {
            for (int i = 0; i < _jugadores.Count; i++)
            {
                ids.Add(_jugadores[i].ID);// PolepositionManager utilizara esta lista como traducción. Es decir, sabrá a quien corresponde cada tiempo segun su posicion y su id
            }
        }
    }

    public void UpdateVuelta(int ID, int vuelta)// Cuando un jugador acaba una vuelta, se busca su posición en los arrays de timecontroller segun su ID y se actualizan los tiempos
    {
        lock (_EMJugadores)
        {
            int idJugador = _jugadores.FindIndex((p) => p.ID == ID);

            if (vuelta == _jugadores[idJugador].siguienteVuelta)
            {
                _jugadores[idJugador].siguienteVuelta++;
                _jugadores[idJugador].actualTime = UnityEngine.Time.time;

                _auxTiempo = _jugadores[idJugador].actualTime - _jugadores[idJugador].anteriorTime;

                tiempoUltimaVuelta[idJugador] = _auxTiempo;
             
                _jugadores[idJugador].anteriorTime = _jugadores[idJugador].actualTime;
                _jugadores[idJugador].actualTime = 0;

                float vueltaRapidaPropia = tiempoMejor[idJugador], ultimaVuelta = 0;


                ultimaVuelta = tiempoUltimaVuelta[idJugador];

                if ((ultimaVuelta < vueltaRapidaPropia) || (vueltaRapidaPropia == 0))
                {
                    vueltaRapidaPropia = ultimaVuelta;
                    tiempoMejor[idJugador] = vueltaRapidaPropia;

                    if ((ultimaVuelta < _vueltaRapida) || (_vueltaRapida == 0))
                    {
                        _vueltaRapida = ultimaVuelta;
                    }
                }

                string vueltaTexto = "Fastest Lap: " + Mathf.Round(_vueltaRapida * 1000) / 1000 + "\nBest Lap: " + Mathf.Round(vueltaRapidaPropia * 1000) / 1000 + "\nLast Lap: " + Mathf.Round(ultimaVuelta * 1000) / 1000;
                TargetUITime(_jugadores[idJugador].conn, vueltaTexto);

            }


        }
    }
    //Cuando un jugador se va, se debe borrar su información en las estructuras de datos
    public void JugadorMenosTiempo(int ID)
    {
        if (_vueltaClasificatoria)
        {
            lock (_EMClas)
            {
                tiemposClas.Remove(ID);
            }

        }
        else
        {
            lock (_EMJugadores)
            {
                int index = _jugadores.FindIndex((p) => p.ID == ID);
                if (index >= 0)
                {
                    _jugadores.RemoveAt(index);
                    tiempoMejor.RemoveAt(index);
                    tiempoUltimaVuelta.RemoveAt(index);
                }
            }
        }


    }
    //La vuelta de clasificación inicia una nueva estructura de datos
    public void IniciarClas(List<PlayerInfo> playerInfos)
    {
        _vueltaClasificatoria = true;
        tiemposClas = new Dictionary<int, float>();
        _comienzoClas = UnityEngine.Time.time;
        lock (_EMClas)
        {
            for (int i = 0; i < playerInfos.Count; i++)
            {
                tiemposClas.Add(playerInfos[i].ID, 0);
            }
        }
        
    }
    //Este método se ejecuta cuando se ha terminado la vuelta clasificatoria, guardando asi su tiempo
    public void VueltaClas(int ID)
    {
        lock (_EMClas)
        {
            tiemposClas[ID] = UnityEngine.Time.time - _comienzoClas;
        }
       
    }
    //Al finalizar la clasificación se ordenan los tiempos para poder saber que posicion les corresponde a los jugadores. Para ello se les manda una lista con los ids de los jugadores ordenados por clasificacion
    public List<int> FinClas(out float[] tiempos)
    {
        List<float> aux = new List<float>();
        List<int> idsOrdenados = new List<int>();
        lock (_EMClas)
        {
            foreach (KeyValuePair<int, float> p in tiemposClas.OrderBy(key => key.Value))
            {
                idsOrdenados.Add(p.Key);
                aux.Add(p.Value);
            }
        }
        
        tiempos = aux.ToArray();
        return idsOrdenados;
    }
    //Se actualiza la interfaz de tiempos
    [TargetRpc]
    private void TargetUITime(NetworkConnection conn, string info)
    {
        uIManager.UpdateTiempos(info);
    }
}

//Estructura de datos auxiliar para guardar los tiempos de todos los jugadores
public class PlayerTime
{
    public float actualTime, anteriorTime, actualGlobalTime, anteriorGlobalTime;


    public int ID;

    public int siguienteVuelta; //para comprobar que la nueva vuelta es la que le corresponde, y que no ha ido hacia atrás y ha vuelto a acabar una vuelta que ya habia terminado

    public NetworkConnection conn; //para las comunicaciones

    public PlayerTime(float antT, int index, NetworkConnection con)
    {
        ID = index;
        conn = con;
        actualGlobalTime = actualTime = 0;
        anteriorGlobalTime = anteriorTime = antT;
        siguienteVuelta = 1;
    }
}
