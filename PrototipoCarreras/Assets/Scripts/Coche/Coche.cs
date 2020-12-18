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
    public ModuloInfo currentModulo;
    public IAMoves IA;

    public Vector3 [] posiciones;
    public LineRenderer linea;
    public Transform socketCamara;

    public bool iniciado = false, salidoCircuito = false, soyPlayer, accidente = false, multiPlayer=false;
    public int currentpoint = 0;
    public int currentPointMod, sizeMod;
    public int ID;
    private float epsilon = 0.05f, speedAnimSaliendo = 100;
    private float factorSpeed = 10, factorUnidades = 20;
    

    //Carrera
    public float currentSpeed, currentAccel, currentUmbral, porcentajeIAccel,accelIA;

    void Start()
    {
        //linea = GetComponentInParent<LineRenderer>();

        IA = GetComponent<IAMoves>();

        //PARA TESTEAR BORRAR LUEGO
        stats = new InfoCoche();

        stats.ElectricForceCurva = 0;
        stats.ElectricForceCurva = 0;
        stats.FinalBrake = statsBase.BaseBrake;
        stats.FinalMaxSpeed = statsBase.BaseMaxSpeed;
        stats.FinalMinSpeed = 20;
        stats.FinalThrottle = statsBase.BaseThrottle;
        currentPointMod = 0;
        accelIA = 0;
        porcentajeIAccel = 0;
    }

    public void Init(ModuloInfo primerModulo)
    {
        posiciones = new Vector3[linea.positionCount];
        linea.GetPositions(posiciones);
        currentModulo = primerModulo;
        iniciado = true;
        transform.position = posiciones[0];

        if (soyPlayer)
        {
            GetComponent<IAMoves>().enabled = false;
        }
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

            if (!salidoCircuito)
            {
                if (!soyPlayer)
                {
                   
                    //if (currentModulo.tipoCircuito.Equals(TipoModulo.CURVACERRADA))
                    //{
                    //    float r = 0;

                    //    r = UnityEngine.Random.Range(0, 100000);

                    //    if (r < IA.porcentajeFallo)
                    //    {
                    //        accidente = true;
                           

                    //    }
                    //}
                  
                }

                if ((currentSpeed > currentModulo.umbral&& currentPointMod >= sizeMod / 2) || accidente)
                {
                    SalirCircuito();
                }
                if (!multiPlayer)
                {
                    transform.position = CalculoNuevaPosicion();
                 
                    
                }
                else if(soyPlayer)
                {
                    transform.position = CalculoNuevaPosicion();
                }
                

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
                        transform.rotation = Quaternion.LookRotation(transform.position - posiciones[currentpoint], posiciones[currentpoint]);
                    }
                   
                        currentPointMod++;
                    
                }
            }
        }   
    }

    public bool HaLlegado()
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
        float speed;

        if (soyPlayer)
        {
            currentSpeed += (currentAccel / factorUnidades) + fuerza;
            //Debug.Log("currentJugador= (" +currentAccel + "/" + factorUnidades + ")" + fuerza);
        }
        else
        {
            //comprobacion siguiente es curva
            if (IA.moduloSiguiente != null)
            {


                if ((IA.SiguienteCurva() || (currentPointMod >= sizeMod / 2)))
                {
                    if (currentSpeed > IA.moduloSiguiente.myInfo.umbral - IA.nivelRitmo)
                    {
                        if (accelIA > stats.FinalBrake)
                        {
                            accelIA = porcentajeIAccel * stats.FinalBrake;
                            porcentajeIAccel += IA.frenacion;
                            Debug.Log("Frenando");
                        }
                        else
                        {
                            porcentajeIAccel = 0;
                        }
                    }
                    else
                    {
                        porcentajeIAccel = 0;
                    }



                }
                else
                {

                    if (currentSpeed < currentModulo.umbral - IA.nivelRitmo)
                    {
                        if (accelIA < stats.FinalThrottle)
                        {
                            accelIA = porcentajeIAccel * stats.FinalThrottle;
                            porcentajeIAccel += IA.accel;
                            Debug.Log("Acelerando");
                        }
                        else
                        {
                            porcentajeIAccel = 0;
                        }
                    }
                    else
                    {
                        porcentajeIAccel = 0;
                    }

                }

                currentSpeed += (accelIA / factorUnidades) + fuerza;
                //comprobacion Umbral current

            }

            if(currentSpeed>(currentModulo.umbral - IA.nivelRitmo))
            {
                currentSpeed = currentModulo.umbral - IA.nivelRitmo;
            }

        }

        if (currentSpeed < stats.FinalMinSpeed)
        {
            currentSpeed = stats.FinalMinSpeed;
         
        }
        else if (currentSpeed > stats.FinalMaxSpeed)
        {
            currentSpeed = stats.FinalMaxSpeed;
          
        }

        speed = currentSpeed / factorSpeed;
    

        return Vector3.MoveTowards(transform.position, posiciones[currentpoint], speed * Time.deltaTime);

    }

    public float ForcesBack()
    {
        float f = 0f, ef = 0f;

        //if (esRecta)
        //{
        //    ef = stats.ElectricForceRecta;
        //}
        //else if (esCurva)
        //{
        //    ef = stats.ElectricForceCurva;
        //}

        f = currentModulo.rozamiento + ef;
        
        return f;
    }
    IEnumerator SaliendoCircuito(Vector3 posIni)
    {
        for(int i = 0; i < speedAnimSaliendo;i++) 
        {
            transform.position += -transform.forward;
            yield return new WaitForSeconds(2/speedAnimSaliendo);
        }

        transform.position = posIni;
        salidoCircuito = false;
        accidente = false;
        currentSpeed = stats.FinalMinSpeed;
    }

    public void SalirCircuito()
    {
        // Seguir Recto
        // Girar coche como si fuera un accidente
        // Respawnear en el punto donde se choco con Accel 0 y Velocidad 0
        salidoCircuito = true;
        StartCoroutine(SaliendoCircuito(transform.position));
    }
}
