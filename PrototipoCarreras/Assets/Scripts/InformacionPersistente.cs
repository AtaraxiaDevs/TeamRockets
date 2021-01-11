﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



//Clase con un Singleton estatico que contine informacion inmutable entre escenas
public class DatosCoche
{
    public Reglajes reg;
    public ModeloCoche infoBase;
    public Signo[] signos = new Signo[2];
    //public InfoCoche stats;
    public int ID;

    public DatosCoche()
    {
        reg = new Reglajes();
    }
    
}
public class InformacionPersistente : MonoBehaviour
{
    //Es Movil
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    //Singleton
    public static InformacionPersistente singleton;

    //Ranking
    public string[] pilotosOrdenados;
    public int[] IDsPosiciones;
    public float[] tiempos;

    //Informacion
    public DatosCoche[] cochesCarrera;
    //public DatosCoche[] cochesManager;
    // quizas hacer un datoscoche con los del modo manager?¿
    public List<Participante> navesModoMan;
    public List<Participante> navesModoCopa;
    public ModeloCoche[] modelosCoches;
  
    public Signo[] signosZodiaco;

    public int numCoches, nivelRitmoPropio = -1;
    public int idiomaActual = 2;
    public string escenaActual = "MainMenu";

    public bool esMovil, esEditor, esTutorial = false, esTemporada = false, esCopa = false,copaTerminada=false,temporadaTerminada=false;
    public string nombreUsuario = "Celtia";
    public string DATA_BD = "";
    [HideInInspector]
    public DataCircuito currentCircuito = null;
    [HideInInspector]
    public DataCircuito[] modoCopa = new DataCircuito[4];
    [HideInInspector]
    public DataCircuito[] modoManager = new DataCircuito[4];
    [HideInInspector]
    public int contCircuitoManager = 0, contCircuitoCopa = 0;

    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
        #endif
            return false;
    }
    public bool isEditor()
    {
        #if UNITY_EDITOR
            return true;
        #endif
            return false;
    }
    #region Unity
    private void Awake()
    {
        esMovil = isMobile();
        esEditor = isEditor();
        pilotosOrdenados = new string[4];

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
        cochesCarrera = new DatosCoche[numCoches];
        LimpiarInfoCoches();

        //int a = 0, b = 0;
        //for (int i = 0; i < cochesCarrera.Length; i++)
        //{
        //    cochesCarrera[i] = new DatosCoche();
        //    cochesCarrera[i].infoBase = modelosCoches[2];
        //    cochesCarrera[i].signos[0] = signosZodiaco[10];
        //    cochesCarrera[i].signos[1] = signosZodiaco[11];
        //    cochesCarrera[i].ID = i;
        //    cochesCarrera[i].reg = new Reglajes();
        //    cochesCarrera[i].reg.ElegirReglajes(a, b);

        //    if (i % 2 != 0)
        //    {
        //        b++;
        //        a--;
        //    }
        //    else
        //    {
        //        a++;
        //    }
        //}
    }
    #endregion
    #region Gestion de la informacion
    //Método que crea valores aleatorios de un coche. Util para la creacion de coches adversarios en el modo individual
    public DatosCoche GetRandomCoche(int pos)
    {
        DatosCoche res = new DatosCoche();
        res.ID = pos;
        res.infoBase = modelosCoches[Random.Range(0, numCoches)];
        res.reg = new Reglajes();
        res.reg.ElegirReglajes(Random.Range(0, res.reg.numReglajes), Random.Range(0, res.reg.numReglajes));

        res.signos = new Signo[2];
        int randomSigno1 = Random.Range(0, signosZodiaco.Length);
        int randomSigno2 = Random.Range(0, signosZodiaco.Length);

        if (randomSigno1 == randomSigno2)
        {
            randomSigno2++;
            if (randomSigno2 > signosZodiaco.Length - 1)
            {
                randomSigno2 = 0;
            }
        }
        
        res.signos[0] = signosZodiaco[randomSigno1];
        res.signos[1] = signosZodiaco[randomSigno2];

        cochesCarrera[pos] = res;
        return res;
    }
   

    public void LimpiarInfoCoches()
    {
        if (!esCopa)
        {
            if (esTemporada)
            {
                if (contCircuitoManager < 3)
                {
                    contCircuitoManager++;
                    currentCircuito = modoManager[contCircuitoManager];
                }
                else
                {
                    temporadaTerminada = true;
                }
            }
            else
            {
              
                for (int i = 0; i < numCoches; i++)
                {
                    cochesCarrera[i] = null;
                    
                }
            }
        }
        else
        {
           
            
                if (contCircuitoCopa < 3)
                {
                    contCircuitoCopa++;
                    currentCircuito = modoCopa[contCircuitoCopa];
                }
                else
                {
                    copaTerminada = true;
                }
            
        }
      
    }
    #endregion


}
