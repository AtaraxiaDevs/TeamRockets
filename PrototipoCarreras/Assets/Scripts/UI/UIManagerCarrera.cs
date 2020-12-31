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
    

    //Variables
   // private float limitSlide = 0.5f;

    #region Unity
    void Start()
    {
        if (myCar != null)
        {
            myCar.soyPlayer = true;
        }

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
            velocidad.text = (Mathf.Round(myCar.currentSpeed)).ToString();

        }
        if (posiciones != null)
        {
            posiciones.text = PilotosToString();

        }
    }
    #endregion
    #region Gestion de eventos

    private void onMinMaxChange(float value)
    {

        ////value va a estar entre 1 y 0 
        //if (value >= limitSlide)
        //{
        //    //0.5 es 0, 1 es finaltrote
        //    float finalValue = value - limitSlide;
        //    float porcentaje = finalValue / limitSlide;
        //    myCar.SetCurrentAccel(porcentaje);
        //}
        //else
        //{
        //    //0.5 es 0, 0 es finalbrake
        //    float finalValue = limitSlide - value;
        //    float porcentaje = finalValue / limitSlide;
        //    myCar.SetCurrentBrake(porcentaje);
        //}
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
    #endregion
}
