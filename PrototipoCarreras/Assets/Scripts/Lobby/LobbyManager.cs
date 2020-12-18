using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Button connect, joinRandom,comenzar;
    public Text Log, PlayerCounter;
    private byte maxPlayersInRoom=4;
    private int playerCounter;
    public UIManagerCarrera uIManagerCarrera;
    public CarreraManagerMulti CM;
    private void Start()
    {
        connect.onClick.AddListener(() => Connect());
        joinRandom.onClick.AddListener(() => JoinRandom());
        comenzar.onClick.AddListener(() => Comenzar());
    }
    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.ConnectUsingSettings())
            {
                Log.text += "\nConectados";
            }
            else
            {
                Log.text += "\nError al conectar";
            }
        }
    }
    public void Comenzar()
    {
        CM.CreateLevel();
        uIManagerCarrera.Comenzar();
        this.gameObject.SetActive(false);
    }
    public override void OnConnectedToMaster()
    {
        //connect.interactable = false;
        //joinRandom.interactable = false;
      
    }
    public void JoinRandom()
    {
        if (!PhotonNetwork.JoinRandomRoom())
        {
            Log.text += "\nError al conectar";
        }
      
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        CM.PlayerID = PhotonNetwork.CurrentRoom.PlayerCount;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log.text += "\nCreando....";
        if (PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions()
        {
            MaxPlayers = maxPlayersInRoom
        }))
        {
            Log.text += "\nSala creada";
        }
        else
        {
            Log.text += "\nFallo al crear";
        }
    }
    private void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            playerCounter = PhotonNetwork.CurrentRoom.PlayerCount;
            PlayerCounter.text = playerCounter + "/" + maxPlayersInRoom;
            
        }
    }
}
