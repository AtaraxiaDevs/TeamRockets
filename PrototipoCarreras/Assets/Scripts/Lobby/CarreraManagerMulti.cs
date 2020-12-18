using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarreraManagerMulti : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabCircuito;
    public Circuito circuito;
    public Text soyJugador;

    public int PlayerID= -1;
    void Start()
    {
        
    }
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
            soyJugador.text = "Soy el jugador " + PlayerID;
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
