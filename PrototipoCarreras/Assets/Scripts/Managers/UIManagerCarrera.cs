using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerCarrera : MonoBehaviour
{
    public Button startCarrera,stopCarrera;
    public Circuito circuito;
    public Slider minMaxController;
    public Coche myCar;
    private float limitSlide = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startCarrera.onClick.AddListener(() => {
            circuito.IniciarCarrera();
            Time.timeScale = 1;
        });
        stopCarrera.onClick.AddListener(() => Time.timeScale = 0);
        minMaxController.onValueChanged.AddListener((value) => onMinMaxChange(value));
        
    }
    private void onMinMaxChange(float value)
    {
        //value va a estar entre 1 y 0 
        if (value >= limitSlide)
        {
            //0.5 es 0, 1 es finaltrote
            float finalValue = value - limitSlide;
            float porcentaje = finalValue / limitSlide;
            myCar.SetCurrentAccel(porcentaje);

        }
        else
        {

            //0.5 es 0, 0 es finalbrake
           
            float finalValue = limitSlide - value;
            float porcentaje = finalValue / limitSlide;
            myCar.SetCurrentBrake(porcentaje);

        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
