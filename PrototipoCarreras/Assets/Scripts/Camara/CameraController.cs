using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Coche myCAR;//( luego se le asignara)
    Transform circuito;

    Quaternion rotation;
    Vector3 posTarget = new Vector3(0,15, -15);
    Vector3 posCircuito = new Vector3(0, 20, 20);
    Vector3 centro;

    public bool preparada = false, esCircuito = false;
    public float m_speed, epsilon = 0.05f;
   
    public void ComenzarCarrera(Coche myCAR)
    {
        esCircuito = false;
        transform.parent = null;
        this.myCAR = myCAR;
        transform.parent = myCAR.transform;
        transform.position = myCAR.transform.TransformPoint(posTarget);
        // transform.forward = myCAR.right;
        transform.LookAt(myCAR.transform);
        //transform.forward = myCAR.forward;
        rotation = transform.rotation;

        preparada = true;
    }

    private void FixedUpdate()
    {
        if (esCircuito)
        {
            transform.LookAt(centro);
            transform.RotateAround(centro, new Vector3(0, 1, 0), 3f * Time.deltaTime);
        }
    }

    public void GirarEnCircuito( Transform circuito)
    {       
        esCircuito = true;
        transform.parent = null;
        centro = GetCenter(circuito);
        transform.position = circuito.transform.TransformPoint(posCircuito);
    }

    public void GirarEnCircuito(Vector3 centro,int num)
    {
        transform.parent = null;
        esCircuito = true;

        this.centro = centro;
        transform.position = posCircuito*num/3;
    }

    private Vector3 GetCenter( Transform trans)
    {
        Vector3 suma = Vector3.zero;
        int contMod = 0;

        for(int i = 0; i < trans.childCount; i++)
        {
            if (trans.GetChild(i).GetComponent<Modulo>() != null)
            {
                suma += trans.GetChild(i).transform.position;
                contMod++;
            }
        }

        posCircuito = posCircuito * contMod / 3;
        return suma / trans.childCount;
    }
}
