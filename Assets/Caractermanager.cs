using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Caractermanager : MonoBehaviourPun , IPunObservable
{

    Caminadoanimacion caminando;
    Camera Camera;
    public float vida = 100;
    public Text Nvida;
    
    void Start()
    {
        Nvida.text += vida;
        caminando = GetComponent<Caminadoanimacion>();
        Camera = gameObject.GetComponentInChildren<Camera>();
        
        if (!this.photonView.IsMine)
        {
            Nvida.enabled = false;
            caminando.enabled = false;
            Camera.enabled = false;
            
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(vida);
           
        }
        else if (stream.IsReading)
        {
           vida = (int)stream.ReceiveNext();
           

        }

    }



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "prueba" && this.photonView.IsMine)
    //    {
    //        Debug.Log("gane");
    //        gane.enabled = true;

    //    }
    //    else if(collision.gameObject.tag == "prueba" && !this.photonView.IsMine)
    //    {
    //        Debug.Log("perdi");
    //        perdi.enabled = true;
    //    }

    //}
}
