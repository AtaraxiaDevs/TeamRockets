using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gestiona el movimiento del coche, sobre todo. También tiene referencia a un objeto IAMoves que gestiona el movimiento de la IA. 
// El movimiento viene dado por las estadísticas del coche y la aceleración que le estemos mandando ( en caso de ser el jugador)
public class Coche : MonoBehaviour
{
    //Referencias
    public InfoCoche stats;
    public ModeloCoche statsBase;
    public ModuloInfo currentModulo;
    public IAMoves IA;
    public LineRenderer linea;
    public Transform socketCamara;

    //Informacion Coche
    public Vector3 [] posiciones;
    public bool iniciado = false, salidoCircuito = false, soyPlayer, accidente = false, multiPlayer=false;
    public int currentpoint = 0;
    public int currentPointMod, sizeMod;
    public int ID, currentCarril;
    private float epsilon = 0.05f, speedAnimSaliendo = 100;
    private float factorSpeed = 10, factorUnidades = 20;
    

    //Carrera
    public float currentSpeed, currentAccel, currentUmbral, porcentajeIAccel,accelIA;
    #region Unity
    void Start()
    {
        //linea = GetComponentInParent<LineRenderer>();

        IA = GetComponent<IAMoves>();

        //PARA TESTEAR BORRAR LUEGO
        
        currentPointMod = 0;
        accelIA = 0;
        porcentajeIAccel = 0;
    }
    void FixedUpdate()
    {


        if (iniciado)
        {

            //Lógica de Movimiento


            if (!salidoCircuito)
            {
                if (!soyPlayer) // Porcentaje de salida del circuito de la IA
                {

                    if (currentModulo.tipoCircuito.Equals(TipoModulo.CURVACERRADA))
                    {
                        float r = 0;

                        r = UnityEngine.Random.Range(0, 10000);

                        if (r < IA.porcentajeFallo)
                        {
                            accidente = true;


                        }
                    }

                }

                if ((currentSpeed > currentModulo.umbral && currentPointMod >= sizeMod / 2) || accidente)
                {
                    SalirCircuito();
                }
                if (!multiPlayer)
                {
                    transform.position = CalculoNuevaPosicion();


                }
                else if (soyPlayer)
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
    #endregion
    #region Carrera
    public void Init(ModuloInfo primerModulo)
    {
        nuevasPosiciones();
        currentModulo = primerModulo;
        iniciado = true;
        transform.position = posiciones[0];

        if (soyPlayer)
        {
            GetComponent<IAMoves>().enabled = false;
        }
    }
    public void nuevasPosiciones()
    {
        posiciones = new Vector3[linea.positionCount];
        linea.GetPositions(posiciones);
    }
    public void CambiarCarril()
    {
        currentCarril++;
        if (currentCarril >= 4)
        {
            currentCarril = 0;
        }
        linea = IA.currentCircuito.GetCircuito(currentCarril);
        nuevasPosiciones();
        iniciado = false;
        StartCoroutine(CambiandoaCarril());

    }
    IEnumerator CambiandoaCarril()
    {
        yield return new WaitForSeconds(0.5f);
        iniciado = true;
      
    }
    #endregion
    #region Carrera Fisicas
    public float GetCurrentAccel()
    {
        float aux = 0f;

        if (aux >= stats.FinalThrottle)
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

    public bool HaLlegado()
    {
        bool x, y, z;

        return (((transform.position.x >= posiciones[currentpoint].x - epsilon) && (transform.position.x <= posiciones[currentpoint].x + epsilon)) && ((transform.position.y >= posiciones[currentpoint].y - epsilon) && (transform.position.y <= posiciones[currentpoint].y + epsilon)) && ((transform.position.z >= posiciones[currentpoint].z - epsilon) && (transform.position.z <= posiciones[currentpoint].z + epsilon)));
    }
    public Vector3 CalculoNuevaPosicion()
    {
        float fuerza = ForcesBack();
        float speed;

        if (soyPlayer)
        {
            currentSpeed += (currentAccel / factorUnidades) + fuerza;

        }
        else //Comportamiento de la IA
        {
            currentSpeed = IA.CalculoNuevaPosicionIA(stats, currentSpeed, currentPointMod, sizeMod, factorUnidades, currentModulo, fuerza);
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
        for (int i = 0; i < speedAnimSaliendo; i++)
        {
            transform.position += -transform.forward;
            yield return new WaitForSeconds(2 / speedAnimSaliendo);
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
    #endregion
    #region Asignar Tipo de Coche
    public void AsignarCoche(DatosCoche datos)
    {
        //Debemos asignarle tambien el modelo 3d correspondiente
        statsBase = datos.infoBase;
        CalcularStats();

    }
    public void CalcularStats()
    {
        stats = new InfoCoche();

        stats.ElectricForceCurva = 0;
        stats.ElectricForceCurva = 0;
        stats.FinalBrake = statsBase.BaseBrake;
        stats.FinalMaxSpeed = statsBase.BaseMaxSpeed;
        stats.FinalMinSpeed = 20;
        stats.FinalThrottle = statsBase.BaseThrottle;
    }
    #endregion









}
