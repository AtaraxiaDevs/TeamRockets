using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManagerMenus : MonoBehaviour
{
    public Fader sceneFader;

    public GameObject tutorial;
    [Header("Panel Principal")]
    public GameObject PPrincipal;

    [Header("Pestañas")]
    public GameObject pestanaActual;

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
        //if (!InformacionPersistente.singleton.esCopa)
        //{
        //    InformacionPersistente.singleton.esCopa = true;
            circuitosListos = false;
            DatabaseAccess db = FindObjectOfType<DatabaseAccess>();
            db.GetCircuitoFromDataBaseModoCopa(this);
            StartCoroutine(esperarCircuitos("CocheReglaje"));
        //}
        //else
        //{
        //    InformacionPersistente.singleton.currentCircuito = InformacionPersistente.singleton.modoCopa[InformacionPersistente.singleton.contCircuitoManager];

        //    IrA("CocheReglaje");
        //}
    }



        IEnumerator esperarCircuitos(string scene)
    {
        yield return new WaitUntil(() => circuitosListos);
        InformacionPersistente.singleton.contCircuitoManager = 0;
        IrA(scene);
    }
    public void IrA(string s)
    {
        sceneFader.FadeTo(s);
        InformacionPersistente.singleton.escenaActual = s;
    }

    public void Desactivar(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
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
    }

    public void CambiarIdioma(int i)
    {
        InformacionPersistente.singleton.idiomaActual = i;
    }
}
