using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Caractermanager : MonoBehaviourPun
{
   
    Control Control;
    Camera Camera;
    
    void Start()
    {
       
        Control = GetComponent<Control>();
        Camera = gameObject.GetComponentInChildren<Camera>();
        
        if (!this.photonView.IsMine)
        {
           
            Control.enabled = false;
            Camera.enabled = false;
            
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
