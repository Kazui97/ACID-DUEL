using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Caractermanager : MonoBehaviourPun
{
    //Caminadoanimacion rott;
    Control Control;
    Camera Camera;
    //punterocamara puntero;
    //public Text gane;
    //public Text perdi;
    void Start()
    {
        //gane.enabled = false;
        //perdi.enabled = false;
        //rott = GetComponent<Caminadoanimacion>();
        Control = GetComponent<Control>();
        Camera = gameObject.GetComponentInChildren<Camera>();
        //puntero = GetComponentInChildren<punterocamara>();
        if (!this.photonView.IsMine)
        {
            //Destroy(rott);
            Control.enabled = false;
            Camera.enabled = false;
            //puntero.enabled = false;
        }
    }

    
    void Update()
    {
        
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
