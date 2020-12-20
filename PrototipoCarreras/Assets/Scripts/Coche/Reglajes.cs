using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Informacion sobre los reglajes ( no deberia ser MonoBehavour)
public enum RELACIONMARCHAS { ACELERACION, VELOCIDAD, EQUILIBRADORM }
public enum ESPACIODINAMICA { RECTAS, CURVAS, EQUILIBRADOA }

public class Reglajes : MonoBehaviour
{
    public int numReglajes=3;
    public void ElegirReglajes(int a, int b)
    {
        RELACIONMARCHAS auxRM;
        ESPACIODINAMICA auxED;

        switch (a)
        {
            case 0:
                auxRM = RELACIONMARCHAS.ACELERACION;
                break;
            case 1:
                auxRM = RELACIONMARCHAS.VELOCIDAD;
                break;
            case 2:
                auxRM = RELACIONMARCHAS.EQUILIBRADORM;
                break;
            default:
                auxRM = RELACIONMARCHAS.EQUILIBRADORM;
                break;
        }

        switch (b)
        {
            case 0:
                auxED = ESPACIODINAMICA.RECTAS;
                break;
            case 1:
                auxED = ESPACIODINAMICA.CURVAS;
                break;
            case 2:
                auxED = ESPACIODINAMICA.EQUILIBRADOA;
                break;
            default:
                auxED = ESPACIODINAMICA.EQUILIBRADOA;
                break;
        }
        
        
        //inmortal.elinmortal.reglajeRM = a;
        //inmortal.elinmortal.reglajeRM = a;
    }

    public void CalcularReglajes(Coche c, RELACIONMARCHAS a, ESPACIODINAMICA b)
    {
        switch (a)
        {
            case RELACIONMARCHAS.ACELERACION:
                c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 0.05f;
                c.stats.FinalThrottle = c.statsBase.BaseMaxSpeed + 0.1f;
                break;
            case RELACIONMARCHAS.VELOCIDAD:
                c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 0.1f;
                c.stats.FinalThrottle = c.statsBase.BaseMaxSpeed + 0.05f;
                break;
            case RELACIONMARCHAS.EQUILIBRADORM:
                c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 0.75f;
                c.stats.FinalThrottle = c.statsBase.BaseMaxSpeed + 0.75f;
                break;
            default:
                c.stats.FinalMaxSpeed = c.statsBase.BaseMaxSpeed + 0.75f;
                c.stats.FinalThrottle = c.statsBase.BaseMaxSpeed + 0.75f;
                break;
        }

        switch (b)
        {
            case ESPACIODINAMICA.RECTAS:
                c.stats.ElectricForceCurva = -0.1f * c.statsBase.BaseWeight / 100;
                c.stats.ElectricForceRecta = -0.05f * c.statsBase.BaseWeight / 100;
                break;
            case ESPACIODINAMICA.CURVAS:
                c.stats.ElectricForceCurva = -0.05f * c.statsBase.BaseWeight / 100;
                c.stats.ElectricForceRecta = -0.1f * c.statsBase.BaseWeight / 100;
                break;
            case ESPACIODINAMICA.EQUILIBRADOA:
                c.stats.ElectricForceCurva = -0.75f * c.statsBase.BaseWeight / 100;
                c.stats.ElectricForceRecta = -0.75f * c.statsBase.BaseWeight / 100;
                break;
            default:
                c.stats.ElectricForceCurva = -0.75f * c.statsBase.BaseWeight / 100;
                c.stats.ElectricForceRecta = -0.75f * c.statsBase.BaseWeight / 100;
                break;
        }

        c.stats.FinalMinSpeed = 2 * c.statsBase.BaseWeight / 100;
        c.stats.FinalBrake = c.statsBase.BaseBrake;
    }
}
