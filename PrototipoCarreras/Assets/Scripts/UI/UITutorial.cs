using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    ConverManager CM;
    public Button playConversacion;
    public string clave;
    void Start()
    {
        CM = GetComponent<ConverManager>();
        CM.refUI = this.gameObject;
        playConversacion.onClick.AddListener(() => CM.PlayConversation(clave));
        CM.PlayConversation(clave);
    }

    
}
