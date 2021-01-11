using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


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
                             //y offline
        signosEscogidos = new int[2];

        signosEscogidos[0] = 0;
        signosEscogidos[1] = 1;
        eleccionModelo = 0;
        if (InformacionPersistente.singleton.cochesCarrera[0] == null)
        {
            InformacionPersistente.singleton.cochesCarrera[currentCoche.ID] = currentCoche;
          
            
            currentCoche.infoBase = InformacionPersistente.singleton.modelosCoches[eleccionModelo];

            currentCoche.signos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];
            currentCoche.signos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        }
        else
        {
            currentCoche = InformacionPersistente.singleton.cochesCarrera[currentCoche.ID];
            eleccionModelo = Array.FindIndex(InformacionPersistente.singleton.modelosCoches, (m) => m.elemento.Equals(currentCoche.infoBase.elemento));

            signosEscogidos[0] = (int)(currentCoche.signos[0].zodiaco) ;
            signosEscogidos[1] = (int)(currentCoche.signos[1].zodiaco);
            btnSigno[0].image.sprite = fotoSigno[signosEscogidos[0]];
            btnSigno[1].image.sprite = fotoSigno[signosEscogidos[1]];
            btnRegED[(int)currentCoche.reg.espacioDinamica].onClick.Invoke();
            btnRegRM[(int)currentCoche.reg.relacionMarchas].onClick.Invoke();
        }
       
       
       
        flechaAtras.onClick.AddListener(() => CambiarCoche(false));
        flechaDelante.onClick.AddListener(() => CambiarCoche(true));
        btnSigno[0].onClick.AddListener(() => CambiarSigno1());
        btnSigno[1].onClick.AddListener(() => CambiarSigno2());
  

      
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
        cocheDisplay.sprite = fotoCoches[eleccionModelo];
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
        btnRegED[index].image.color = Color.red;
        for (int i = 0; i < btnRegED.Length; i++)
        {
            if (i != index)
            {
                btnRegED[i].image.color = Color.white; // cambiar lo suq eno estan seleccionado sy luego el seleccionado
            }
        }
        UpdateInfoCoche();
    }
    private void ElegirReglajeRM(int index)
    {
        currentCoche.reg.relacionMarchas = (RELACIONMARCHAS)index;
        btnRegRM[index].image.color = Color.red;
        for (int i = 0; i < btnRegED.Length; i++)
        {
            if (i != index)
            {
                btnRegRM[i].image.color = Color.white; // cambiar lo suq eno estan seleccionado sy luego el seleccionado
            }
        }
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
        int idioma = InformacionPersistente.singleton.idiomaActual;

        string [] s = ElTraductor(idioma);

        Coche cebo = new Coche();
        cebo.statsBase = currentCoche.infoBase;
        cebo.signosAnadidos = new Signo[2];
        cebo.signosAnadidos[0] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[0]];
        cebo.signosAnadidos[1] = InformacionPersistente.singleton.signosZodiaco[signosEscogidos[1]];

        infosigno1.text = MiniTraductor(cebo.signosAnadidos[0].zodiaco.ToString(), idioma);
        infosigno2.text = MiniTraductor(cebo.signosAnadidos[1].zodiaco.ToString(), idioma);
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
        List<Elemento> ele = new List<Elemento>();
        ele.Add(cebo.statsBase.elemento);
        ele.Add(cebo.signosAnadidos[0].elemento);
        ele.Add(cebo.signosAnadidos[1].elemento);

        List<Elemento> fuego = ele.FindAll((E) => E.Equals(Elemento.FUEGO));
        List<Elemento> tierra = ele.FindAll((E) => E.Equals(Elemento.TIERRA));
        List<Elemento> aire = ele.FindAll((E) => E.Equals(Elemento.AIRE));
        List<Elemento> agua = ele.FindAll((E) => E.Equals(Elemento.AGUA));

        int bonusAgua = agua.Count;
        int bonusTierra = tierra.Count ;
        int bonusAire = aire.Count ;
        int bonusFuego = fuego.Count ;
        if (bonusAgua >= 2)
        {
            if (bonusAgua > 2)
            {
                xtresDisplay.color = Color.red;
                xdosDisplay.color = Color.white;
            }
            else
            {
                xdosDisplay.color = Color.red;
                xtresDisplay.color = Color.white;
            }
            txtElemento.text = MiniTraductor("AGUA", idioma);
        }
        else if (bonusFuego >=2)
        {
            if (bonusFuego > 2)
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
            txtElemento.text = MiniTraductor("FUEGO", idioma);
        }
        else if (bonusTierra >= 2)
        {
            if (bonusTierra > 2)
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
            txtElemento.text = MiniTraductor("TIERRA", idioma);
        }
        else if (bonusAire >= 2)
        {
            if (bonusAire > 2)
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
            txtElemento.text = MiniTraductor("AIRE", idioma); ;
        }
        else
        {
            xdosDisplay.color = Color.white;
            xtresDisplay.color = Color.white;
        }

        infoCoche.text = s[0] + cebo.stats.FinalMaxSpeed + "\n\n" + s[1] +cebo.stats.FinalThrottle + "\n\n" + s[2] + -cebo.stats.FinalBrake + "\n\n" + s[3] + cebo.stats.FinalWeight+"\n\n" + s[4] + MiniTraductor(currentCoche.infoBase.elemento.ToString(), idioma);
        infoCocheSignos.text = s[0] + cebo.stats.FinalMaxSpeed + plus[0] + "\n\n" + s[1] + cebo.stats.FinalThrottle + plus[1] + "\n\n" + s[2] + -cebo.stats.FinalBrake + plus[2] + "\n\n" + s[3] + cebo.stats.FinalWeight + plus[5] + "\n\n" + s[4] + MiniTraductor(currentCoche.infoBase.elemento.ToString(), idioma) + "\n\n"+ s[5]+plus[4]+"\n\n"+s[6] +plus[3] ;
    }

    public string MiniTraductor(string key, int lang)
    {
        string palabro = "";

        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

        palabro = data[InformacionPersistente.singleton.escenaActual][key][lang].Value;

        return palabro;
    }


    public string [] ElTraductor(int idioma)
    {
        string[] aux = new string[7];

        string jsonData;
        TextAsset auxtxt = Resources.Load<TextAsset>("localization");
        jsonData = auxtxt.ToString();
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonData);

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
