using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Coche myCAR;
    Transform circuito;
    Camera myCamera;
    Quaternion rotation;
    Vector3 posTarget = new Vector3(0,17, -25);
    Vector3 posCircuito = new Vector3(0, 30, 30);
    Vector3 centro;

    public bool  esCircuito = false, tengoCoche=false;
    public float m_speed, epsilon = 0.05f;

    private void Awake()
    {
        
        myCamera = GetComponent<Camera>();
    }
    public void ComenzarCarrera(Coche myCAR)
    {

        tengoCoche = true;
        esCircuito = false;
        //transform.parent = null;
        this.myCAR = myCAR;
        
        //transform.parent = myCAR.transform;
        transform.position = myCAR.transform.TransformPoint(posTarget);
        // transform.forward = myCAR.right;
        
        transform.LookAt(myCAR.transform);
        //transform.forward = myCAR.forward;

       // rotation = transform.rotation;
    
    }

    private void FixedUpdate()
    {
        if (esCircuito)
        {
            transform.LookAt(centro);
            transform.RotateAround(centro, new Vector3(0, 1, 0), 3f * Time.deltaTime);
        }
        else if(tengoCoche)
        {
            // transform.eulerAngles= transform.parent.TransformPoint(transform.)
           
            transform.position = myCAR.transform.TransformPoint(posTarget);
            transform.LookAt(myCAR.transform);
          
        }
        
    }

    public void GirarEnCircuito( Transform circuito)
    {
        myCamera.fieldOfView = 60;
        esCircuito = true;
        transform.parent = null;
        centro = GetCenter(circuito);
        transform.position = circuito.transform.TransformPoint(posCircuito);
    }

    public void GirarEnCircuito(Vector3 centro,int num)
    {
        myCamera.fieldOfView = 60;
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
