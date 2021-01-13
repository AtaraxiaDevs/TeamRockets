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

        int idioma = InformacionPersistente.singleton.idiomaActual;

        seleccionador.onValueChanged.AddListener((value) => CambiarCamara(value));
        //if idioma no se que
        List<string> opciones = new List<string>();

        opciones.Add(MiniTraductor("General", idioma));
        opciones.Add(MiniTraductor("TuPiloto", idioma));
        opciones.Add(MiniTraductor("Piloto", idioma) + " 2");
        opciones.Add(MiniTraductor("Piloto", idioma) + " 3");
        opciones.Add(MiniTraductor("Piloto", idioma) + " 4");

        seleccionador.ClearOptions();
        seleccionador.AddOptions(opciones);
       
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
    public string MiniTraductor(string key, int lang)
    {
        string palabro = "";

        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        palabro = data[InformacionPersistente.singleton.escenaActual][key][lang].Value;

        return palabro;
    }
}
