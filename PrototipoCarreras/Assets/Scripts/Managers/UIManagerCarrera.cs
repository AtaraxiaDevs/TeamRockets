using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerCarrera : MonoBehaviour
{
    public Button startCarrera,stopCarrera;
    public Circuito circuito;
    // Start is called before the first frame update
    void Start()
    {
        startCarrera.onClick.AddListener(() => {
            circuito.IniciarCarrera();
            Time.timeScale = 1;
        });
        stopCarrera.onClick.AddListener(() => Time.timeScale = 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
