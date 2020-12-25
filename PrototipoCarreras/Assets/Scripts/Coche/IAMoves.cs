using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase tiene información del siguiente modulo del circuito para saber si la IA tiene que frenar o si puede acelerar. Calcula eel movimiento
// de la IA.
public class IAMoves : MonoBehaviour
{
    // Referencias
    public Modulo moduloActual, moduloSiguiente;
    public Circuito currentCircuito;
    private Coche coche;
    private int currentModulo;
    //Informacion

    public float porcentajeFallo = 1;
    public float nivelRitmo = 2;
    private float accel = 0.005f, frenacion= 0.01f;
    public float accelIA, porcentajeIAccel;

    #region Unity
    void Start()
    {
        coche = GetComponent<Coche>();
    }
    #endregion
    #region Calculos
    public float CalculoNuevaPosicionIA(InfoCoche stats, float currentSpeed, int currentPointMod, int sizeMod, float factorUnidades, ModuloInfo currentMod, float fuerza)
    {
        if (moduloSiguiente != null)
        {
            if ((SiguienteCurva() || (currentPointMod >= sizeMod / 2)))
            {
                if (currentSpeed > moduloSiguiente.myInfo.umbral - nivelRitmo)
                {
                    if (accelIA > stats.FinalBrake)
                    {
                        accelIA = porcentajeIAccel * stats.FinalBrake;
                        porcentajeIAccel += frenacion;

                        Debug.Log("Frenando");
                    }
                    else
                    {
                        porcentajeIAccel = 0;
                    }
                }
                else
                {
                    if (currentSpeed < currentMod.umbral - nivelRitmo)
                    {
                        if (accelIA < stats.FinalThrottle)
                        {
                            accelIA = porcentajeIAccel * stats.FinalThrottle;
                            porcentajeIAccel += accel;

                            Debug.Log("Acelerando");
                        }
                        else
                        {
                            porcentajeIAccel = 0;
                        }
                    }
                }
            }
            else
            {
                if (currentSpeed < currentMod.umbral - nivelRitmo)
                {
                    if (accelIA < stats.FinalThrottle)
                    {
                        accelIA = porcentajeIAccel * stats.FinalThrottle;
                        porcentajeIAccel += accel;

                        Debug.Log("Acelerando");
                    }
                    else
                    {
                        porcentajeIAccel = 0;
                    }
                }
                else
                {
                    porcentajeIAccel = 0;
                }
            }

            currentSpeed += (accelIA / factorUnidades) + fuerza;
            //comprobacion Umbral current
        }

        if (currentSpeed > (currentMod.umbral - nivelRitmo))
        {
            currentSpeed = currentMod.umbral - nivelRitmo;
        }

        return currentSpeed;
    }
    #endregion
    #region Devolver Informacion

    public bool SiguienteCurva()
    {
        return moduloSiguiente.myInfo.tipoCircuito.Equals(TipoModulo.CURVACERRADA) || moduloSiguiente.myInfo.tipoCircuito.Equals(TipoModulo.CURVABIERTA);
    }

    public void ModuloSiguiente(int idCurrent)
    {
        if (idCurrent < 0)
        {
            moduloActual = currentCircuito.GetModulo(0);
            moduloSiguiente = currentCircuito.GetModulo(1);
        }
        else
        {
            if (moduloSiguiente != null)
            {
                moduloActual = moduloSiguiente;
            }
            else
            {
                moduloActual = currentCircuito.GetModulo(idCurrent);
            }

            moduloSiguiente = currentCircuito.GetModulo(idCurrent + 1);
        }
    }
    #endregion

}
