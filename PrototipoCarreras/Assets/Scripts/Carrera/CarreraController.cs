using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreraController : MonoBehaviour
{
    //Aquí se controlarán las posiciones y el progreso de la carrera 

    //Auxiliar, borrar luego

    public const int N_PLAYERS = 4;

    //References

    public TimeController times;

    //Variables

    private int vueltaMásActual;

    public void Start()
    {
        //Necesito referencias a los coches, que preferiblemente sean los nombres, asi evitamos basarnos en ID's. 
    }

    public void InicioCarrera()
    {
        times.InicioTiempos();
        vueltaMásActual = 0;
    }

    public void UpdateCarrera()
    {
        //times.UpdateVuelta();
    }

    public void FinCarrera()
    {
        //times.FinalTiempos();
        
        string[] clasFinal = new string[N_PLAYERS];
        
        DarPuntos(clasFinal);
    }

    public void DarPuntos(string [] s)
    {
        int[] puntos;
    }

}
