using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona la UI de la carrera, con botones para empezarla, pararla, e incluso la gestion del minmax ( gestion de la aceleracion del coche del jugador)
public class UIManagerCarrera : MonoBehaviour
{
    //Referencias
    public Circuito circuito;
    public Coche myCar;
     public List<Coche> coches= new List<Coche>();
    //Referencias UI
    public Button startCarrera,stopCarrera;
    public Slider minMaxController;
    public Text velocidad,posiciones;
    public Fader sceneFader;
    //PC
    private int marcha;

    //Velocidad

    private float speed=0;
    private float currentSpeed=0;

    //Variables
    // private float limitSlide = 0.5f;

    #region Unity
    void Start()
    {
        if (myCar != null)
        {
            myCar.soyPlayer = true;
        }
        marcha = 0;
        //startCarrera.onClick.AddListener(() => {
        //    circuito.Construir();
        //    circuito.IniciarCarrera();
        //    // Camera.main.transform.position = myCar.transform.position+Vector3.up*2;
        //    // Camera.main.transform.rotation = Quaternion.LookRotation(transform.position - myCar.transform.position, myCar.transform.position);

        //    Time.timeScale = 1;
        //});
        if (circuito!=null)
        {
            coches.AddRange(circuito.pilotos);
            FindObjectOfType<CameraController>().GirarEnCircuito(circuito.transform);
        }
       
        //stopCarrera.onClick.AddListener(() => Time.timeScale = 0);
        if (minMaxController != null)
        {
            minMaxController.onValueChanged.AddListener((value) => onMinMaxChange(value));
        }

        
       
    }
    void Update()
    {
        //Camera.main.transform.position = (myCar.transform.position + Vector3.up * 10);

        if (velocidad != null)
        {
            currentSpeed = myCar.currentSpeed;
            if (Mathf.Abs(currentSpeed - speed) > 1)
            {
                speed = currentSpeed;
                velocidad.text = ((int)Mathf.Round(speed)).ToString();
            }
       

        }
        if (posiciones != null)
        {
            posiciones.text = PilotosToString();

        }
        if (!InformacionPersistente.singleton.esMovil)
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

    private void onMinMaxChange(float value)
    {

       
        myCar.SetCurrentMarcha((int)value);
  
    }

    #endregion
    #region Metodos auxiliares
    public Coche getPlayer()
    {
        return circuito.getPlayer();
    }
    public void Comenzar()
    {
        if (myCar == null)
        {
            myCar = getPlayer();
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
