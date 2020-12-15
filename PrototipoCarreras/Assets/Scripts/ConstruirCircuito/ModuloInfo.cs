using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum TipoSocket
{
    POSX,
    NEGX,
    POSZ,
    NEGZ
}
[Serializable]
public enum TipoModulo
{
    RECTA,
    CURVACERRADA,
    CURVABIERTA,
    CHICANE,
    CAMBIOCARRIL

}
[Serializable]
[CreateAssetMenu(fileName = "NewModeloModulo", menuName = "InfoJuego/Modulo", order = 2)]
public class ModuloInfo :ScriptableObject
{
    public TipoModulo tipoCircuito;
    public Elemento elemento;
    public float rozamiento;
    public float umbral;

  
}
