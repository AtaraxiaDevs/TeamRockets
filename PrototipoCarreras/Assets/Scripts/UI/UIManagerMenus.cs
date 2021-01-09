using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenus : MonoBehaviour
{
    public Fader sceneFader;

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

    private void Start()
    {
        SoundManager.singleton.EjecutarMusica(MUSICA.MENU);


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

    public void ModoTutorialOn()
    {

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
