using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerPausa : MonoBehaviour
{
    public Sprite[] Signos;
    public Image[] Signos1;
    public Image[] Signos2;
    public Text[] RegEDI;
    public Text[] RegRMI;
    public Text[] NombreCoche;
    private int N_COCHES = 4;

    private int idioma;

    public void ActualizarInfo(Coche[] pilotos)
    {
        idioma = InformacionPersistente.singleton.idiomaActual;

        for (int i = 0; i < N_COCHES; i++)
        {
            if(pilotos[i].ED == ESPACIODINAMICA.EQUILIBRADOA)
            {
                RegEDI[i].text = "EQ";
            }
            else
            {
                if(pilotos[i].ED == ESPACIODINAMICA.CURVAS)
                    RegEDI[i].text = MiniTraductor("CURV", idioma);

                if (pilotos[i].ED == ESPACIODINAMICA.RECTAS)
                    RegEDI[i].text = MiniTraductor("RECT", idioma);
            }

            if (pilotos[i].RM == RELACIONMARCHAS.EQUILIBRADORM)
            {
                RegRMI[i].text = "EQ";
            }
            else
            {
                if(pilotos[i].RM == RELACIONMARCHAS.ACELERACION)
                    RegRMI[i].text = MiniTraductor("ACE", idioma);

                if (pilotos[i].RM == RELACIONMARCHAS.VELOCIDAD)
                    RegRMI[i].text = MiniTraductor("VEL", idioma);
            }

            Signos1[i].sprite = Signos[(int)pilotos[i].signosAnadidos[0].zodiaco];
            Signos2[i].sprite = Signos[(int)pilotos[i].signosAnadidos[1].zodiaco];

            switch (pilotos[i].statsBase.elemento)
            {
                case Elemento.AGUA:
                    NombreCoche[i].text = MiniTraductor("Piloto", idioma) + " " + (i + 1) + ":\n" + MiniTraductor("Neptuno", idioma);
                    break;
                case Elemento.FUEGO:
                    NombreCoche[i].text = MiniTraductor("Piloto", idioma) + " " + (i + 1) + ":\n" + MiniTraductor("Marte", idioma);
                    break;
                case Elemento.TIERRA:
                    NombreCoche[i].text = MiniTraductor("Piloto", idioma) + " " + (i + 1) + ":\n" + MiniTraductor("Saturno", idioma);
                    break;
                case Elemento.AIRE:
                    NombreCoche[i].text = MiniTraductor("Piloto", idioma) + " " + (i + 1) + ":\n" + MiniTraductor("Jupiter", idioma);
                    break;
                default:
                    NombreCoche[i].text = MiniTraductor("Piloto", idioma) + " " + (i + 1) + ":\n" + "UFO";
                    break;

            }
           
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
