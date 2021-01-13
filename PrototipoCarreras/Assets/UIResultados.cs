using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultados : MonoBehaviour
{
    public Text[] nombres;
    public Text[] puntos;

    void Start()
    {
        InformacionPersistente ip = InformacionPersistente.singleton;

        if (ip.esCopa)
        {
            InformacionPersistente.singleton.esCopa = false;

            for (int i = 0; i < nombres.Length; i++)
            {
                nombres[i].text = ip.navesModoCopa[i].nombre;
                puntos[i].text = ip.navesModoCopa[i].puntos.ToString();
            }
        }
        else if (ip.esTemporada)
        {
            InformacionPersistente.singleton.esTemporada = false;

            for (int i = 0; i < nombres.Length; i++)
            {
                nombres[i].text = ip.navesModoMan[i].nombre;
                puntos[i].text = ip.navesModoMan[i].puntos.ToString();
            }
        }
    }
}
