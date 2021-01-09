using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConverManager : MonoBehaviour
{

    public GameObject refUI;
    public Text refLine;
    public float speed;
    private Dictionary<string, Conversacion> listConver;
    public Conversacion[] listConveraux;

    public int numChara = 140;
    private bool ejecutando = false;
    private SoundManager sm;

  
    public void addConver(Conversacion c)
    {
        if (listConver.ContainsKey(c.clave))
        {
            Debug.Log("Error, conversacion duplicada: " + c.clave);
        }
        else
        {
            listConver.Add(c.clave, c);
        }
    }
    private void mostrarTexto(string line)
    {
        refLine.text = line;
    }
    public bool PlayConversation(string clave)

    {

        sm = FindObjectOfType<SoundManager>();
        Conversacion aux;
        if (listConver.TryGetValue(clave, out aux))
        {
            string line = aux.GetConver(numChara);
            if (line == null)
            {
                refUI.SetActive(false);
                return true;
            }
            else
            {
                if (!refUI.active)
                {
                    refUI.SetActive(true);

                }
             
                StopAllCoroutines();
                StartCoroutine(textoView(line));
                
               
                return false;
            }

        }
        else
        {
            Debug.Log("Error, conversacion no encontrada: " + clave);
            return false;
        }
    }
    void Awake()
    {
        listConver = new Dictionary<string, Conversacion>();
        for (int i = 0; i < listConveraux.Length; i++)
        {
            addConver(listConveraux[i]);
        }


    }
        IEnumerator textoView(string line)
    {
        ejecutando = true;
           for(int i=0; i<line.Length;i++)
        {
            refLine.text = line.Substring(0,i+1);
            sm.EjecutarSonido(SONIDO.HABLA);
            yield return new WaitForSeconds(1 / speed);
        }
        ejecutando = false;
       
        
    }

    public void Resetear()
    {
        StopAllCoroutines();
        foreach(Conversacion c in listConver.Values)
        {
            c.resetear();
        }
        refUI.SetActive(false);
    }
    private void Wait(float time)
    {
        Thread.Sleep((int)time * 1000);
    }
    private void OnApplicationQuit()
    {
        Resetear();
    }
}
