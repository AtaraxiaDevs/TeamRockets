using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionadorCamara : MonoBehaviour
{

    List<Coche> coches= new List<Coche>();
    CameraController camera;
    Constructor constructor;
    public Dropdown seleccionador;
    Circuito circuito;

   
    // Start is called before the first frame update
    void Start()
    { 
        camera = FindObjectOfType<CameraController>();
        constructor = FindObjectOfType<Constructor>();
        seleccionador.onValueChanged.AddListener((value) => CambiarCamara(value));
    }
    public void AddCoches()
    {
        circuito = (FindObjectOfType<Circuito>());
        coches.AddRange(circuito.pilotos);

    }
    private void CambiarCamara(int value)
    {
        if (value == 0)
        {
            constructor.CameraFuncionando(camera);
        }
        else
        {
            camera.ComenzarCarrera(coches[value - 1]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
