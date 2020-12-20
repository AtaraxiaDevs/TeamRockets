﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase con un Singleton estatico que contine informacion inmutable entre escenas
public class InformacionPersistente : MonoBehaviour
{
    //Singleton

    public static InformacionPersistente singleton;

    //Informacion

    public DatosCoche[] cochesCarrera;
    public ModeloCoche[] modelosCoches;
    public Signo[] signosZodiaco;
    public int numCoches;

    #region Unity
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        numCoches = modelosCoches.Length;
    }
    #endregion
    #region Gestion de la informacion
    //Método que crea valores aleatorios de un coche. Util para la creacion de coches adversarios en el modo individual
    public DatosCoche GetRandomCoche(int pos)
    {
        DatosCoche res = new DatosCoche();
        res.ID = pos;
        res.info = modelosCoches[Random.Range(0, numCoches)];
        res.reg = new Reglajes();
        res.reg.ElegirReglajes(Random.Range(0, res.reg.numReglajes), Random.Range(0, res.reg.numReglajes));
        res.signos = new Signo[3];
        res.signos[0] = signosZodiaco[Random.Range(0, signosZodiaco.Length)];
        res.signos[1] = signosZodiaco[Random.Range(0, signosZodiaco.Length)];
        res.signos[2] = signosZodiaco[Random.Range(0, signosZodiaco.Length)];
        cochesCarrera[pos] = res;
        return res;


    }
    #endregion





}
