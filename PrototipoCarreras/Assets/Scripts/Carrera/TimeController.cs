using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //Auxiliar, borrar luego

    public const int N_PLAYERS = 4;
    
    //References



    //Arrays

    public List<float> tiempoGeneral;
    public List<float> tiempoMejor;
    public List<float> tiempoUltimaVuelta;

    public float totalTime;

    private List<PlayerTime> _jugadores = new List<PlayerTime>();

    //Control Tiempo
    private float _auxTiempo;
    private float _vueltaRapida = 0;

    //Metodos

    //Inician los tiempos cuando se inicia la carrera

    public void InicioTiempos()
    {
        tiempoGeneral = new List<float>();
        tiempoMejor = new List<float>();
        tiempoUltimaVuelta = new List<float>();

        _auxTiempo = Time.time;
        totalTime = _auxTiempo;
        
        for (int i = 0; i < N_PLAYERS; i++)
        {
            tiempoGeneral.Add(0);
            tiempoMejor.Add(0);
            tiempoUltimaVuelta.Add(0);
            _jugadores.Add( new PlayerTime(Time.time, i));
        }
    }

    public string UpdateVuelta(int ID, int vuelta)// Cuando un jugador acaba una vuelta, se busca su posición en los arrays de timecontroller segun su ID y se actualizan los tiempos
    {
        int idJugador = _jugadores.FindIndex((p) => p.ID == ID);

        _jugadores[idJugador].siguienteVuelta++;
        _jugadores[idJugador].actualTime = Time.time;

        _auxTiempo = _jugadores[idJugador].actualTime - _jugadores[idJugador].anteriorTime;

        tiempoUltimaVuelta[idJugador] = _auxTiempo;

        _jugadores[idJugador].anteriorTime = _jugadores[idJugador].actualTime;
        _jugadores[idJugador].actualTime = 0;

        float vueltaRapidaPropia = tiempoMejor[idJugador], ultimaVuelta = 0;

        ultimaVuelta = tiempoUltimaVuelta[idJugador];
        tiempoGeneral[idJugador] += ultimaVuelta;
        if ((ultimaVuelta < vueltaRapidaPropia) || (vueltaRapidaPropia == 0))
        {
            vueltaRapidaPropia = ultimaVuelta;
            tiempoMejor[idJugador] = vueltaRapidaPropia;

            if ((ultimaVuelta < _vueltaRapida) || (_vueltaRapida == 0))
            {
                _vueltaRapida = ultimaVuelta;
            }
        }

        int idioma = InformacionPersistente.singleton.idiomaActual;
        
        string vueltaTexto = MiniTraductor("VueltaRapida", idioma) + ": " + Mathf.Round(_vueltaRapida * 1000) / 1000 + "\n" + MiniTraductor("MejorTiempo", idioma) + ": " + Mathf.Round(vueltaRapidaPropia * 1000) / 1000 + "\n" + MiniTraductor("UltimaVuelta", idioma) + ": " + Mathf.Round(ultimaVuelta * 1000) / 1000;
        return vueltaTexto;
    }

    //Cuando finaliza la carrera se pasan los ids de los jugadores con sus respectivos mejores tiempos
    public void FinalTiempos(out float total, out List<int> ids, out float[] mejoresTiempos)
    {
        totalTime = Time.time - totalTime;
        total = totalTime;
        mejoresTiempos = tiempoMejor.ToArray();
        ids = new List<int>();

        for (int i = 0; i < _jugadores.Count; i++)
        {
            ids.Add(_jugadores[i].ID);
        }
    }

    public string MiniTraductor(string key, int lang)
    {
        string palabro = "";

        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        palabro = data[InformacionPersistente.singleton.escenaActual][key][lang].Value;

        return palabro;
    }
}

//Estructura de datos auxiliar para guardar los tiempos de todos los jugadores
public class PlayerTime
{
    public float actualTime, anteriorTime, actualGlobalTime, anteriorGlobalTime;

    public int ID;

    public int siguienteVuelta; //para comprobar que la nueva vuelta es la que le corresponde, y que no ha ido hacia atrás y ha vuelto a acabar una vuelta que ya habia terminado

    public PlayerTime(float antT, int index)
    {
        ID = index;
        actualGlobalTime = actualTime = 0;
        anteriorGlobalTime = anteriorTime = antT;
        siguienteVuelta = 1;
    }
}


