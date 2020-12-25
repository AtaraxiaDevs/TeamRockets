using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gestiona el movimiento del coche, sobre todo. También tiene referencia a un objeto IAMoves que gestiona el movimiento de la IA. 
// El movimiento viene dado por las estadísticas del coche y la aceleración que le estemos mandando ( en caso de ser el jugador)
public class PosicionesCarreraComparator : Comparer<Coche>
{
    public override int Compare(Coche x, Coche y)
    {
        return (y.posiciones.Length * y.vuelta + y.currentpoint) - (x.posiciones.Length * x.vuelta + x.currentpoint);
    }
}
public enum Marcha
{
    PRIMERA,
    SEGUNDA,
    TERCERA,
    CUARTA,
    QUINTA
}

public class Coche : MonoBehaviour
{
    //Referencias
    public InfoCoche stats;
    public ModeloCoche statsBase;
    public ModuloInfo currentModulo;
    public IAMoves IA;
    public LineRenderer linea;
    public Transform socketCamara;
    private CarreraController carreraController;

    //Informacion Coche
    public Signo[] signosAnadidos = new Signo[2];
    public Vector3 [] posiciones;
    public bool iniciado = false, salidoCircuito = false, soyPlayer, accidente = false, multiPlayer=false;
    public int currentpoint = 0;
    public int currentPointMod, sizeMod;
    public int ID, currentCarril, vuelta = 0;

    private Marcha currentMarcha = Marcha.PRIMERA;
    private bool[] Calado;

    private float epsilon = 0.05f, speedAnimSaliendo = 100;
    private float factorSpeed = 10, factorUnidades = 20;

    //Carrera
    public float currentSpeed, currentAccel, currentUmbral;
    public float accel = 0.005f, frenacion = 0.01f, porcentajeIAccel, accelIA;

    #region Unity
    void Start()
    {
        //linea = GetComponentInParent<LineRenderer>();

        IA = GetComponent<IAMoves>();
        carreraController = FindObjectOfType<CarreraController>();
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

                    if (currentpoint == posiciones.Length)// Vuelta
                    {
                        carreraController.UpdateCarrera(ID,vuelta);
                        vuelta++;
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
    public void SetCurrentMarcha( int marcha)
    {
        currentMarcha = (Marcha)marcha;
    }

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

    public void FormulaMovimiento(float f)
    {
        currentSpeed += (currentAccel / factorUnidades) + f;
    }

    public void AcelProgresiva(int ID)
    {
        if (currentSpeed < stats.Marchas[ID])
        {
            accelIA = porcentajeIAccel * stats.FinalThrottle;
            porcentajeIAccel += accel;
        }
        else
        {
            porcentajeIAccel = 0;
        }
    }

    public void FrenProgresiva(int ID)
    {
        if (currentSpeed > stats.Marchas[ID])
        {
            accelIA = porcentajeIAccel * stats.FinalBrake;
            porcentajeIAccel += frenacion;
        }
        else
        {
            porcentajeIAccel = 0;
        }
    }

    public Vector3 CalculoNuevaPosicion()
    {
        float fuerza = ForcesBack();
        float speed;
        int ID;

        if (soyPlayer)
        {
            //dependiendo de la marcha currentAccel aumenta( cuanto? depende de qué marcha) hasta 
            switch(currentMarcha)
            {
                //Si current es mayor, accel-> frenar, cada vez mas
                //Si current es menor, accel-> acelerar, cada vez mas

                case Marcha.PRIMERA:

                    ID = 0;

                    FrenProgresiva(ID);

                    currentAccel = accelIA;

                    //if (currentSpeed > stats.Marchas[ID + 2] && !Calado[ID])
                    //{
                    //    Calado[ID] = true;
                    //    currentAccel = stats.FinalBrake;
                    //}

                    //if (Calado[ID])
                    //{
                        
                    //}
                    
                    FormulaMovimiento(fuerza);

                    if (currentSpeed < stats.Marchas[ID])
                        currentSpeed = stats.Marchas[ID];

                    break;

                case Marcha.SEGUNDA:

                    ID = 1;

                    if (currentSpeed < stats.Marchas[ID])
                    {
                        AcelProgresiva(ID);
                    }
                    else if (currentSpeed > stats.Marchas[ID])
                    {
                        FrenProgresiva(ID);
                    }

                    currentAccel = accelIA;

                    FormulaMovimiento(fuerza);

                    break;

                case Marcha.TERCERA:

                    ID = 2;

                    if (currentSpeed < stats.Marchas[ID])
                    {
                        AcelProgresiva(ID);
                    }
                    else
                    {
                        FrenProgresiva(ID);
                    }

                    currentAccel = accelIA;

                    FormulaMovimiento(fuerza);

                    if (currentSpeed > stats.Marchas[ID])
                        currentSpeed = stats.Marchas[ID];

                    break;

                case Marcha.CUARTA:

                    ID = 3;

                    if (currentSpeed < stats.Marchas[ID])
                    {
                        AcelProgresiva(ID);
                    }
                    else
                    {
                        FrenProgresiva(ID);
                    }

                    currentAccel = accelIA;

                    FormulaMovimiento(fuerza);

                    if (currentSpeed > stats.Marchas[ID])
                        currentSpeed = stats.Marchas[ID];

                    break;

                case Marcha.QUINTA:

                    ID = 4;
                    
                    AcelProgresiva(ID);

                    currentAccel = accelIA;

                    FormulaMovimiento(fuerza);

                    if (currentSpeed > stats.Marchas[ID])
                        currentSpeed = stats.Marchas[ID];

                    break;
            }
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

    private bool EsCurva()
    {
        return currentModulo.tipoCircuito.Equals(TipoModulo.CURVABIERTA) && currentModulo.tipoCircuito.Equals(TipoModulo.CURVACERRADA);
    }

    public float ForcesBack()
    {
        float f = 0f, ef = 0f;

        if (!EsCurva())
        {
            ef = stats.ElectricForceRecta;
        }
        else
        {
            ef = stats.ElectricForceCurva;
        }

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
        signosAnadidos[0] = datos.signos[0];
        signosAnadidos[1] = datos.signos[1];
        CalcularStats();
    }
    public void CalcularStats()
    {
        stats = new InfoCoche();

        stats.Marchas = new float[5];
        Calado = new bool[stats.Marchas.Length];
        stats.ElectricForceCurva = 0;
        stats.ElectricForceCurva = 0;
        stats.FinalBrake = statsBase.BaseBrake;
        stats.FinalMaxSpeed = statsBase.BaseMaxSpeed;
        stats.FinalMinSpeed = 20;
        stats.FinalThrottle = statsBase.BaseThrottle;

        //

        for (int i = 0; i < Calado.Length; i++)
        {
            Calado[i] = false;
        }

        stats.Marchas[0] = stats.FinalMinSpeed;

        float aux = stats.FinalMaxSpeed - stats.FinalMinSpeed;
        float aux2 = aux / stats.Marchas.Length;

        for (int i = 1; i < stats.Marchas.Length - 1; i++)
        {
            stats.Marchas[i] = i * aux2 + stats.FinalMinSpeed;
        }

        stats.Marchas[4] = stats.FinalMaxSpeed;

        //

        signosAnadidos[0].ModificarStats(stats);
        signosAnadidos[1].ModificarStats(stats);
    }
    #endregion


}
