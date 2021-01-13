using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerTemporada : MonoBehaviour
{
    [HideInInspector]
    public static int numeroMejoras = 3;

    [HideInInspector]
    public int nivelPiloto = 0;

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
    private static int[] nivelMejora = { 0, 0, 0, 0 };
    private string mejora = "";

    public Text circuito1;
    public Text circuito2;
    public Text circuito3;
    public Text circuito4;

    public void Start()
    {

        InformacionPersistente ip = InformacionPersistente.singleton;
        if (ip.esTemporada)
        {
            CambiarMejoras(0, mejorasGraficos1, ip.naveTerricola.infoBase.BaseMaxSpeed.ToString());
            CambiarMejoras(1, mejorasGraficos2, ip.naveTerricola.infoBase.BaseThrottle.ToString());
            CambiarMejoras(2, mejorasGraficos3, ip.naveTerricola.infoBase.BaseBrake.ToString());
            CambiarMejoras(3, mejorasGraficos4, ip.naveTerricola.infoBase.BaseWeight.ToString());
            pantallaElegir.SetActive(false);
            uimanager.SetActive(true);
            ip.escenaActual = "ModoManager";
            for (int i = 0; i < 4; i++)
            {
                if (ip.pilotosOrdenados[0] != null)
                {
                    ParticipantesNameUltima[i].text = ip.pilotosOrdenados[i];
                    if (ip.tiempos.Length != 0)
                        ParticipantesTiemposUltima[i].text = ip.tiempos[i].ToString();


                }
                if (ip.navesModoMan != null)
                {
                    ParticipantesName[i].text = ip.navesModoMan[i].nombre;
                    ParticipantesPuntos[i].text = ip.navesModoMan[i].puntos.ToString();

                }
            }



        }

        circuito1.text = InformacionPersistente.singleton.nombreCircuitoTemporada[0];
        circuito2.text = InformacionPersistente.singleton.nombreCircuitoTemporada[1];
        circuito3.text = InformacionPersistente.singleton.nombreCircuitoTemporada[2];
        circuito4.text = InformacionPersistente.singleton.nombreCircuitoTemporada[3];







        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        mejora = data["ModificarCoche"]["Mejoras"][InformacionPersistente.singleton.idiomaActual].Value;
        if (nivelPiloto == 0)
        {
            nivelPiloto = 1;
            MeterDatosPiloto(15, 0);
        }

        foreach (Text t in mejorasText)
        {
            t.text = numeroMejoras + " " + mejora;
        }
    }

    public void EscogerPiloto(int a)
    {

        if (nivelPiloto == 1 && a != 1)
        {
            if (a == 2 && numeroMejoras > 0)
            {
                numeroMejoras--;
                MeterDatosPiloto(8, 1);
            }

            if (a == 3 && numeroMejoras - 1 > 0)
            {
                numeroMejoras -= 2;
                MeterDatosPiloto(2, 2);
            }
        }

        if (nivelPiloto == 2 && a != 2)
        {
            if (a == 1)
            {
                numeroMejoras++;
                MeterDatosPiloto(15, 0);
            }

            if (a == 3 && numeroMejoras > 0)
            {
                numeroMejoras--;
                MeterDatosPiloto(2, 2);
            }
        }

        if (nivelPiloto == 3 && a != 3)
        {
            if (a == 1)
            {
                numeroMejoras += 2;
                MeterDatosPiloto(15, 0);
            }

            if (a == 2)
            {
                numeroMejoras++;
                MeterDatosPiloto(8, 1);
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

    private void MeterDatosPiloto(int level, int LVL)
    {
        nivelPiloto = LVL + 1;
        Piloto.sprite = pilotoSprite[LVL];
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
                        nivelMejora[tipo - 1]++;
                        ip.naveTerricola.infoBase.BaseMaxSpeed = infoTerricola.BaseMaxSpeed + (nivelMejora[tipo - 1]) * 12.5f;
                        CambiarMejoras(tipo - 1, mejorasGraficos1, ip.naveTerricola.infoBase.BaseMaxSpeed.ToString());

                        ActualizarMejoras(true);
                    }
                    break;

                case 2://Aceleracion
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        nivelMejora[tipo - 1]++;
                        ip.naveTerricola.infoBase.BaseThrottle = infoTerricola.BaseThrottle + (nivelMejora[tipo - 1]) * 1.5f;
                        CambiarMejoras(tipo - 1, mejorasGraficos2, ip.naveTerricola.infoBase.BaseThrottle.ToString());
                        ActualizarMejoras(true);
                    }
                    break;

                case 3://Frenos
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas
                        nivelMejora[tipo - 1]++;
                        ip.naveTerricola.infoBase.BaseBrake = infoTerricola.BaseBrake + (nivelMejora[tipo - 1]) * 5;
                        CambiarMejoras(tipo - 1, mejorasGraficos3, ip.naveTerricola.infoBase.BaseBrake.ToString());

                        ActualizarMejoras(true);
                    }
                    break;

                case 4://Peso
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        nivelMejora[tipo - 1]++;
                        //Estadisticas
                        ip.naveTerricola.infoBase.BaseWeight = infoTerricola.BaseWeight - (nivelMejora[tipo - 1]) * 10;
                        CambiarMejoras(tipo - 1, mejorasGraficos4, ip.naveTerricola.infoBase.BaseWeight.ToString());

                        ActualizarMejoras(true);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    public void CambiarMejoras(int i, GameObject[] graficos, string txt)
    {

        caracteristicasText[i].text = txt;
        if (nivelMejora[i] != 0)
        {
            for (int j = 0; j < nivelMejora[i]; j++)
            {
                graficos[j].SetActive(true);
            }
        }

    }

    public void NoTemporada()
    {
        InformacionPersistente.singleton.nivelRitmoPropio = -1;
    }
}

