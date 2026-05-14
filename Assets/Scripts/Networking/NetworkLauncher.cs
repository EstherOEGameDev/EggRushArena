
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting");
    }



public override void OnConnectedToMaster()
    {
        Debug.Log(" Connected to photon!");
    }

}
