using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    //Aquí se gestionará el ranking

    //Auxiliar, borrar luego

    public const int N_PLAYERS = 4;
    public string [] nombres;
    public Text[] puntos;

    //References



    //Variables

    public List <Participante> listaParticipantes;

    private void Start()
    {
        if (InformacionPersistente.singleton.esTemporada)
        {
            InformacionPersistente ip = InformacionPersistente.singleton;
            if (ip.navesModoMan == null)
            {
                listaParticipantes = new List<Participante>();
                for (int i = 0; i < 4; i++)
                {
                    listaParticipantes.Add(new Participante(ip.pilotosOrdenados[i]));
                  
                  


                }
                listaParticipantes[0].SetPuntos(5);
                listaParticipantes[1].SetPuntos(3);
                listaParticipantes[2].SetPuntos(1);
                ip.navesModoMan = listaParticipantes;


            }
            else
            {
                listaParticipantes = ip.navesModoMan;
                listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[0])).SetPuntos(5);
                listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[1])).SetPuntos(3);
                listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[2])).SetPuntos(1);
            }
            for(int i=0;i<4;i++)
            puntos[Array.IndexOf(ip.pilotosOrdenados, listaParticipantes[i])].text = listaParticipantes[i].puntos.ToString();
        }
            
       
    }
    public void SalirRanking()
    {
        UIManagerMenus ui = FindObjectOfType<UIManagerMenus>();
        if (InformacionPersistente.singleton.esTemporada)
        {
            ui.IrA("ModoTemporada");
        }
        else if (InformacionPersistente.singleton.esCopa){
            if(InformacionPersistente.singleton.copaTerminada)
                ui.IrA("ModosJuegos");
            else
                ui.IrA("CarreraRápida");
        }
        else
        {
            ui.IrA("ModosJuegos");
        }
    }
}

public class Participante
{
    public string nombre;
    public int puntos;
    
    public Participante(string s)
    {
        nombre = s;
        puntos = 0;
    }

    public void SetPuntos(int i)
    {
        puntos += i;
    }
}
