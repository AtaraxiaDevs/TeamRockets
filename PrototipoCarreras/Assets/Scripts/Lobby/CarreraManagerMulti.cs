using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreraManagerMulti : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabCircuito;
    public Circuito circuito;

    void Start()
    {
        
    }
     public void CreateLevel()
    {
        Debug.Log("Creando Jugador");
        PhotonNetwork.AutomaticallySyncScene = true;
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
