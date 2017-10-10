using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Photon.PunBehaviour {

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        Debug.Log("New player connected: " + newPlayer.NickName);
        if (!PhotonNetwork.isMasterClient)
            return;

        loadLevel();
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log("Player disconnected : " + otherPlayer.NickName);

        if (!PhotonNetwork.isMasterClient)
            return;
        loadLevel();
    }

    private void loadLevel()
    {
        if (!PhotonNetwork.isMasterClient)
            Debug.LogError("NOT THE MASTER CLIENT!");

        Debug.Log("Loading level: " + PhotonNetwork.room.playerCount);
        PhotonNetwork.LoadLevel("Main");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
}
