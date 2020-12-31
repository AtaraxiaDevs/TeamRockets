using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManagerButtons : MonoBehaviour
{
    private string jsonData = "", buttText = "";
    public string buttKey = "menuPrincipal";

    public Text hola;

    private int idioma;

    void Start()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/UI/localization.json");
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        idioma = InformacionPersistente.singleton.idiomaActual;

        buttText = data[InformacionPersistente.singleton.escenaActual][buttKey][idioma].Value;
        hola.text = buttText;
    }

    // Update is called once per frame
    private void Update()
    {
        if(idioma != InformacionPersistente.singleton.idiomaActual)
        {
            jsonData = File.ReadAllText(Application.dataPath + "/UI/localization.json");
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);
            idioma = InformacionPersistente.singleton.idiomaActual;
            buttText = data[InformacionPersistente.singleton.escenaActual][buttKey][idioma].Value;
            hola.text = buttText;
        }
    }
}
