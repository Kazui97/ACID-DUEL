using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTotem : MonoBehaviour
{
    int timer=0, lapseMarker=30;
    float playerDistance;
    GameObject head, parent;

    public bool ofInduction;
    public AudioClip shot;
    public GameObject targetLook, shotpoint;

    

    private void Awake()
    {
        head=transform.GetChild(0).gameObject;
        shotpoint=head.transform.GetChild(0).gameObject;
        parent=transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.y<-2)
        // {
        //     Totems.totemsCont--;
        //     gameObject.SetActive(false);
        // }

        head.transform.LookAt(targetLook.transform.position);
        if (playerDistance>10)
        {
            head.transform.eulerAngles=new Vector3(-22, head.transform.eulerAngles.y, 0);
        }

        timer++;
        if (timer==lapseMarker)//(Input.GetKeyDown(KeyCode.G))//
        {
            GameObject go=parent.GetComponent<Totems>().bullets.Dequeue();
            go.SetActive(true); 
            go.transform.position=shotpoint.transform.position;
            go.GetComponent<Rigidbody>().AddForce(shotpoint.transform.forward*1500);
            go.GetComponent<Rigidbody>().useGravity= true;
            go.GetComponent<Bullet>().droped= true;
            go.GetComponent<Bullet>().myQueue=parent.GetComponent<Totems>().bullets;
            AudioSource.PlayClipAtPoint(shot,transform.position);

            timer=0;
            lapseMarker=Random.Range(20,50);
            AudioSource.PlayClipAtPoint(shot, transform.position);
        }

        playerDistance=(transform.position-targetLook.transform.position).magnitude;
    }
}
