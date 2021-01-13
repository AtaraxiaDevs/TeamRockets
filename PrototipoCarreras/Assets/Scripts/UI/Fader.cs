using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;

    #region Unity
    public void Start()
    {
        if(!InformacionPersistente.singleton.esMovil)
            StartCoroutine(FadeIn());
    }
    #endregion
    #region Metodos

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        Time.timeScale = 1;
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;

            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t > 1f)
        {
            t += Time.deltaTime;

            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
    #endregion


}
