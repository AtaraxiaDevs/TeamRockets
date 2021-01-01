using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerRanking : MonoBehaviour
{
    public Text[] posicion;
    public Text[] tiempos;
    void Start()
    {
        string[] resultadoCarrera = InformacionPersistente.singleton.pilotosOrdenados;
        float[] tiempo = InformacionPersistente.singleton.tiempos;
        for (int i = 0; i < posicion.Length; i++)
        {
            posicion[i].text = resultadoCarrera[i];
            if ((tiempo[i] == 0)|| (tiempo[i] == null))
            {
                tiempos[i].text = "???";
            }
            else
            {
                tiempos[i].text = tiempo[i].ToString();
            }
           
        }
    }

 
}
