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
    public Button flechaAtras, flechaDelante;
    public Button[] btnSigno;
    public Button[] btnRegED;
    public Button[] btnRegRM;
    public Image cocheDisplay,xdosDisplay,xtresDisplay;
    public Text infoCoche,infoCocheSignos,infosigno1,infosigno2, txtElemento;

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
        InformacionPersistente.singleton.cochesCarrera[currentCoche.ID] = currentCoche;
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
        currentCoche.signos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
        currentCoche.signos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        for (int i=0; i < btnRegED.Length; i++)
        {
            int a = i;
            btnRegED[i].onClick.AddListener(() => ElegirReglajeED(a));
        }
        for (int i = 0; i < btnRegRM.Length; i++)
        {
            int a = i;
            btnRegRM[i].onClick.AddListener(() => ElegirReglajeRM(a));
        }
        UpdateInfoCoche();
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
        currentCoche.signos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        UpdateInfoCoche();
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
        currentCoche.signos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
        UpdateInfoCoche();
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
     
        UpdateInfoCoche();
    }

    private void ElegirReglajeED(int index)
    {
        currentCoche.reg.espacioDinamica = (ESPACIODINAMICA)index;

        for(int i = 0; i < btnRegED.Length; i++)
        {
            //if (i != index)
            //{
            //    btnRegED[i] // cambiar lo suq eno estan seleccionado sy luego el seleccionado
            //}
        }
        UpdateInfoCoche();
    }
    private void ElegirReglajeRM(int index)
    {
        currentCoche.reg.relacionMarchas = (RELACIONMARCHAS)index;
        UpdateInfoCoche();
    }
    //public void EditarCoche()
    //{
    //    currentCoche.signos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
    //    currentCoche.signos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
    //    //currentCoche.reg.ElegirReglajes(RM.value, ED.value);
    //    InformacionPersistente.singleton.cochesCarrera[currentCoche.ID] = currentCoche;
    //}

    #endregion
    #region Modificacion UI
    private void UpdateInfoCoche()
    {
        string [] s = ElTraductor();

        Coche cebo = new Coche();
        cebo.statsBase = currentCoche.infoBase;
        cebo.signosAnadidos = new Signo[2];
        cebo.signosAnadidos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        cebo.signosAnadidos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];

        infosigno1.text = cebo.signosAnadidos[0].zodiaco.ToString();
        infosigno2.text = cebo.signosAnadidos[1].zodiaco.ToString();
        cebo.CalcularStats(currentCoche.reg);

        string[] plus = new string[6];

        for(int i=0; i < plus.Length; i++)
        {
            plus[i] = " ";
            if (cebo.signosAnadidos[0].caracteristicaPlus.Equals((Caracteristicas)i))
            {
                plus[i] += "+";
            }
            else if (cebo.signosAnadidos[0].caracteristicaMinus.Equals((Caracteristicas)i))
            {
                plus[i] += "-";
            }
            if (cebo.signosAnadidos[1].caracteristicaPlus.Equals((Caracteristicas)i))
            {
                plus[i] += "+";
            }
            else if (cebo.signosAnadidos[1].caracteristicaMinus.Equals((Caracteristicas)i))
            {
                plus[i] += "-";
            }
        }

        if (cebo.bonusAgua >= 0.5f)
        {
            if (cebo.bonusAgua > 0.5f)
            {
                xtresDisplay.color = Color.red;
                xdosDisplay.color = Color.white;
            }
            else
            {
                xdosDisplay.color = Color.red;
                xtresDisplay.color = Color.white;
            }
            txtElemento.text = "Auga";
        }
        else if (cebo.bonusFuego >= 0.5f)
        {
            if (cebo.bonusFuego > 0.5f)
            {
                xtresDisplay.color = Color.red;
                xdosDisplay.color = Color.white;
                plus[1] += "++";
            }
            else
            {
                xdosDisplay.color = Color.red;
                xtresDisplay.color = Color.white;
                plus[1] += "+";
            }
            txtElemento.text = "Lume";
        }
        else if (cebo.bonusTierra >= 0.5f)
        {
            if (cebo.bonusTierra > 0.5f)
            {
                xtresDisplay.color = Color.red;
                xdosDisplay.color = Color.white;
                plus[0] += "++";
            }
            else
            {
                xdosDisplay.color = Color.red;
                xtresDisplay.color = Color.white;
                plus[0] += "+";
            }
            txtElemento.text = "Terra";
        }
        else if (cebo.bonusAire >= 0.5f)
        {
            if (cebo.bonusAire > 0.5f)
            {
                xtresDisplay.color = Color.red;
                xdosDisplay.color = Color.white;
                plus[3] += "++";
            }
            else
            {
                xdosDisplay.color = Color.red;
                xtresDisplay.color = Color.white;
                plus[3] += "+";
            }
            txtElemento.text = "Ar";
        }
        else
        {
            xdosDisplay.color = Color.white;
            xtresDisplay.color = Color.white;
        }

        infoCoche.text = s[0] + cebo.stats.FinalMaxSpeed + "\n\n" + s[1] +cebo.stats.FinalThrottle + "\n\n" + s[2] + -cebo.stats.FinalBrake + "\n\n" + s[3] + cebo.stats.FinalWeight+"\n\n" + s[4] + currentCoche.infoBase.elemento.ToString();
        infoCocheSignos.text = s[0] + cebo.stats.FinalMaxSpeed + plus[0] + "\n\n" + s[1] + cebo.stats.FinalThrottle + plus[1] + "\n\n" + s[2] + -cebo.stats.FinalBrake + plus[2] + "\n\n" + s[3] + cebo.stats.FinalWeight + plus[5] + "\n\n" + s[4] + currentCoche.infoBase.elemento.ToString() + "\n\n"+ s[5]+plus[4]+"\n\n"+s[6] +plus[3] ;
    }

    public string [] ElTraductor()
    {
        string[] aux = new string[7];

        string jsonData;
        //if (InformacionPersistente.singleton.esEditor)
        //{
        //    jsonData = File.ReadAllText(Application.dataPath + "/UI/localization.json");
        //}
        //else
        //{
        //    jsonData = File.ReadAllText(Application.dataPath + "localization.json");
        //}
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        int idioma = InformacionPersistente.singleton.idiomaActual;

        aux[0] = data[InformacionPersistente.singleton.escenaActual]["VelocidadMaxima"][idioma].Value+ ": ";
        aux[1] = data[InformacionPersistente.singleton.escenaActual]["Aceleracion"][idioma].Value + ": ";
        aux[2] = data[InformacionPersistente.singleton.escenaActual]["Frenos"][idioma].Value + ": ";
        aux[3] = data[InformacionPersistente.singleton.escenaActual]["Peso"][idioma].Value + ": ";
        aux[4] = data[InformacionPersistente.singleton.escenaActual]["Elemento"][idioma].Value + ": ";
        aux[5] = data[InformacionPersistente.singleton.escenaActual]["RelacionMarchas"][idioma].Value + ": ";
        aux[6] = data[InformacionPersistente.singleton.escenaActual]["EspacioDinamica"][idioma].Value + ": ";

        return aux;
    }
    #endregion


}
