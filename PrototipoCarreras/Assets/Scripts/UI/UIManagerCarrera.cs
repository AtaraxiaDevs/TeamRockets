using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona la UI de la carrera, con botones para empezarla, pararla, e incluso la gestion del minmax ( gestion de la aceleracion del coche del jugador)
public class UIManagerCarrera : MonoBehaviour
{
    //Referencias
    private Circuito circuito;
    private Constructor constructor;
    private CarreraController carrerita;
    [HideInInspector]
    public Coche myCar;
    public List<Coche> coches = new List<Coche>();
    public GameObject MenuPausa;
    public GameObject tuto;
    public bool PartidaRapida;
    //Referencias UI
    public Button startCarrera,stopCarrera,reanudarCarrera;
    public Slider minMaxController;
    public Text velocidad,posiciones, vueltas;
    public Fader sceneFader;

    //PC
    private int marcha;

    //Velocidad

    private float speed = 0;
    private float currentSpeed = 0;
    private bool flagEsperandoCircuito = false;
    //private bool noAccedido = false;
    //Variables
    // private float limitSlide = 0.5f;

    #region Unity
    void Start()
    {
        if (InformacionPersistente.singleton.esTutorial)
        {
            tuto.SetActive(true);
        }

        SoundManager.singleton.EjecutarMusica(MUSICA.CARRERA);
        marcha = 0;
      
        constructor = FindObjectOfType<Constructor>();
        carrerita = FindObjectOfType<CarreraController>();

        //Si no hay un string de hay circuito en el informacionpersitente
        if (InformacionPersistente.singleton.currentCircuito.modulos.Count == 0)
        {

            constructor.ConstruirCircuito();
            Debug.Log("Despues del construir del carreramanager");
            flagEsperandoCircuito = true;
        }
        else
        {
            constructor.DataToCircuito(InformacionPersistente.singleton.currentCircuito);
            constructor.creado.CrearPilotos();
            CircuitoCargado(constructor);
            InformacionPersistente.singleton.currentCircuito = null;
        }
        //CircuitoCargado(c);
       
    }
    public void CircuitoCargado(Constructor c)
    {
        circuito = c.creado;
        coches.AddRange(circuito.pilotos);

        CameraController cc = FindObjectOfType<CameraController>();
        c.CameraFuncionando(cc);
        if (PartidaRapida)
        {
            myCar = circuito.pilotos[0];
            myCar.soyPlayer = true;
            if (minMaxController != null)
            {
                minMaxController.onValueChanged.AddListener((value) => onMinMaxChange(value));
                minMaxController.enabled = false;
            }
        }
        stopCarrera.onClick.AddListener(() => PararCarrera());
        startCarrera.onClick.AddListener(() => { FindObjectOfType<CarreraController>().EmpezarCarrera(); startCarrera.gameObject.SetActive(false); });

    }

