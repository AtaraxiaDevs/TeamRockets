using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarreraManagerMulti : MonoBehaviour
{
    //Referencias
    public GameObject prefabCircuito;
    public Circuito circuito;
    public Text soyJugador;
    //Informacion
    public int PlayerID= -1;
 
    // Metodo que se deberá tocar cuando hagamos el online. Por ahora decide cual es el jugador del usuario local.
     public void CreateLevel()
    {
        Debug.Log("Comenzando");
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PlayerID < 0)
        {
            Debug.Log("kapasao");
        }
        else
        {
            circuito.setMyPlayer(PlayerID-1);
            circuito.setMulti();
            soyJugador.text = "Soy el jugador " + PlayerID;
        }
      
    }
 
}
