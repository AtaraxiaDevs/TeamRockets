using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMoves : MonoBehaviour
{
    // Start is called before the first frame update
    private Coche coche;
    private int currentModulo;
    public Modulo moduloActual, moduloSiguiente;
    public Circuito currentCircuito;
  

    public float porcentajeFallo = 1;
    public float nivelRitmo = 2;
    public float accel = 0.005f, frenacion= 0.1f;

    void Start()
    {
        coche = GetComponent<Coche>();
    }

    public void CalculoNuevaPosicionIA()
    {

    }
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
}
