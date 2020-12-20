using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Gestion de la UI para la seleccion de los reglajes del coche, además del modelo y el zodiaco
public class DatosCoche{
    public Reglajes reg;
    public ModeloCoche info;
    public Signo[] signos;
    public int ID;
}
public class UIManagerEscogerCoche : MonoBehaviour
{
    //Referencias
    public Sprite[] fotoCoches;
    //UI Referencias
    public Button flechaAtras, flechaDelante, btnListo;
    public Image cocheDisplay;
    public Dropdown RM;
    public Dropdown ED;
    public Text infoCoche;

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
        currentCoche.info = InformacionPersistente.singleton.modelosCoches[eleccionModelo];
        flechaAtras.onClick.AddListener(() => CambiarCoche(false));
        flechaDelante.onClick.AddListener(() => CambiarCoche(true));
        btnListo.onClick.AddListener(() => EditarCoche());
        UpdateInfoCoche();

    }
    #endregion
    #region Modificacion Coche
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

        currentCoche.info = InformacionPersistente.singleton.modelosCoches[eleccionModelo];
        UpdateInfoCoche();

    }
    public void EditarCoche()
    {
        currentCoche.reg.ElegirReglajes(RM.value, ED.value);
        InformacionPersistente.singleton.cochesCarrera[currentCoche.ID] = currentCoche;
    }

    #endregion
    #region Modificacion UI
    private void UpdateInfoCoche()
    {
        infoCoche.text = "Velocidad Maxima: " + currentCoche.info.BaseMaxSpeed + "\n\nAceleracion: " + currentCoche.info.BaseThrottle + "\n\nFrenos: " + currentCoche.info.BaseBrake + "\n\nPeso: " + currentCoche.info.BaseWeight;
    }
    #endregion


}
