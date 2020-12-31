using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


//Gestion de la UI para la seleccion de los reglajes del coche, además del modelo y el zodiaco

public class UIManagerEscogerCoche : MonoBehaviour
{
    //Referencias
    public Sprite[] fotoCoches;
    public Sprite[] fotoSigno;
    //UI Referencias
    public Button flechaAtras, flechaDelante, btnListo;
    public Button[] btnSigno;
    public Image cocheDisplay;
    public Text infoCoche;
    public int[] signosEscogidos;
    public int RM, ED;

    //Info
    public DatosCoche currentCoche;
    private int eleccionModelo;

    #region Unity
    void Start()
    {
        currentCoche = new DatosCoche();
        currentCoche.ID = 0; // Va a ser el Jugador 1 por ahora

        eleccionModelo = 0;
        cocheDisplay.sprite = fotoCoches[eleccionModelo];
        currentCoche.infoBase = InformacionPersistente.singleton.modelosCoches[eleccionModelo];
        flechaAtras.onClick.AddListener(() => CambiarCoche(false));
        flechaDelante.onClick.AddListener(() => CambiarCoche(true));
        //btnListo.onClick.AddListener(() => EditarCoche());
        btnSigno[0].onClick.AddListener(() => CambiarSigno1());
        btnSigno[1].onClick.AddListener(() => CambiarSigno2());
        //RM.onValueChanged.AddListener((b) => UpdateInfoCoche(b));
        //ED.onValueChanged.AddListener((b) => UpdateInfoCoche(b));

        signosEscogidos = new int[2];
        signosEscogidos[0] = 0;
        signosEscogidos[1] = 1;
        UpdateInfoCoche(0);
    }
    #endregion
    #region Modificacion Coche
    private void CambiarSigno1()
    {
        signosEscogidos[0]++;
     
        if (signosEscogidos[0] >= 12)
        {
            signosEscogidos[0] = 0;
        } 
        
        if(signosEscogidos[0]== signosEscogidos[1])
        {
            signosEscogidos[0]++;
        }

        if (signosEscogidos[0] >= 12)
        {
            signosEscogidos[0] = 0;
        }

        btnSigno[0].image.sprite = fotoSigno[signosEscogidos[0]];
        UpdateInfoCoche(0);
    }
    private void CambiarSigno2()
    {
        signosEscogidos[1]++;
      
        if (signosEscogidos[1] >= 12)
        {
            signosEscogidos[1] = 0;
        } 

        if (signosEscogidos[0] == signosEscogidos[1])
        {
            signosEscogidos[1]++;
        }

        if (signosEscogidos[1] >= 12)
        {
            signosEscogidos[1] = 0;
        }

        btnSigno[1].image.sprite = fotoSigno[signosEscogidos[1]];
        UpdateInfoCoche(0);
    }
    private void CambiarCoche(bool avanzar)
    {
        if (avanzar)
        {
            eleccionModelo++;

            if (eleccionModelo == InformacionPersistente.singleton.numCoches)
            {
                eleccionModelo = 0;
            }
        }
        else
        {
            eleccionModelo--;

            if (eleccionModelo < 0)
            {
                eleccionModelo = InformacionPersistente.singleton.numCoches - 1;
            }
        }

        cocheDisplay.sprite = fotoCoches[eleccionModelo];

        currentCoche.infoBase = InformacionPersistente.singleton.modelosCoches[eleccionModelo];
     
        UpdateInfoCoche(0);
    }

    public void EditarCoche()
    {
        currentCoche.signos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        currentCoche.signos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
        //currentCoche.reg.ElegirReglajes(RM.value, ED.value);
        InformacionPersistente.singleton.cochesCarrera[currentCoche.ID] = currentCoche;
    }

    #endregion
    #region Modificacion UI
    private void UpdateInfoCoche(int b)
    {
        string [] s = ElTraductor();

        Coche cebo = new Coche();
        cebo.statsBase = currentCoche.infoBase;
        cebo.signosAnadidos = new Signo[2];
        cebo.signosAnadidos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        cebo.signosAnadidos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
        Reglajes reg = new Reglajes();
        //reg.ElegirReglajes(RM.value, ED.value);
        cebo.CalcularStats(reg);

        infoCoche.text = s[0] + cebo.stats.FinalMaxSpeed + "\n\n" + s[1] +cebo.stats.FinalThrottle + "\n\n" + s[2] + cebo.stats.FinalBrake + "\n\n" + s[3] + currentCoche.infoBase.BaseWeight+"\n\n" + s[4] + currentCoche.infoBase.elemento.ToString();
    }

    public string [] ElTraductor()
    {
        string[] aux = new string[5];

        string jsonData = File.ReadAllText(Application.dataPath + "/UI/localization.json");
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        int idioma = InformacionPersistente.singleton.idiomaActual;

        aux[0] = data[InformacionPersistente.singleton.escenaActual]["VelocidadMaxima"][idioma].Value;
        aux[1] = data[InformacionPersistente.singleton.escenaActual]["Aceleracion"][idioma].Value;
        aux[2] = data[InformacionPersistente.singleton.escenaActual]["Frenos"][idioma].Value;
        aux[3] = data[InformacionPersistente.singleton.escenaActual]["Peso"][idioma].Value;
        aux[4] = data[InformacionPersistente.singleton.escenaActual]["Elemento"][idioma].Value;

        return aux;
    }
    #endregion


}
