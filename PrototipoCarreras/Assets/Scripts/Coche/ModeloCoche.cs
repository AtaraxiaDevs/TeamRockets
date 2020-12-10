using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewModeloCoche", menuName = "InfoJuego/Coches", order = 1)]
public class ModeloCoche : ScriptableObject
{
    public float BaseMaxSpeed, BaseThrottle, BaseBrake;
    public float BaseWeight;
}
