﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManagerMenus : MonoBehaviour
{
    public Fader sceneFader;

    public GameObject tutorial;
    [Header("Panel Principal")]
    public GameObject PPrincipal;

    [Header("Tutoriales")]
    public GameObject tutoMovil;
    public GameObject tutoPC;

    [Header("Pestañas")]
    public GameObject pestanaActual;
    public GameObject pestanaActualClas;

    [Header("Titulo")]
    public bool esTitulo;
    public Image titulo;
    public Sprite spriteEspañol;
    public Sprite spriteIngles;
    public Sprite spriteGallego;

    [Header("OtroTitulo")]
    public bool esTitulo2;
    public Image titulo2;
    public Sprite spriteEspañol2;
    public Sprite spriteIngles2;
    public Sprite spriteGallego2;
    [Header("Es Carrera?")]
    public bool esCarrera= false;
    //ModoTemporada
    [HideInInspector]
    public bool circuitosListos = false;
    private void Start()
    {
        if(!esCarrera)
            SoundManager.singleton.EjecutarMusica(MUSICA.MENU);

        if ((InformacionPersistente.singleton.esTutorial) && tutorial != null)
        {
            tutorial.SetActive(true);
        }

        foreach(Button b in Resources.FindObjectsOfTypeAll<Button>())
        {
            b.onClick.AddListener(()=>SoundManager.singleton.EjecutarSonido(SONIDO.BOTON1));
        }
    }
    private void Update()
    {
        if (esTitulo)
        {
            if(InformacionPersistente.singleton.idiomaActual == 0)
            {
                titulo.sprite = spriteEspañol;

                if (esTitulo2)
                {
                    titulo2.sprite = spriteEspañol2;
                }
            }
            else if (InformacionPersistente.singleton.idiomaActual == 1)
            {
                titulo.sprite = spriteIngles;

                if (esTitulo2)
                {
                    titulo2.sprite = spriteIngles2;
                }
            }
            else if (InformacionPersistente.singleton.idiomaActual == 2)
            {
                titulo.sprite = spriteGallego;

                if (esTitulo2)
                {
                    titulo2.sprite = spriteGallego2;
                }
            }
            else
            {
                titulo.sprite = spriteEspañol;

                if (esTitulo2)
                {
                    titulo2.sprite = spriteEspañol2;
                }
            }
        }
    }

    public void ModoTutorialOn(bool value)
    {
        InformacionPersistente.singleton.esTutorial = value;
    }

    public void ModoTemporadaOn(bool value)
    {
        InformacionPersistente.singleton.esTemporada = value;
    }
    public void ModoEntrarTemporadaOn(bool value)
    {
        InformacionPersistente.singleton.entradoTemporada = value;
        if (value)
        {
            InformacionPersistente.singleton.naveTerricola = null;
        }
    }

    public void GenerarCircuitosTemporadas()
    {
        if (!InformacionPersistente.singleton.esTemporada)
        {
           
            circuitosListos = false;
            DatabaseAccess db = FindObjectOfType<DatabaseAccess>();
            db.GetCircuitoFromDataBaseModoTemporada(this);
            StartCoroutine(esperarCircuitos("ModoTemporada"));
        }
        else
        {
            InformacionPersistente.singleton.currentCircuito = InformacionPersistente.singleton.modoManager[InformacionPersistente.singleton.contCircuitoManager];
         
            IrA("ModoTemporada");
        }
  
    }
    public void CopaOn(bool value)
    {
        InformacionPersistente.singleton.esCopa = value;
    }
    public void GenerarCircuitosCopa()
    {

            circuitosListos = false;
            DatabaseAccess db = FindObjectOfType<DatabaseAccess>();
            db.GetCircuitoFromDataBaseModoCopa(this);
            StartCoroutine(esperarCircuitos("CocheReglaje"));
      
    }



        IEnumerator esperarCircuitos(string scene)
    {
        yield return new WaitUntil(() => circuitosListos);
        InformacionPersistente.singleton.contCircuitoManager = 0;
        IrA(scene);
    }
    public void IrA(string s)
    {

        if (!InformacionPersistente.singleton.esMovil)
        {
            sceneFader.FadeTo(s);
            InformacionPersistente.singleton.escenaActual = s;
        }
        else
        {

           CambiarSceneEditor(s);
        }
     
    }

    public void Desactivar(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
    }

    public void PonerTuto()
    {

        if (InformacionPersistente.singleton.esMovil)
        {
            tutoMovil.SetActive(true);
        }
        else
        {
            tutoPC.SetActive(true);
        }
    }
    public void CambiarPanel(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        PPrincipal.SetActive(!PPrincipal.activeSelf);

        if (PPrincipal.activeSelf)
        {
            InformacionPersistente.singleton.escenaActual = PPrincipal.name;
        }
        else
        {
            InformacionPersistente.singleton.escenaActual = scene.name;
        }
    }

    public void Mutear(bool value)
    {
        SoundManager.singleton.Mutear(value);
    }
    public void CambiarPestana(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        pestanaActual.SetActive(!pestanaActual.activeSelf);
        pestanaActual = scene;
    }

    public void AsignarPestana(GameObject scene)
    {
        pestanaActual = scene;
    }
  
    public void CambiarSceneEditor(string scene)
    {
        SceneManager.LoadScene(scene);
        InformacionPersistente.singleton.escenaActual = scene;
    }

    public void CambiarIdioma(int i)
    {
        InformacionPersistente.singleton.idiomaActual = i;
    }

    public void EnablePestana(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        pestanaActualClas.SetActive(!pestanaActual.activeSelf);
        pestanaActualClas = scene;
    }

    public void RecogerInput(Text input){
        string str = input.text;

        Debug.Log(str);
    }



}
