using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparadorParticipantes : Comparer<Participante>
{
    public override int Compare(Participante x, Participante y)
    {
        return y.puntos - x.puntos;
    }
}
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
        InformacionPersistente ip = InformacionPersistente.singleton;
        if (ip.esTemporada)
        {
        
            if (ip.navesModoMan == null)
            {
                
                listaParticipantes = new List<Participante>();
                for (int i = 0; i < 4; i++)
                {
                    listaParticipantes.Add(new Participante(ip.pilotosOrdenados[i]));

                    listaParticipantes[i].ID = ip.IDsPosiciones[i];
           
                }

                listaParticipantes[0].SetPuntos(5);
                listaParticipantes[1].SetPuntos(3);
                listaParticipantes[2].SetPuntos(1);
                ip.navesModoMan = listaParticipantes;

                if (listaParticipantes[0].ID == 0)
                {
                    UIManagerTemporada.numeroMejoras += 0;
                }
                else if (listaParticipantes[1].ID == 0)
                {
                    UIManagerTemporada.numeroMejoras += 1;
                }
                else if ((listaParticipantes[2].ID==0))
                {
                    UIManagerTemporada.numeroMejoras += 2;
                }
                else
                {
                    UIManagerTemporada.numeroMejoras += 3;
                }

            }
            else
            {
                listaParticipantes = ip.navesModoMan;
                Participante primero= listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[0]));
                primero.SetPuntos(5);
              
                Participante segundo = listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[1]));
                segundo.SetPuntos(3);
               
                Participante tercero = listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[2]));
                tercero.SetPuntos(1);
               
                ip.navesModoMan.Sort(new ComparadorParticipantes());
                if (primero.ID == 0)
                {
                    UIManagerTemporada.numeroMejoras += 0;
                }
                else if (segundo.ID == 0)
                {
                    UIManagerTemporada.numeroMejoras += 1;
                }
               else  if ((tercero.ID == 0))
                {
                    UIManagerTemporada.numeroMejoras += 2;
                }
                else
                {
                    UIManagerTemporada.numeroMejoras += 3;
                }
            }
            for(int i = 0; i < 4; i++)
            {
                puntos[Array.FindIndex(ip.pilotosOrdenados,(p)=>p.Equals(listaParticipantes[i].nombre))].text = listaParticipantes[i].puntos.ToString();

            }
                
        }
            else if (ip.esCopa)
        {
           
                if (ip.navesModoCopa == null)
                {

                    listaParticipantes = new List<Participante>();
                    for (int i = 0; i < 4; i++)
                    {
                        listaParticipantes.Add(new Participante(ip.pilotosOrdenados[i]));

                        listaParticipantes[i].ID = ip.IDsPosiciones[i];



                    }
                    listaParticipantes[0].SetPuntos(5);
                    listaParticipantes[1].SetPuntos(3);
                    listaParticipantes[2].SetPuntos(1);
                    ip.navesModoCopa = listaParticipantes;


                }
                else
                {
                    listaParticipantes = ip.navesModoCopa;
                    listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[0])).SetPuntos(5);
                    listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[1])).SetPuntos(3);
                    listaParticipantes.Find((p) => p.nombre.Equals(ip.pilotosOrdenados[2])).SetPuntos(1);
                    ip.navesModoCopa.Sort(new ComparadorParticipantes());
                }
                for (int i = 0; i < 4; i++)
                {
                    puntos[Array.FindIndex(ip.pilotosOrdenados, (p) => p.Equals(listaParticipantes[i].nombre))].text = listaParticipantes[i].puntos.ToString();
                }

            }
        }
       
    
    public void SalirRanking()
    {
        UIManagerMenus ui = FindObjectOfType<UIManagerMenus>();
        InformacionPersistente ip = InformacionPersistente.singleton;
        if (ip.esTemporada)
        { 
        
            if (ip.temporadaTerminada)
            {

                UIManagerTemporada.numeroMejoras = 3;
                ip.temporadaTerminada = false; 
                ip.LimpiarInfoCoches();
                for(int i=0; i<4; i++)
                {
                    ip.modoManager[i] = null;
                   
                }
                ip.navesModoMan = null;
                ip.currentCircuito = null;
                ip.contCircuitoManager = 0;
                ui.IrA("Resultados");
            }
            else
            {
                ui.IrA("ModoTemporada");
            }
        }
        else if (ip.esCopa){
               
             
              
            if (ip.copaTerminada)
            {
            
                ip.copaTerminada = false;  
                ip.LimpiarInfoCoches();
                for (int i = 0; i < 4; i++)
                {
                    ip.modoCopa[i] = null;

                }
                ip.contCircuitoCopa = 0;
                ip.currentCircuito = null;
                ui.IrA("Resultados");
            }
            else
            {
                InformacionPersistente.singleton.copaComenzada = true;
                ui.IrA("CocheReglaje");

            }
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
    public int ID;
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
