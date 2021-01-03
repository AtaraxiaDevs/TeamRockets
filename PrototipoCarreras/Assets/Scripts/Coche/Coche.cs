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
    //TESTING QUITAR
    public RELACIONMARCHAS RM;
    public ESPACIODINAMICA ED;

    //Referencias
    public InfoCoche stats;
    public ModeloCoche statsBase;
    public ModuloInfo currentModulo;
    public IAMoves IA;
    public LineRenderer linea;
    public Transform socketCamara;
    private CarreraController carreraController;
    private Animator animator;

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
    private  float accel = 0.05f, frenacion = 0.09f, porcentajeIAccel, accelIA;
    private bool acelerando = true;
    public int ultimaVueltaCambio = -1;

    public float bonusTierra = 0, bonusFuego = 0, bonusAgua = 0, bonusAire = 0;

    private Vector3 up;
    #region Unity
    void Start()
    {
        //linea = GetComponentInParent<LineRenderer>();
        animator = GetComponentInChildren<Animator>();
        IA = GetComponent<IAMoves>();
        carreraController = FindObjectOfType<CarreraController>();
        //PARA TESTEAR BORRAR LUEGO
        
        currentPointMod = 0;
        accelIA = 0;
        porcentajeIAccel = 0;
        up = transform.up;
    }
    void FixedUpdate()
    {
        if (iniciado)
        {
            //Lógica de Movimiento

            if (!salidoCircuito)
            {
                RotarNave();
         
                //transform.LookAt(posiciones[currentpoint]);
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

                    currentPointMod++;
                }
            }
        }
    }

    #endregion
    #region Carrera
    private void RotarNave()
    {
        Quaternion aux = transform.rotation;
        Vector3 dir = posiciones[currentpoint] - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), Time.time * 0.15f);
        float giroY = (transform.rotation.eulerAngles - aux.eulerAngles).y;
        transform.Rotate(0, 0, giroY );
        //rotar z
        if (soyPlayer)
        {
            Debug.Log(transform.rotation.eulerAngles - aux.eulerAngles);
        }
    }
    public void Init(ModuloInfo primerModulo)
    {
        NuevasPosiciones();
        currentModulo = primerModulo;
        iniciado = true;
        transform.position = posiciones[0];
        transform.LookAt(posiciones[1]);

        if (soyPlayer)
        {
            GetComponent<IAMoves>().enabled = false;
        }
    }

    public void NuevasPosiciones()
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
        NuevasPosiciones();
        iniciado = false;
        StartCoroutine(CambiandoaCarril());
    }

    IEnumerator CambiandoaCarril()
    {
        animator.SetBool("CambioCarril", true);
        //yield return new WaitUntil(()=>!animator.GetCurrentAnimatorStateInfo(0).IsTag("1"));
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("CambioCarril", false);
        iniciado = true;
    }
    #endregion
    #region Carrera Fisicas
    public void SetCurrentMarcha( int marcha)
    {
        if (marcha < (int)currentMarcha)
        {
            acelerando = false;
        }
        else
        {
            acelerando = true;
        }
        currentMarcha = (Marcha)marcha;
        porcentajeIAccel = 0;
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

        if (currentSpeed< stats.Marchas[0])
        {
            currentSpeed = stats.Marchas[0]+ f;
        }

        if (soyPlayer)
        {
            //Debug.Log("currentspeed" + currentSpeed+"currentAccel" + currentAccel+"fuerza" + f);
        }
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

        if (porcentajeIAccel >= 1)
        {
            porcentajeIAccel = 1;
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

        if (porcentajeIAccel >= 1)
        {
            porcentajeIAccel = 1;
        }
    }

    public Vector3 CalculoNuevaPosicion()
    {
        float fuerza = ForcesBack();
        float speed;

        if (soyPlayer)
        {

            //dependiendo de la marcha currentAccel aumenta( cuanto? depende de qué marcha) hasta
            //Debug.Log("Marcha: " + currentMarcha.ToString() + " accel: "+accelIA+" acelerando "+ acelerando+" porcentaje "+ porcentajeIAccel);

            //Si current es mayor, accel-> frenar, cada vez mas
            //Si current es menor, accel-> acelerar, cada vez mas

            if (currentMarcha == 0)
            {
                FrenProgresiva(0);

                currentAccel = accelIA;

                if (acelerando)
                {
                    if (currentSpeed >= stats.Marchas[0])
                        currentSpeed = stats.Marchas[0] + fuerza;
                    else
                        FormulaMovimiento(fuerza);
                }

                if (currentSpeed <= stats.Marchas[0])
                    currentSpeed = stats.Marchas[0] + fuerza;
                else
                    FormulaMovimiento(fuerza);
            }
            else
            {
                if (currentSpeed < stats.Marchas[(int)currentMarcha])
                {
                    AcelProgresiva((int)currentMarcha);
                }
                else if ((currentSpeed > stats.Marchas[(int)currentMarcha])&&((int)currentMarcha!=(int)Marcha.QUINTA))
                {
                    FrenProgresiva((int)currentMarcha);
                }

                currentAccel = accelIA;

                if (acelerando)
                {
                    if (currentSpeed >= stats.Marchas[(int)currentMarcha])
                        currentSpeed = stats.Marchas[(int)currentMarcha] + fuerza;
                    else
                        FormulaMovimiento(fuerza);
                }
                else
                {
                    if (currentSpeed <= stats.Marchas[(int)currentMarcha])
                        currentSpeed = stats.Marchas[(int)currentMarcha] + fuerza;
                    else
                        FormulaMovimiento(fuerza);
                }
            } 
        }
        else //Comportamiento de la IA
        {
            currentSpeed = IA.CalculoNuevaPosicionIA(stats, currentSpeed, currentPointMod, sizeMod, factorUnidades, currentModulo, fuerza,currentMarcha);
        }

        if (currentSpeed < stats.Marchas[0] + fuerza)
        {
            currentSpeed = stats.FinalMinSpeed+ fuerza;
        }
        else if (currentSpeed > stats.FinalMaxSpeed + fuerza)
        {
            currentSpeed = stats.FinalMaxSpeed+ fuerza;
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

        float rozamiento = currentModulo.rozamiento;

        switch (currentModulo.elemento)
        {
            case Elemento.AIRE:
                rozamiento -= bonusAire * rozamiento;
                break;

            case Elemento.AGUA:
                rozamiento -= bonusAgua * rozamiento;
                break;

            case Elemento.TIERRA:
                rozamiento -= bonusTierra * rozamiento;
                break;

            case Elemento.FUEGO:
                rozamiento -= bonusFuego * rozamiento;
                break;

            default:
                break;
        }
      
        //Debug.Log(ID+" rozamiento final"+rozamiento);
        //Debug.Log(ID+" rozamiento en bruto "+currentModulo.rozamiento);
      
        f = rozamiento + ef;

        return f;
    }
    IEnumerator SaliendoCircuito(Vector3 posIni)
    {
        for (int i = 0; i < speedAnimSaliendo; i++)
        {
            transform.position += transform.forward;
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

        CalcularStats(datos.reg);
    }

    public void CalcularStats(Reglajes reg)
    {
        stats = new InfoCoche();

        stats.Marchas = new float[5];
        Calado = new bool[stats.Marchas.Length];
        stats.ElectricForceCurva = 0;
        stats.ElectricForceRecta = 0;
        stats.FinalWeight = statsBase.BaseWeight;
        stats.FinalBrake = statsBase.BaseBrake;
        stats.FinalMaxSpeed = statsBase.BaseMaxSpeed;
        stats.FinalMinSpeed = 20;
        stats.FinalThrottle = statsBase.BaseThrottle;
        signosAnadidos[0].ModificarStats(stats,statsBase,reg.relacionMarchas,reg.espacioDinamica);
        signosAnadidos[1].ModificarStats(stats,statsBase, reg.relacionMarchas, reg.espacioDinamica);
        reg.CalcularReglajes(this);
        CalcularBonus();

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
        RM = reg.relacionMarchas;
        ED = reg.espacioDinamica;
  
    }
    private void CalcularBonus()
    {
        //comprobamos los elementos del coche y de los signos!
        float porcentaje = 0.25f;

        List<Elemento> ele = new List<Elemento>();
        ele.Add(statsBase.elemento);
        ele.Add(signosAnadidos[0].elemento);
        ele.Add(signosAnadidos[1].elemento);

        List<Elemento> fuego = ele.FindAll((E)=>E.Equals(Elemento.FUEGO));
        List<Elemento> tierra = ele.FindAll((E) => E.Equals(Elemento.TIERRA)); 
        List<Elemento> aire = ele.FindAll((E) => E.Equals(Elemento.AIRE)); 
        List<Elemento> agua = ele.FindAll((E) => E.Equals(Elemento.AGUA));

        bonusAgua = agua.Count * 0.25f;
        bonusTierra = tierra.Count * 0.25f;
        bonusAire = aire.Count * 0.25f;
        bonusFuego = fuego.Count * 0.25f;

        if (fuego.Count >= 2)
        {
            if (fuego.Count == 3)
            {
                porcentaje = 0.5f;
                bonusFuego = 0.9f;
            }

            stats.FinalThrottle += stats.FinalThrottle* porcentaje;
        }
        else if (tierra.Count >= 2)
        {
            if (tierra.Count == 3)
            {
                porcentaje = 0.5f;
                bonusTierra = 0.8f;
            }

            stats.FinalMaxSpeed += stats.FinalMaxSpeed* porcentaje;
        }
        else if (aire.Count >= 2)
        {
            if (aire.Count == 3)
            {
                porcentaje = 0.5f;
                bonusAire= 0.8f;
            }

            stats.ElectricForceCurva -= stats.ElectricForceCurva * porcentaje;
            stats.ElectricForceRecta -= stats.ElectricForceRecta * porcentaje;
        }
        else if (agua.Count >= 2)
        {
            if (agua.Count == 3)
            {
                porcentaje = 0.5f;
                bonusAgua = 0.8f;
            }
            bonusAgua += 0.1f;
            bonusAire += porcentaje ;
            bonusFuego += porcentaje;
            bonusTierra += porcentaje ;
          
            if (bonusAire> 0.8)
            {
                bonusAire = 0.8f;
            }
            if (bonusFuego > 0.8)
            {
                bonusFuego = 0.8f;
            }
            if (bonusTierra > 0.8)
            {
                bonusTierra = 0.8f;
            }
            //penalizacion y rozamiento poco! cosas del rozamiento
        }
    }
    #endregion


}
