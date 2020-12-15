using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetwotkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
