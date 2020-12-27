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
    private float accel = 0.01f, frenacion= 0.01f;
    public float accelIA, porcentajeIAccel;
    public bool acelerando = false;

    #region Unity
    void Start()
    {
        coche = GetComponent<Coche>();
    }
    #endregion
    #region Calculos
    public float CalculoNuevaPosicionIA(InfoCoche stats, float currentSpeed, int currentPointMod, int sizeMod, float factorUnidades, ModuloInfo currentMod, float fuerza,Marcha marcha)
    {
        if (moduloSiguiente != null)
        {
            if ((SiguienteCurva() && (currentPointMod >= sizeMod / 2)))
            {
                
                if (currentSpeed > moduloSiguiente.myInfo.umbral - nivelRitmo)
                {
                    Frenar(currentSpeed, marcha, stats);
                    if (accelIA > stats.FinalBrake)
                    {
                        if (acelerando)
                        {
                            acelerando = false;
                            porcentajeIAccel = 0;
                        }
                      
                        accelIA = porcentajeIAccel * stats.FinalBrake;
                        porcentajeIAccel += frenacion;

                        //Debug.Log("Frenando");
               
                    }
                 
                }
                else if (currentSpeed < currentMod.umbral - nivelRitmo)
                {
                    Acelerar(currentSpeed, marcha, stats);
                    if (!acelerando)
                        {
                            acelerando = true;
                            porcentajeIAccel = 0;
                        }
                        if (accelIA < stats.FinalThrottle)
                        {
                            accelIA = porcentajeIAccel * stats.FinalThrottle;
                            porcentajeIAccel += accel;

                        // Debug.Log("Acelerando");
                        }
                       
                }
             
            }
            
            else
            {
                if (currentSpeed < currentMod.umbral - nivelRitmo)
                {
                    Acelerar(currentSpeed, marcha, stats);
                    if (!acelerando)
                    {
                        acelerando = true;
                        porcentajeIAccel = 0;
                    }
                    if (accelIA < stats.FinalThrottle)
                    {
                        accelIA = porcentajeIAccel * stats.FinalThrottle;
                        porcentajeIAccel += accel;

                        // Debug.Log("Acelerando");
          
                    }
                 
                }
              
            }
            if (porcentajeIAccel == 1)
            {
                porcentajeIAccel = 1;
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
    private void Acelerar(float currentSpeed, Marcha marcha, InfoCoche stats)
    {
        if ((int)marcha < (int)Marcha.QUINTA)
        {
            if (currentSpeed>= stats.Marchas[(int)marcha])
            {
           
                coche.SetCurrentMarcha((int)marcha + 1);
                porcentajeIAccel = 0;
            }
        }


    }
    private void Frenar(float currentSpeed, Marcha marcha, InfoCoche stats)
    {
        if((int)marcha> (int) Marcha.PRIMERA)
        {
            if (currentSpeed <= stats.Marchas[(int)marcha-1])
            {
              
                    coche.SetCurrentMarcha((int)marcha - 1);
                    porcentajeIAccel = 0;
                
            }
        }
     
    }
    #endregion

}
