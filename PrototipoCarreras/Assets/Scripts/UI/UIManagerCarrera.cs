using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerCarrera : MonoBehaviour
{
    //References
    public Circuito circuito;
    public Coche myCar;

    //UI
    public Button startCarrera,stopCarrera;
    public Slider minMaxController;
    public Text velocidad;

    private float limitSlide = 0.5f;
    
    void Start()
    {
        myCar.soyPlayer = true;

        startCarrera.onClick.AddListener(() => {
            circuito.IniciarCarrera();
            Camera.main.transform.position = myCar.transform.position+Vector3.up*2;
           // Camera.main.transform.rotation = Quaternion.LookRotation(transform.position - myCar.transform.position, myCar.transform.position);
            
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
        Camera.main.transform.position = (myCar.transform.position + Vector3.up * 10);

        velocidad.text = myCar.currentSpeed.ToString();
    }
}
