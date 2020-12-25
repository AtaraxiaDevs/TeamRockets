using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Informacion sobre el Zodiaco
[SerializeField]
public enum Elemento
{
    TIERRA,
    AIRE,
    FUEGO,
    AGUA,
    ESPIRITU
}

[SerializeField]
public enum Zodiaco
{
    ARIES,
    LEO,
    SAGITARIO,
    LIBRA,
    ACUARIO,
    GEMINIS,
    TAURO,
    CAPRICORNIO,
    ESCORPIO,
    PISCIS,
    CANCER,
    VIRGO
}

[System.Serializable]
[CreateAssetMenu(fileName = "NewModeloCoche", menuName = "InfoJuego/Signos", order = 3)]
public class Signo
{
    public Zodiaco zodiaco;
    public Elemento elemento;
    private float valuePlus = 0.10f, valueMinus = 0.10f;
    //añadir las caracteristicas que subiran/ bajaran
    public void ModificarStats(InfoCoche stats)
    {
        switch (zodiaco)
        {
            case Zodiaco.ARIES:
                stats.FinalMaxSpeed -= valueMinus * stats.FinalMaxSpeed;
                
                break;
            case Zodiaco.SAGITARIO:
                break;
            case Zodiaco.LEO:
                stats.FinalThrottle += stats.FinalThrottle*valuePlus;

                break;
            case Zodiaco.LIBRA:
                break;
            case Zodiaco.GEMINIS:
                break;
            case Zodiaco.ACUARIO:
                break;
            case Zodiaco.PISCIS:
                break;
            case Zodiaco.ESCORPIO:
                break;
            case Zodiaco.CANCER:
                break;
            case Zodiaco.CAPRICORNIO:
                break;
            case Zodiaco.TAURO:
                break;
            case Zodiaco.VIRGO:
                break;
         

        }
    }
}
