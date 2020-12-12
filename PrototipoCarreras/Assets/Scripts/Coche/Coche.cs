using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Coche : MonoBehaviour
{
    //References
    public InfoCoche stats;
    public ModeloCoche statsBase;
    
    Vector3 []posiciones;
    private LineRenderer linea;
    private bool iniciado = false, esRecta, esCurva;
    private int currentpoint = 0;
    private float epsilon = 0.05f;

    public float speed = 2;
    public float minSpeed = 2;
    public float rozamiento = -0.05f;

    public int ID;

    //Carrera
    private float currentSpeed, currentAccel, currentUmbral;


    void Start()
    {
        linea = GetComponentInParent<LineRenderer>();

        //PARA TESTEAR BORRAR LUEGO
        stats = new InfoCoche();

        stats.ElectricForceCurva = 0;
        stats.ElectricForceCurva = 0;
        stats.FinalBrake = statsBase.BaseBrake;
        stats.FinalMaxSpeed = statsBase.BaseMaxSpeed;
        stats.FinalMinSpeed = 2;
        stats.FinalThrottle = statsBase.BaseThrottle;   
    }

    public void Init()
    {
        posiciones = new Vector3[linea.positionCount];
        linea.GetPositions(posiciones);
        iniciado = true;
        transform.position = posiciones[0];
    }
    
    private void Update()
    {
        //Min Max
        /////////////////////////////////
        //currentAccel = GetCurrentAccel();
        /////////////////////////////////
        
        /*if (Input.GetMouseButton(1))
        {
            if (speed < maxSpeed)
            {
                timePulsado += aceleracion;
                speed += Mathf.Abs(timePulsado);
            }
        }
        else
        {
            if (speed > minSpeed)
            {
                timePulsado -= aceleracion;
                speed -= Mathf.Abs(timePulsado);
            }
        }*/
    }

    public float GetCurrentAccel()
    {
        float aux = 0f;
        
        if(aux >= stats.FinalThrottle)
            aux = stats.FinalThrottle;

        if (aux <= stats.FinalBrake)
            aux = stats.FinalBrake;

        return aux;
    }
    public void SetCurrentAccel(float value)
    {
        currentAccel = stats.FinalThrottle * value;
    }
    public void SetCurrentBrake(float value)
    {
        currentAccel = stats.FinalBrake * value;
    }

    void FixedUpdate()
    {
        if (iniciado)
        {
            //Logica de Movimiento
            
            if(currentSpeed > currentUmbral)
            {
                SalirCircuito();
            }

            transform.position = CalculoNuevaPosicion();

            //Llegar a los Puntos
            
            if (HaLlegado())
            {
                currentpoint++;
               
                if (currentpoint == posiciones.Length)
                {
                    currentpoint = 0;
                    transform.position = posiciones[currentpoint];

                }
                else
                {
                    transform.rotation = Quaternion.LookRotation(transform.position, posiciones[currentpoint-1]);
                }
            }
        }
    }

    private bool HaLlegado()
    {
        bool x, y, z;
        
        //x = Mathf.Approximately( transform.position.x , posiciones[currentpoint].x);
        //y = Mathf.Approximately(transform.position.y, posiciones[currentpoint].y);
        //z = Mathf.Approximately(transform.position.z , posiciones[currentpoint].z);
        return (((transform.position.x >= posiciones[currentpoint].x - epsilon) && (transform.position.x <= posiciones[currentpoint].x + epsilon)) && ((transform.position.y >= posiciones[currentpoint].y - epsilon) && (transform.position.y <= posiciones[currentpoint].y + epsilon)) && ((transform.position.z >= posiciones[currentpoint].z - epsilon) && (transform.position.z <= posiciones[currentpoint].z + epsilon)));
    }

    public Vector3 CalculoNuevaPosicion()
    {
        float fuerza = ForcesBack();

        currentSpeed += currentAccel + fuerza;

        if (currentSpeed < stats.FinalMinSpeed)
        {
            currentSpeed = stats.FinalMinSpeed;
        }
        else if (currentSpeed > stats.FinalMaxSpeed)
        {
            currentSpeed = stats.FinalMaxSpeed;
        }
     
        return Vector3.MoveTowards(transform.position, posiciones[currentpoint], currentSpeed * Time.deltaTime);
    }

    public float ForcesBack()
    {
        float f = 0f, ef = 0f;

        if (esRecta)
        {
            ef = stats.ElectricForceRecta;
        }
        else if (esCurva)
        {
            ef = stats.ElectricForceCurva;
        }

        f = rozamiento + ef;
        
        return f;
    }

    public void SalirCircuito()
    {
        // Seguir Recto
        // Girar coche como si fuera un accidente
        // Respawnear en el punto donde se choco con Accel 0 y Velocidad 0
    }
}
