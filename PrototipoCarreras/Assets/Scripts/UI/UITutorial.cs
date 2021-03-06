﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    ConverManager CM;
    public Button playConversacion;
    public string clave;
    void Start()
    {
        CM = GetComponent<ConverManager>();
        CM.refUI = this.gameObject;

        ComprobarIdioma();
        playConversacion.onClick.AddListener(() => CM.PlayConversation(clave));
        CM.PlayConversation(clave);
    }
    private void ComprobarIdioma()
    {
        switch (InformacionPersistente.singleton.idiomaActual)
        {
            case 0:

                break;

            case 1:
                clave = clave.Replace("Español", "Ingles");
                break;

            case 2:
                clave = clave.Replace("Español", "Gallego");
                break;

            default:

                break;
        }
    }
    public void CambiarConversacion(string nuevaClave)
    {
        if (InformacionPersistente.singleton.esTutorial)
        {
            clave = nuevaClave;
            ComprobarIdioma();
            CM.PlayConversation(clave);
        }
    }
    
}
