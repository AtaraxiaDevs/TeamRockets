using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No estoy segura de si esto se usa
public class NetwotkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

   
}
