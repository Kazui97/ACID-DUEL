using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Autolobby : MonoBehaviourPunCallbacks
{
    public Button conectar;
    public Button buscarocrear;
    public Text info;
    public Text playercont;
    public int playernume;


    public byte maxPlayer = 3;
    public byte minPlayer = 2;

    public bool isloading = false;


    public void Connectar()
    {
        if (!PhotonNetwork.IsConnected)
        {
            
           if(PhotonNetwork.ConnectUsingSettings())
           {
                info.text += "\nconectando al servidor";
           }
           else
            {
                info.text += "\nFallo conectar al servidor";
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        conectar.interactable = false;
        buscarocrear.interactable = true;
    }

    public void joinRandom()  // unirse a sala
    {

        if (!PhotonNetwork.JoinRandomRoom())
        {
            info.text += "\nfallo  al crear sala";
        }
    }
       
        

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        info.text += "\nno hay servidor para unise... creando";

        if (PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() { MaxPlayers = maxPlayer }))
        {
            info.text += "\ncreando servidor";
        }
        else
        {
            info.text += "\nfallo al crear servidor";
        }
    }


    public override void OnJoinedRoom()
    {
        buscarocrear.interactable = false;
        info.text += "\n servido creado";
        PhotonNetwork.Instantiate("Player 1",
          new Vector3(Random.Range(-1, 2), 0.5f, Random.Range(-1, 2)),
          Quaternion.identity, 0);
    }

    private void FixedUpdate()
    {
        if(PhotonNetwork.CurrentRoom != null)
        playernume = PhotonNetwork.CurrentRoom.PlayerCount;
        playercont.text = playernume + "/" + maxPlayer;

        if (!isloading  && playernume >= minPlayer)
        {
            cargarmapa();
        }
    }

    private void cargarmapa()
    {
        isloading = true;
        PhotonNetwork.LoadLevel("mapa");
     

    }

}
