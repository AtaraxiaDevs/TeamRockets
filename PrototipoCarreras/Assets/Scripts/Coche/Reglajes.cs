using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Informacion sobre los reglajes ( no deberia ser MonoBehavour)
public enum RELACIONMARCHAS { ACELERACION, VELOCIDAD, EQUILIBRADORM }
public enum ESPACIODINAMICA { RECTAS, CURVAS, EQUILIBRADOA }

public class Reglajes 
{
    public int numReglajes=2;
    public RELACIONMARCHAS relacionMarchas;
    public ESPACIODINAMICA espacioDinamica;

    public void ElegirReglajes(int a, int b)
    {
        switch (a)
        {
            case 0:
                relacionMarchas = RELACIONMARCHAS.ACELERACION;
                break;
            case 1:
                relacionMarchas = RELACIONMARCHAS.VELOCIDAD;
                break;
            case 2:
                relacionMarchas = RELACIONMARCHAS.EQUILIBRADORM;
                break;
            default:
                relacionMarchas = RELACIONMARCHAS.EQUILIBRADORM;
                break;
        }

        switch (b)
        {
            case 0:
                espacioDinamica = ESPACIODINAMICA.RECTAS;
                break;
            case 1:
                espacioDinamica = ESPACIODINAMICA.CURVAS;
                break;
            case 2:
                espacioDinamica = ESPACIODINAMICA.EQUILIBRADOA;
                break;
            default:
                espacioDinamica = ESPACIODINAMICA.EQUILIBRADOA;
                break;
        }
    }

    public void CalcularReglajes(Coche c)
    {
        switch (relacionMarchas)
        {
            case RELACIONMARCHAS.ACELERACION:
                //c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 10f;
                //c.stats.FinalThrottle = c.statsBase.BaseThrottle+ 7f;
                c.stats.FinalMaxSpeed = c.stats.FinalMaxSpeed + 10f;
                c.stats.FinalThrottle = c.stats.FinalThrottle + 8f;
                break;
            case RELACIONMARCHAS.VELOCIDAD:
                //c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 30f;
                //c.stats.FinalThrottle = c.statsBase.BaseThrottle + 4f;
                c.stats.FinalMaxSpeed = c.stats.FinalMaxSpeed + 30f;
                c.stats.FinalThrottle = c.stats.FinalThrottle + 4f;
                break;
            case RELACIONMARCHAS.EQUILIBRADORM:
                //c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 20f;
                //c.stats.FinalThrottle = c.statsBase.BaseThrottle + 2f;
                c.stats.FinalMaxSpeed = c.stats.FinalMaxSpeed + 20f;
                c.stats.FinalThrottle = c.stats.FinalThrottle + 6f;
                break;
            default:
                //c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 20f;
                //c.stats.FinalThrottle = c.statsBase.BaseThrottle + 2f;
                break;
        }

        switch (espacioDinamica)
        {
            case ESPACIODINAMICA.RECTAS:
                c.stats.ElectricForceCurva += -0.5f * c.stats.FinalWeight/ 100;
                c.stats.ElectricForceRecta += -0.2f * c.stats.FinalWeight / 100;
                break;
            case ESPACIODINAMICA.CURVAS:
                c.stats.ElectricForceCurva += -0.2f * c.stats.FinalWeight / 100;
                c.stats.ElectricForceRecta += -0.5f * c.stats.FinalWeight / 100;
                break;
            case ESPACIODINAMICA.EQUILIBRADOA:
                c.stats.ElectricForceCurva += -0.35f * c.stats.FinalWeight / 100;
                c.stats.ElectricForceRecta += -0.35f * c.stats.FinalWeight / 100;
                break;
            default:
                c.stats.ElectricForceCurva += -0.35f * c.stats.FinalWeight / 100;
                c.stats.ElectricForceRecta += -0.35f * c.stats.FinalWeight / 100;
                break;
        }

        c.stats.FinalMinSpeed = 20 * c.stats.FinalWeight / 100;

    }
}
