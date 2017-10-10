using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {

    [SerializeField]
    private PhotonLogLevel logLevel = PhotonLogLevel.Informational;

    [SerializeField]
    private byte MAX_PLAYERS;

    [SerializeField]
    private string GAME_VERSION;

    [SerializeField]
    private bool offlineMode;

    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.offlineMode = offlineMode;
        PhotonNetwork.logLevel = logLevel;
    }

    public void connect()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings(GAME_VERSION);
            return;
        }

        PhotonNetwork.JoinRandomRoom();
        
    }

    private RoomOptions roomOptions()
    {
        RoomOptions option;
        option = new RoomOptions();
        option.MaxPlayers = MAX_PLAYERS;
        return option;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        //Failed to join room , full or none exist.
        PhotonNetwork.CreateRoom(null, roomOptions(), null);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.room.PlayerCount != 1)
            return;
        
        PhotonNetwork.LoadLevel("Main");
    }

}
