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
    private float valuePlus = 0.20f, valueMinus = 0.10f;
    //añadir las caracteristicas que subiran/ bajaran
    public void ModificarStats(InfoCoche stats,ModeloCoche statsBase,RELACIONMARCHAS RM, ESPACIODINAMICA ED)
    {
        switch (zodiaco)
        {
            case Zodiaco.ARIES:
                stats.FinalMaxSpeed -= valueMinus * stats.FinalMaxSpeed;
                stats.FinalWeight -= valuePlus * stats.FinalWeight;
                
                break;
            case Zodiaco.SAGITARIO:
                stats.FinalWeight -= valuePlus*2 * stats.FinalWeight;
                CalcularMarchas(false, stats, RM);


                break;
            case Zodiaco.LEO:
                stats.FinalThrottle += stats.FinalThrottle*valuePlus;
                stats.ElectricForceRecta -= valueMinus * stats.FinalWeight / 100;
                stats.ElectricForceCurva -= valueMinus * stats.FinalWeight / 100;
                break;
            case Zodiaco.LIBRA:
                stats.FinalMaxSpeed += stats.FinalMaxSpeed * valuePlus;
                stats.FinalWeight += valueMinus * stats.FinalWeight;
                break;
            case Zodiaco.GEMINIS:
                stats.FinalThrottle -= valueMinus * stats.FinalThrottle;
                CalcularMarchas(true, stats, RM);

                break;
            case Zodiaco.ACUARIO:
                stats.ElectricForceRecta += valueMinus * stats.FinalWeight / 100;
                stats.ElectricForceCurva += valueMinus * stats.FinalWeight / 100;
                stats.FinalThrottle -= stats.FinalThrottle * valueMinus;
                break;
            case Zodiaco.PISCIS:
                stats.FinalMaxSpeed += stats.FinalMaxSpeed * valuePlus;
                stats.FinalBrake -= stats.FinalBrake * valueMinus;

                break;
            case Zodiaco.ESCORPIO:
                stats.FinalWeight += valueMinus * stats.FinalWeight;
                CalcularMarchas(true, stats, RM);
                break;
            case Zodiaco.CANCER:
                stats.FinalBrake -= stats.FinalBrake * valueMinus;
                stats.ElectricForceRecta += valueMinus * stats.FinalWeight / 100;
                stats.ElectricForceCurva += valueMinus * stats.FinalWeight / 100;
                break;
            case Zodiaco.CAPRICORNIO:
                stats.FinalBrake += stats.FinalBrake * valuePlus;
                stats.ElectricForceRecta -= valueMinus * stats.FinalWeight / 100;
                stats.ElectricForceCurva -= valueMinus * stats.FinalWeight / 100;
                break;
            case Zodiaco.TAURO:

                stats.FinalWeight -= valuePlus * stats.FinalWeight;
                CalcularMarchas(false, stats, RM);
                break;
            case Zodiaco.VIRGO:
                stats.FinalMaxSpeed -= valueMinus * stats.FinalMaxSpeed;
                stats.FinalBrake += valuePlus * stats.FinalBrake;

                break;
            default:
                break;
         

        }


       
    }
    private void CalcularMarchas(bool plus, InfoCoche stats, RELACIONMARCHAS RM)
    {
        int signo = -1;
        if(plus)
        {
            signo = 1;
        }
        switch (RM)
        {
            case RELACIONMARCHAS.ACELERACION:

                stats.FinalMaxSpeed = stats.FinalMaxSpeed + 3f * signo;
                stats.FinalThrottle = stats.FinalThrottle + 1f * signo;
                break;
            case RELACIONMARCHAS.VELOCIDAD:

                stats.FinalMaxSpeed = stats.FinalMaxSpeed + 5f * signo;
                stats.FinalThrottle = stats.FinalThrottle + 1f * signo;
                break;
            case RELACIONMARCHAS.EQUILIBRADORM:

                stats.FinalMaxSpeed = stats.FinalMaxSpeed + 4f * signo;
                stats.FinalThrottle = stats.FinalThrottle + 1f * signo;
                break;
            default:
                stats.FinalMaxSpeed = stats.FinalMaxSpeed + 4f * signo;
                stats.FinalThrottle = stats.FinalThrottle + 1f * signo;

                break;
        }

    }
}
