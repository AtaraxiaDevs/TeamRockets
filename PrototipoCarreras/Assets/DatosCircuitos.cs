using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatosCircuitos
{
    public string order;
    public float bestTime;
    public string creator;

    public DatosCircuitos()
    {
        order = "hola";
        bestTime = 0;
        creator = InformacionPersistente.singleton.nombreUsuario;
    }
}
