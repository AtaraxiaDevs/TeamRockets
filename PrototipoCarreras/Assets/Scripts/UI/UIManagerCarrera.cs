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
    [HideInInspector]
    public Coche myCar;
    public List<Coche> coches = new List<Coche>();
    public bool PartidaRapida;
    //Referencias UI
    public Button startCarrera,stopCarrera,reanudarCarrera;
    public Slider minMaxController;
    public Text velocidad,posiciones;
    public Fader sceneFader;

    //PC
    private int marcha;

    //Velocidad

    private float speed = 0;
    private float currentSpeed = 0;
    private bool flagEsperandoCircuito = false;
    //Variables
    // private float limitSlide = 0.5f;

    #region Unity
    void Start()
    {
        SoundManager.singleton.EjecutarMusica(MUSICA.CARRERA);
        marcha = 0;
      
        constructor = FindObjectOfType<Constructor>();
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
        startCarrera.onClick.AddListener(() => { FindObjectOfType<CarreraController>().EmpezarCarrera(); startCarrera.gameObject.SetActive(false); }); ;


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
        Time.timeScale = 0;
        circuito.PararCarrera(true);
        stopCarrera.onClick.RemoveAllListeners();
        stopCarrera.onClick.AddListener(() => ReanudarCarrera());
    }
    private void ReanudarCarrera()
    {
        Time.timeScale = 1;
        circuito.PararCarrera(false);
        stopCarrera.onClick.RemoveAllListeners();
        stopCarrera.onClick.AddListener(() => PararCarrera());
    }
    private void onMinMaxChange(float value)
    {
        myCar.SetCurrentMarcha((int)value);
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
        int agua = 1, fuego = 1, aire = 1, tierra = 1;
        coches.Sort(new PosicionesCarreraComparator());

        for(int i=0; i < coches.Count; i++)
        {
            switch (coches[i].statsBase.elemento)
            {
                case Elemento.AGUA:
                    source[i] = "ID: "+ coches[i].ID+ " Neptuno " + agua;
                    agua++;
                    break;

                case Elemento.AIRE:
                    source[i] = "ID: " + coches[i].ID + " Jupiter " + aire;
                    aire++;
                    break;

                case Elemento.FUEGO:
                    source[i] = "ID: " + coches[i].ID + " Marte " + fuego;
                    fuego++;
                    break;

                case Elemento.TIERRA:
                    source[i] = "ID: " + coches[i].ID + " Saturno " + tierra;
                    tierra++;
                    break;

                default:
                    source[i] = i + "º " + "UFO ";
                    break;
            }

            tiempos[i] = tc.tiempoMejor[coches[i].ID];
        }

        InformacionPersistente.singleton.pilotosOrdenados = source;
        InformacionPersistente.singleton.tiempos = tiempos;
        IrA("Ranking");
    }
    #endregion
}
