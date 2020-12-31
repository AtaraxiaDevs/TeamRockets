﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Coche myCAR;//( luego se le asignara)
    Quaternion rotation;
    Vector3 posTarget = new Vector3(0,15, -15);
    float epsilon = 0.05f;
    public bool preparada = false;
    public float m_speed;

    void Update()
    {
        if (preparada)
        {
            //float hayRotacion = Quaternion.Dot(myCAR.rotation, rotation);

            //if (Mathf.Abs(hayRotacion) <= epsilon)
            //{
            //    //if (hayRotacion < 0)
            //    //{
            //    //    rotation = Quaternion.Euler(0, -90f, 0);
            //    //}
            //    //else
            //    //{
            //    //    rotation = Quaternion.Euler(0, 90f, 0);
            //    //}

            //}
            //transform.rotation = rotation;
            //transform.LookAt(myCAR.transform);
            //if(myCAR.currentModulo.tipoCircuito.Equals(TipoModulo.CURVACERRADA) && (myCAR.currentPointMod == myCAR.sizeMod - 1))
            //{


            //}
            //transform.position = myCAR.transform.TransformPoint(posTarget);
            //Vector3 dir = myCAR.transform.position - transform.position;
            //transform.rotation = Quaternion.RotateTowards(rotation, Quaternion.LookRotation(dir), Time.time * m_speed);
        }

    }

    public void ComenzarCarrera(Coche myCAR)
    {
        this.myCAR = myCAR;
        transform.parent = myCAR.transform;
        transform.position = myCAR.transform.TransformPoint(posTarget);
       // transform.forward = myCAR.right;
        transform.LookAt(myCAR.transform);
        //transform.forward = myCAR.forward;
        rotation = transform.rotation;

        preparada = true;

    }
}
