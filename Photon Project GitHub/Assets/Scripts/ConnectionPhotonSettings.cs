using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionPhotonSettings : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _PanelLogin, _PanelRoom;
    [SerializeField]
    private InputField _PlayerName, _RoomName;

    [SerializeField]
    private GameObject _Player;

    //-----------------------------------------------------------------------------------------------------

    public void Login()
    {
        PhotonNetwork.NickName = _PlayerName.text;
        PhotonNetwork.ConnectUsingSettings();
        _PanelLogin.SetActive(false);
        _PanelRoom.SetActive(true);
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(_RoomName.text, new RoomOptions(), TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Online");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnLobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join Random Failed");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);

        _PanelRoom.SetActive(false);
        PhotonNetwork.Instantiate(_Player.name, new Vector3(0, Random.Range(1,8),0),Quaternion.identity,0);
    }
}
