using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using System.Diagnostics;
public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandom();
    }
   
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room found");
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayer =4});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room found");
    }

}
