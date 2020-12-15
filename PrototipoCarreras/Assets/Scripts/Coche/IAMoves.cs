using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMoves : MonoBehaviour
{
    // Start is called before the first frame update
    private Coche coche;
    public Modulo moduloActual, moduloSiguiente;

    public float porcentajeFallo = 5f;
    public float nivelRitmo = 2;

    void Start()
    {
        coche = GetComponent<Coche>();
    }

    public void CalculoNuevaPosicionIA()
    {

    }
}
