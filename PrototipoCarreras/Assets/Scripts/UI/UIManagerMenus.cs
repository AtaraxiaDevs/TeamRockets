using UnityEngine.UI;
using UnityEngine;

public class UIManagerMenus : MonoBehaviour
{
    public Fader sceneFader;

    [Header("ModoTemporada")]
    public GameObject ModoTemporada;
    public Reglajes reg;
    public Dropdown RM;
    public Dropdown ED;

    public void IrA(string s)
    {
        sceneFader.FadeTo(s);
    }

    public void EditarCoche()
    {
        reg.ElegirReglajes(RM.value, ED.value);
    }

    public void CambiarEscena(GameObject scene)
    {
        scene.SetActive(!scene.activeSelf);
        ModoTemporada.SetActive(!ModoTemporada.activeSelf);
    }
}
