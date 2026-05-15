
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No Room Found");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;

        PhotonNetwork.CreateRoom("Room1", roomOptions);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");

        Vector2 spawnPos = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));

        PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity);
    }
}
