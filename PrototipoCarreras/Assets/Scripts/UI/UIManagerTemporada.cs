using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerTemporada : MonoBehaviour
{
    private int numeroMejoras;

    [HideInInspector]
    public int nivelPiloto;

    public Image Piloto;
    public Sprite[] pilotoSprite;

    public Text[] mejorasText;
    public Text[] caracteristicasText;
    public GameObject[] mejorasGraficos1;
    public GameObject[] mejorasGraficos2;
    public GameObject[] mejorasGraficos3;
    public GameObject[] mejorasGraficos4;
    public GameObject pantallaElegir, uimanager;
    public Text[] ParticipantesName;
    public Text[] ParticipantesPuntos;
    public Text[] ParticipantesNameUltima;
    public Text[] ParticipantesTiemposUltima;
    private static int[] nivelMejora= { 0, 0, 0, 0 };
    private string mejora = "";

    public void Start()
    {
 
        InformacionPersistente ip = InformacionPersistente.singleton;
        if (ip.esTemporada)
        {
            for(int i=0; i < 4; i++)
            {
                AplicarMejora(i);
            }
            pantallaElegir.SetActive(false);
            uimanager.SetActive(true);
            ip.escenaActual = "ModoManager";
            for (int i = 0; i < 4; i++)
            {
                if (ip.pilotosOrdenados[0] != null)
                {
                    ParticipantesNameUltima[i].text = ip.pilotosOrdenados[i];
                    if(ip.tiempos.Length!=0)
                        ParticipantesTiemposUltima[i].text = ip.tiempos[i].ToString();
                   

                }
                if (ip.navesModoMan != null)
                {
                    ParticipantesName[i].text = ip.navesModoMan[i].nombre;
                    ParticipantesPuntos[i].text = ip.navesModoMan[i].puntos.ToString();

                }
            }
        
            

        }
       
       
        nivelMejora = new int[4];

        for (int i = 0; i < nivelMejora.Length; i++)
        {
            nivelMejora[i] = 0;
        }

        numeroMejoras = 8;
        nivelPiloto = 1;

        numeroMejoras -= nivelPiloto;
        
        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        mejora = data["ModificarCoche"]["Mejoras"][InformacionPersistente.singleton.idiomaActual].Value;

        ActualizarMejoras(true);
    }

    public void EscogerPiloto(int a)
    {
        if (nivelPiloto == 1 && a != 1)
        {
            if (a == 2 && numeroMejoras > 0)
            {
                numeroMejoras--;
                MeterDatosPiloto(a);
            }

            if (a == 3 && numeroMejoras - 1 > 0)
            {
                numeroMejoras -= 2;
                MeterDatosPiloto(a);
            }
        }

        if (nivelPiloto == 2 && a != 2)
        {
            if (a == 1)
            {
                numeroMejoras++;
                MeterDatosPiloto(a);
            }

            if (a == 3 && numeroMejoras > 0)
            {
                numeroMejoras--;
                MeterDatosPiloto(a);
            }
        }

        if (nivelPiloto == 3 && a != 3)
        {
            if (a == 1)
            {
                numeroMejoras += 2;
                MeterDatosPiloto(a);
            }

            if (a == 2)
            {
                numeroMejoras++;
                MeterDatosPiloto(a);
            }
        }

        if (numeroMejoras >= 0)
        {
            foreach (Text t in mejorasText)
            {
                t.text = numeroMejoras + " " + mejora;
            }
        }  
    }

    private void MeterDatosPiloto(int level)
    {
        nivelPiloto = level;
        Piloto.sprite = pilotoSprite[level - 1];
        InformacionPersistente.singleton.nivelRitmoPropio = level;
    }

    public void ActualizarMejoras(bool esMas)
    {
        if (esMas)
        {
            numeroMejoras--;
        }
        else
        {
            numeroMejoras++;
        }

        foreach (Text t in mejorasText)
        {
            t.text = numeroMejoras + " " + mejora;
        }
    }

    public void AplicarMejora(int tipo)
    {
        InformacionPersistente ip = InformacionPersistente.singleton;
        ModeloCoche infoTerricola = ip.modelosCoches[(int)Elemento.ESPIRITU];
        if (numeroMejoras > 0)
        {
            switch (tipo)
            {
                case 1://Velocidad
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        ip.naveTerricola.infoBase.BaseMaxSpeed = infoTerricola.BaseMaxSpeed + nivelMejora[tipo - 1] * 20;
                        CambiarMejoras(tipo - 1, mejorasGraficos1);
                        caracteristicasText[0].text = ip.naveTerricola.infoBase.BaseMaxSpeed.ToString();
                        ActualizarMejoras(true);
                    }
                    break;

                case 2://Aceleracion
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        ip.naveTerricola.infoBase.BaseThrottle = infoTerricola.BaseThrottle + nivelMejora[tipo - 1] * 2;
                        CambiarMejoras(tipo - 1, mejorasGraficos2);
                        caracteristicasText[1].text = ip.naveTerricola.infoBase.BaseThrottle.ToString();
                        ActualizarMejoras(true);
                    }
                    break;

                case 3://Frenos
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        ip.naveTerricola.infoBase.BaseBrake = infoTerricola.BaseBrake - nivelMejora[tipo - 1] * 5;
                        CambiarMejoras(tipo - 1, mejorasGraficos3);
                        caracteristicasText[2].text = ip.naveTerricola.infoBase.BaseBrake.ToString();
                        ActualizarMejoras(true);
                    }
                    break;

                case 4://Peso
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        ip.naveTerricola.infoBase.BaseWeight = infoTerricola.BaseWeight - nivelMejora[tipo - 1] * 10;
                        CambiarMejoras(tipo - 1, mejorasGraficos4);
                        caracteristicasText[3].text = ip.naveTerricola.infoBase.BaseWeight.ToString();
                        ActualizarMejoras(true);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    public void CambiarMejoras(int t, GameObject[] graficos)
    {
        nivelMejora[t]++;

        graficos[nivelMejora[t] - 1].SetActive(true);
    }

    public void NoTemporada()
    {
        InformacionPersistente.singleton.nivelRitmoPropio = -1;
    }
}

