using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerElegirCircuito : MonoBehaviour
{
    public Text nombreCircuito;

    public void cambiarNombre()
    {
        nombreCircuito.text = InformacionPersistente.singleton.nombreCircuitoActual;
        Debug.Log(nombreCircuito.text);
        Debug.Log(InformacionPersistente.singleton.nombreCircuitoActual);
    }
}
