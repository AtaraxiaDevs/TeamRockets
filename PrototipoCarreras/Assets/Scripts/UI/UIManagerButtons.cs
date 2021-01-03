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
     
        TextAsset aux = Resources.Load<TextAsset>("localization");
        jsonData = aux.ToString();
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
            
            TextAsset aux = Resources.Load<TextAsset>("localization");
            jsonData = aux.ToString();
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);
            idioma = InformacionPersistente.singleton.idiomaActual;
            buttText = data[InformacionPersistente.singleton.escenaActual][buttKey][idioma].Value;
            hola.text = buttText;
        }
    }
}