    void Update()
    {
        //Camera.main.transform.position = (myCar.transform.position + Vector3.up * 10);

        if (flagEsperandoCircuito)
        {
            if (!InformacionPersistente.singleton.DATA_BD.Equals(""))
            {
                Debug.Log("flag activado");
                constructor.ConstruirCircuitoDesdeBD(InformacionPersistente.singleton.DATA_BD, this);
                InformacionPersistente.singleton.DATA_BD = "";
                flagEsperandoCircuito = false;
            }
        }

        if ((velocidad != null)&&(myCar!=null))
        {
            currentSpeed = myCar.currentSpeed;

            if (Mathf.Abs(currentSpeed - speed) > 2)
            {
                speed = currentSpeed;
                velocidad.text = ((int)Mathf.Round(speed)).ToString();
            }
        }

        if (posiciones != null)
        {
            posiciones.text = PilotosToString();
        }

        if ((!InformacionPersistente.singleton.esMovil)&&(minMaxController!=null)&&(minMaxController.enabled))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (marcha > 0)
                {
                    marcha--;
                    minMaxController.value = marcha;

                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (marcha <4)
                {
                    marcha++;
                    minMaxController.value = marcha;

                }
            }

        }
    }
    #endregion
    #region Gestion de eventos
    private void PararCarrera()
    {
        MenuPausa.SetActive(true);
        MenuPausa.GetComponent<UIManagerPausa>().ActualizarInfo(circuito.pilotos);
        Time.timeScale = 0;
        circuito.PararCarrera(true);
       
    }
    public void ReanudarCarrera()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
        circuito.PararCarrera(false);
 
    }
    private void onMinMaxChange(float value)
    {
        //if (value < marcha && noAccedido)
        //{
        //    noAccedido
        //}
       bool success=  myCar.SetCurrentMarcha((int)value);
        if (!success)
        {
            minMaxController.value = value-1;
        }
        else
        {
            marcha = (int)value;
        }
    }

    #endregion
    #region Metodos auxiliares
    public Coche GetPlayer()
    {
        return circuito.getPlayer();
    }

    public void Comenzar()
    {
        if (myCar == null)
        {
            myCar = GetPlayer();
        }
    }

    public void IrA(string s)
    {
        //si es modo manager, no se hace, pero si es partida rapida y tal:
       
        
        InformacionPersistente.singleton.LimpiarInfoCoches();
        sceneFader.FadeTo(s);
        InformacionPersistente.singleton.escenaActual = s;
    }

    private string PilotosToString()
    {
        int cont = 1;
        
        coches.Sort(new PosicionesCarreraComparator());
        string res = "";

        foreach(Coche c in coches)
        {
            res += cont + "º: " + c.ID + " " + c.statsBase.elemento.ToString() + "\n";
            cont++;
        }
        return res;
    }

    public void SetPosiciones()
    {
        TimeController tc = FindObjectOfType<TimeController>();
        string[] source = new string[4];
        float[] tiempos = new float[4];
        int[] ids = new int[4];
        //int agua = 1, fuego = 1, aire = 1, tierra = 1;
        Posicion[] pos = new Posicion[4];
        float[] tiemposGenerales = tc.tiempoGeneral.ToArray();
        for (int i=0; i < 4; i++)
        {
            pos[i] = new Posicion();
            pos[i].ID = i;
            pos[i].time = tiemposGenerales[i];
            pos[i].doblado = coches.Find((c) => c.ID == pos[i].ID).doblado;
        }

        Array.Sort(pos, (x, y) => {

            if (x.doblado != y.doblado)
            {
                if (x.doblado)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                float aux = x.time - y.time;
                if (aux > 0)
                {
                    return 1;
                }
                else if (aux < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
          
        });

        //  coches.Sort(new PosicionesCarreraComparator());
        Coche[] posicionesFinales = new Coche[4];

        for(int i=0; i < coches.Count; i++)
        {
            posicionesFinales[i] = coches.Find((c) => c.ID.Equals(pos[i].ID));
       
            ids[i] = posicionesFinales[i].ID;
            switch (posicionesFinales[i].statsBase.elemento)
            {
                case Elemento.AGUA:
                    source[i] =   " Neptuno " + posicionesFinales[i].ID;
                  //  agua++;
                    break;

                case Elemento.AIRE:
                    source[i] =   " Jupiter " + posicionesFinales[i].ID;
                   // aire++;
                    break;

                case Elemento.FUEGO:
                    source[i] =  " Marte " + posicionesFinales[i].ID;
                   // fuego++;
                    break;

                case Elemento.TIERRA:
                    source[i] =  " Saturno " + posicionesFinales[i].ID;
                    //tierra++;
                    break;

                default:
                    source[i] =  "UFO ";
                    break;
            }
            
            tiempos[i] = tc.tiempoMejor[posicionesFinales[i].ID];
            
        }

        InformacionPersistente.singleton.pilotosOrdenados = source;
        InformacionPersistente.singleton.tiempos = tiempos;
        InformacionPersistente.singleton.IDsPosiciones = ids;
        IrA("Ranking");
    }
    #endregion
}

public class Posicion
{
    public bool doblado;
    public int ID;
    public float time;
}
