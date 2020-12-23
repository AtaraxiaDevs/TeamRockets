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

    public Participante[] listaParticipantes;

    private void Start()
    {
        listaParticipantes = new Participante[N_PLAYERS];
        
        for (int i = 0; i < listaParticipantes.Length; i++)
        {
            listaParticipantes[i].nombre = nombres[i];
        }
    }

    private void Reorganizar()
    {
        
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
