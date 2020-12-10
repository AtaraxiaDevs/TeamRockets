using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RELACIONMARCHAS { ACELERACION, VELOCIDAD, EQUILIBRADORM }
public enum ESPACIODINAMICA { RECTAS, CURVAS, EQUILIBRADOA }

public class Reglajes : MonoBehaviour
{
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
