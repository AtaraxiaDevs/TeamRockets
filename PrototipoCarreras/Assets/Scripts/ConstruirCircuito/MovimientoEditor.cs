﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEditor : MonoBehaviour
{
    //input mouse 1
    Vector3 antiguo,nuevo;
    Camera main;
    bool moviendose;
    float width = 100, height = 100;
    float maxSize = 200, minSize = 50;
    float speedTouch = 0.5f;
    float speedScroll = 40f;
    float speedMove = 3f, speedMoveMovil = 8f;
    float epsilonTouch = 1f;
    
    private void Start()
    {
        main = Camera.main;
     
    }
    private void Update()
    {
       
        if (InformacionPersistente.singleton.esMovil)
        {
            if (Input.touchCount == 2)
            {
                moviendose = true;
                
                Touch primero = Input.GetTouch(0);
                Touch segundo = Input.GetTouch(1);
                if(primero.phase.Equals(TouchPhase.Began)|| segundo.phase.Equals(TouchPhase.Began))
                {
                    nuevo = (primero.position + segundo.position) / 2;
                    antiguo = nuevo;
                }
                else
                {
                    antiguo = nuevo;
                    nuevo = (primero.position + segundo.position) / 2;
                }
                Vector2 primeroOld = primero.position - primero.deltaPosition;
                Vector2 segundoOld = segundo.position - segundo.deltaPosition;
                float distanciaAnterior = Vector2.Distance(primeroOld, segundoOld);
                float distanciaActual = Vector2.Distance(primero.position , segundo.position);

                float deltadistance = distanciaAnterior - distanciaActual;
                if(Mathf.Abs(deltadistance)>epsilonTouch)
                    Zoom(-deltadistance,speedTouch);
            }
           
            else
            {
                moviendose = false;
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll,speedScroll);
            if (Input.GetMouseButtonDown(1))
            {
                moviendose = true;

            }
            else if (Input.GetMouseButtonUp(1))
            {
                moviendose = false;
            }

        }
     
    }
    
    private void FixedUpdate()
    {
        if ((moviendose))
        {
            Vector3 pos;
            if (InformacionPersistente.singleton.esMovil)
            {
            
                Vector3 movimiento = nuevo-antiguo;
                movimiento.y = main.transform.position.y; 
                main.transform.position = Vector3.MoveTowards(main.transform.position, movimiento, speedMoveMovil);
            }
            else
            {
                pos = main.ScreenToWorldPoint(Input.mousePosition);
                pos.y = main.transform.position.y;
                main.transform.position = Vector3.MoveTowards(main.transform.position, pos, speedMove);
            }
            Vector3 position = main.transform.position;
            if( (Mathf.Abs(main.transform.position.x) > width))
            {
                if (main.transform.position.x < 0)
                {
                    main.transform.position = new Vector3(-width, position.y, position.z);
                }
                else
                {
                    main.transform.position = new Vector3(width, position.y, position.z);
                }
            }
            position = main.transform.position;
            if ((Mathf.Abs(main.transform.position.z) > height))
            {
           
                if (main.transform.position.z < 0)
                {
                    main.transform.position = new Vector3(position.x, position.y,- height);
                }
                else
                {
                    main.transform.position = new Vector3(position.x, position.y, height);

                }
            }
        }
        
    }
    private void Zoom(float delta,float speed)
    {
        main.orthographicSize += delta * speed;
        if (main.orthographicSize > maxSize)
        {
            main.orthographicSize = maxSize;
        }
        else if (main.orthographicSize < minSize)
        {
            main.orthographicSize = minSize;
        }
    }

    
}
