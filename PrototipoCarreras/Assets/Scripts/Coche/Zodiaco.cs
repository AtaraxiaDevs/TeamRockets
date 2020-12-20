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
    //añadir las caracteristicas que subiran/ bajaran
}
