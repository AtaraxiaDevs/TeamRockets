﻿using System.Collections;
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
    public GameObject[] mejorasGraficos1;
    public GameObject[] mejorasGraficos2;
    public GameObject[] mejorasGraficos3;
    public GameObject[] mejorasGraficos4;

    private int[] nivelMejora;

    public void Start()
    {
        nivelMejora = new int[4];

        for (int i = 0; i < nivelMejora.Length; i++)
        {
            nivelMejora[i] = 0;
        }

        numeroMejoras = 8;
        nivelPiloto = 1;

        numeroMejoras -= nivelPiloto;

        ActualizarMejoras(true);
    }

    public void EscogerPiloto(int a)
    {
        if (nivelPiloto == 1 && a != 1)
        {
            numeroMejoras -= a;
        }

        if (nivelPiloto == 2 && a != 2)
        {
            if (a == 1)
                numeroMejoras++;
            if (a == 3)
                numeroMejoras--;
        }

        if (nivelPiloto == 3 && a != 3)
        {
            numeroMejoras += a;
        }

        nivelPiloto = a;
        Piloto.sprite = pilotoSprite[a - 1];
        InformacionPersistente.singleton.nivelRitmoPropio = a;

        foreach (Text t in mejorasText)
        {
            t.text = numeroMejoras + " MEJORAS";
        }
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
            t.text = numeroMejoras + " MEJORAS";
        }
    }

    public void AplicarMejora(int tipo)
    {
        if (numeroMejoras > 0)
        {
            switch (tipo)
            {
                case 1:
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas

                        CambiarMejoras(tipo - 1, mejorasGraficos1);

                        ActualizarMejoras(true);
                    }
                    break;

                case 2:
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas

                        CambiarMejoras(tipo - 1, mejorasGraficos2);

                        ActualizarMejoras(true);
                    }
                    break;

                case 3:
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas

                        CambiarMejoras(tipo - 1, mejorasGraficos3);

                        ActualizarMejoras(true);
                    }
                    break;

                case 4:
                    if (nivelMejora[tipo - 1] < 3)
                    {
                        //Estadisticas

                        CambiarMejoras(tipo - 1, mejorasGraficos4);

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

