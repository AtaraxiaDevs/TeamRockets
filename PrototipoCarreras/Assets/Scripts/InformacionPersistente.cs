using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase con un Singleton estatico que contine informacion inmutable entre escenas
public class DatosCoche
{
    public Reglajes reg;
    public ModeloCoche infoBase;
    public Signo[] signos = new Signo[2];
    public InfoCoche stats;
    public int ID;
    public DatosCoche()
    {
        reg = new Reglajes();
    }
}
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
        cochesCarrera = new DatosCoche[numCoches];
        LimpiarInfoCoches();
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
        for (int i = 0; i < numCoches; i++)
        {
            cochesCarrera[i] = null;
        }
    }
    #endregion


}
