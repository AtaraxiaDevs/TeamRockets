using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    //Aquí se gestionará el ranking

    //Auxiliar, borrar luego

    public const int N_PLAYERS = 4;
    public string [] nombres;

    //References



    //Variables

    public List <Participante> listaParticipantes;

    private void Start()
    {
        InformacionPersistente ip = InformacionPersistente.singleton;
        if (ip.navesModoMan == null)
        {
            listaParticipantes = new List<Participante>();
            for (int i = 0; i < listaParticipantes.Count; i++)
            {
                listaParticipantes[i].nombre = ip.pilotosOrdenados[i];
                

            }
            listaParticipantes[0].SetPuntos(5);
            listaParticipantes[1].SetPuntos(3);
            listaParticipantes[2].SetPuntos(1);
            ip.navesModoMan = listaParticipantes;


        }
        else
        {
            listaParticipantes = ip.navesModoMan;
            listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[0])).SetPuntos(5);
            listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[1])).SetPuntos(3);
            listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[2])).SetPuntos(1);
        }
    }
}

public class Participante
{
    public string nombre;
    public int puntos;
    
    public Participante(string s)
    {
        nombre = s;
        puntos = 0;
    }

    public void SetPuntos(int i)
    {
        puntos += i;
    }
}
