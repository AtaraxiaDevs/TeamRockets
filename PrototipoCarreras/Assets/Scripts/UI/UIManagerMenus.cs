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

    public void IrA(string s)
    {
        sceneFader.FadeTo(s);
    }

    public void CambiarPanel(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        PPrincipal.SetActive(!PPrincipal.activeSelf);
    }

    public void CambiarPestana(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        pestanaActual.SetActive(!pestanaActual.activeSelf);
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
