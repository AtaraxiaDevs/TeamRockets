using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerPausa : MonoBehaviour
{
    private string[] RegED= { "RECT","CURV","EQ"};
    private string[] RegRM = { "ACE", "VEL", "EQ" };
    public Sprite[] Signos;
    //public Coche[] pilotos;
    public Image[] Signos1;
    public Image[] Signos2;
    public Text[] RegEDI;
    public Text[] RegRMI;
    public Text[] NombreCoche;
    private int N_COCHES = 4;
    
    public void ActualizarInfo(Coche[] pilotos)
    {
        
        for(int i=0; i < N_COCHES; i++)
        {
            RegEDI[i].text = RegED[(int)pilotos[i].ED];
            RegRMI[i].text = RegRM[(int)pilotos[i].RM];
            Signos1[i].sprite = Signos[(int)pilotos[i].signosAnadidos[0].zodiaco];
            Signos2[i].sprite = Signos[(int)pilotos[i].signosAnadidos[1].zodiaco];

            switch (pilotos[i].statsBase.elemento)
            {
                case Elemento.AGUA:
                    NombreCoche[i].text = "Neptuno" ;
                    break;
                case Elemento.FUEGO:
                    NombreCoche[i].text = "Marte";
                    break;
                case Elemento.TIERRA:
                    NombreCoche[i].text = "Saturno";
                    break;
                case Elemento.AIRE:
                    NombreCoche[i].text = "Jupiter";
                    break;
                default:
                    NombreCoche[i].text = "UFO";
                    break;

            }
           
        }
    }
}
