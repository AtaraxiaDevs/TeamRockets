using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManagerButtons : MonoBehaviour
{
    private string jsonData = "";
    public string buttKey = "menuPrincipal";
    public Text hola;
    private string buttText = "";
    void Start()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/UI/localization.json");
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);
        buttText = data[InformacionPersistente.singleton.escenaActual][buttKey][InformacionPersistente.singleton.idiomaActual].Value;
        Debug.Log(InformacionPersistente.singleton.idiomaActual);
        hola.text = buttText;
    }

    // Update is called once per frame

}
