using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    GameObject head;
    int  timeCount=0, timeLapse=20;
    public GameObject  targetLook, shotpoint, player;
    public float playerDistance;
    public AudioClip shot;
    public bool forInduction;
    
    
    void Awake()
    {
        head=transform.GetChild(0).gameObject;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.y<-2)
        // {
        //     DemoManager.totemsCont--;
        //     gameObject.SetActive(false);
        // }

        // head.transform.LookAt(targetLook.transform.position);
        // if (playerDistance>10)
        // {
        //     head.transform.eulerAngles=new Vector3(-22, head.transform.eulerAngles.y, 0);
        // }

        // timeCount++;
        // if (timeCount==timeLapse)//(Input.GetKeyDown(KeyCode.G))//
        // {
        //     GameObject go=DemoManager.bullets.Dequeue();
        //     go.SetActive(true); 
        //     go.transform.position=shotpoint.transform.position;
        //     go.GetComponent<Rigidbody>().AddForce(shotpoint.transform.forward*1000);
        //     go.GetComponent<Rigidbody>().useGravity= true;
        //     go.GetComponent<Bullet>().droped= true;
        //     AudioSource.PlayClipAtPoint(shot,transform.position);

        //     timeCount=0;
        //     timeLapse=Random.Range(20,50);
        //     // AudioSource.PlayClipAtPoint(shotClip, transform.position);
        // }

        // playerDistance=(transform.position-player.transform.position).magnitude;
    }


}

