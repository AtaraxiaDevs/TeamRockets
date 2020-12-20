using System;
using UnityEngine;


//Información sobre un módulo específico. Se puede crear en el editor
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
    // uno por cada modulo diferente que hay ( no solo la forma) para que el constructor funcione
{
    RECTA,
    CURVACERRADA,
    CURVABIERTA,
    CHICANE,
    VUELTA,
    CAMBIOCARRIL,
    ZIGZAG
}

[Serializable]
[CreateAssetMenu(fileName = "NewModeloModulo", menuName = "InfoJuego/Modulo", order = 2)]
public class ModuloInfo : ScriptableObject
{
    public TipoModulo tipoCircuito;
    public Elemento elemento;
    public float rozamiento;
    public float umbral;
}
