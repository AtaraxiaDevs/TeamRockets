using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 []posiciones;
    public LineRenderer linea;
    private bool iniciado = false;
    private int currentpoint = 0;
    private float epsilon = 0.05f;




    public float speed = 2;
    public float minSpeed = 2;
    private float maxSpeed = 14;

    private float timePulsado = 0;
    private float aceleracion = 0.0001f;
    void Start()
    {
       
    }
    public void init()
    {
            posiciones = new Vector3[linea.positionCount];
            linea.GetPositions(posiciones);
            iniciado = true;
            transform.position = posiciones[0];

    }
    // Update is called once per frame
    void Update()
    {
        if (iniciado)
        {
            transform.position = Vector3.MoveTowards(transform.position, posiciones[currentpoint], speed * Time.deltaTime);
            
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
                    transform.rotation = Quaternion.LookRotation(transform.position, posiciones[currentpoint]);
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (speed < maxSpeed)
            {
                timePulsado += aceleracion;
                speed += Mathf.Abs(timePulsado);
              ;
            }
            

        }
        else
        {
            if (speed > minSpeed)
            {
                timePulsado -= aceleracion;
                speed -=Mathf.Abs( timePulsado);
                Debug.Log(maxSpeed);
            }
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    timePulsado = 0;
        //}
        


    }
    private bool HaLlegado()
    {
        bool x, y, z;
        
        //x =Mathf.Approximately( transform.position.x , posiciones[currentpoint].x);
        //y = Mathf.Approximately(transform.position.y, posiciones[currentpoint].y);
        //z = Mathf.Approximately(transform.position.z , posiciones[currentpoint].z);
        return (((transform.position.x >= posiciones[currentpoint].x - epsilon) && (transform.position.x <= posiciones[currentpoint].x + epsilon)) && ((transform.position.y >= posiciones[currentpoint].y - epsilon) && (transform.position.y <= posiciones[currentpoint].y + epsilon)) && ((transform.position.z >= posiciones[currentpoint].z - epsilon) && (transform.position.z <= posiciones[currentpoint].z + epsilon)));
    }
}
