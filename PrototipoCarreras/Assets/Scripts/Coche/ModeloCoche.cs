using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelo base del coche, se pueden crear objetos de esta clase en el editor
[System.Serializable]
[CreateAssetMenu(fileName = "NewModeloCoche", menuName = "InfoJuego/Coches", order = 1)]
public class ModeloCoche : ScriptableObject
{
    public float BaseMaxSpeed, BaseThrottle, BaseBrake;
    public float BaseWeight;
    public Elemento elemento;
    public Mesh mesh;
    public Material[] materialesCoche;

    public ModeloCoche Clone()
    {
        return (ModeloCoche)this.MemberwiseClone();
    }
}
