using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    // ORBIT VARS
    int orbiTimer, fallingTime;
    public Vector3 target;
    public GameObject  lookingGo, orbit, compactMe, me;

    // CONTROL VARS
    public bool normalLook=true, taked, falling;
    public float speed;
    public GameObject head, kondor;

    // MEDIA VARS


    //--------------------------------------------------------------------------------------------------
    void Awake()
    {
        normalLook=true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        taked=true;
        

        for (int i = 0; i < orbit.transform.childCount; i++)
        {
            orbit.transform.GetChild(i).gameObject.AddComponent<PitcherFocus>().gfe=gameObject;
        }

        transform.position=kondor.GetComponent<Kondor>().pitcherpoint.transform.position;
        
    }
    

    void Update()
    {

        if (taked)
        {
            transform.position=kondor.GetComponent<Kondor>().pitcherpoint.transform.position;
            normalLook=false;
            gameObject.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            normalLook=!normalLook;
        }

        if (normalLook)
        {
            Control(); 
        }

        me.SetActive(normalLook);
        compactMe.SetActive(!normalLook);
        orbit.SetActive(gameObject.activeSelf);
        orbit.transform.position=transform.position;

        if (falling)
        {
            fallingTime++;
            if (fallingTime>20)
            {
                fallingTime=0;
                falling=false;
            }
        }
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Kondor>() && falling==false)
        {
            taked=true;
        }
    }
     
    //--------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------

    void Control()
    {
        Vector3 pos=transform.position;
        Vector3 velocity=Vector3.Lerp(pos,target,0.01f);
        velocity=new Vector3(velocity.x,0,velocity.z);
        transform.position=new Vector3(velocity.x, transform.position.y, velocity.z);

        orbit.transform.Rotate(transform.up*4);
        
        
        for (int i = 0; i < orbit.transform.childCount; i++)
        {
            orbit.transform.GetChild(i).transform.Translate
            ( new Vector3(0, 0, Mathf.Sin(Time.time*2))/2 );
        }
        
        orbiTimer++;
        if (orbiTimer==80)
        {
            LookSome();
            orbiTimer=0;
        }
    }

    void LookSome()
    {
        Vector3 looking= orbit.transform.GetChild(Random.Range(1, orbit.transform.childCount)).transform.position;
        head.transform.LookAt(looking);
    }

}



public class PitcherFocus : MonoBehaviour
{
    public GameObject gfe;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name=="Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}


/*
// public class Pitcher : MonoBehaviour
// {
//     // SHOT VARS
//     int cantbullets;
//     public GameObject bulletsContainer, lookingGo, orbit;
//     public static Queue<GameObject> bullets = new Queue<GameObject>();

//     // CONTROL VARS
//     int jumps, orbiTimer;
//     public bool onAir, shot;
//     public float speed;
//     public float x,y,xr=0,yr=0;
//     public GameObject head, lower, lowerdir;

//     // MEDIA VARS
//     Animator lowerBodyAnim;


//     //--------------------------------------------------------------------------------------------------
//     void Awake()
//     {
//         Cursor.visible = false;
//         Cursor.lockState = CursorLockMode.Locked;
        
//         head=transform.GetChild(0).gameObject;
//         lower=transform.GetChild(1).gameObject;
//         lowerdir=transform.GetChild(2).gameObject;

//         lowerBodyAnim=lower.transform.GetChild(0).gameObject.GetComponent<Animator>();
        
//         cantbullets=bulletsContainer.transform.childCount;
//         for (int i = 0; i < cantbullets; i++)
//         {
//             bullets.Enqueue(bulletsContainer.transform.GetChild(i).gameObject);
//             bulletsContainer.transform.GetChild(i).gameObject.AddComponent<Proyectile>();
//             bulletsContainer.transform.GetChild(i).gameObject.SetActive(false);
//         }

//         for (int i = 0; i < orbit.transform.childCount; i++)
//         {
//             orbit.transform.GetChild(i).gameObject.AddComponent<PitcherFocus>().gfe=gameObject;
//         }
//     }

//     void Update()
//     {
//         // Shot();
//         Control();

//         // float forwards=(new Vector2(x,y).normalized).magnitude;
//         // if (y<0)
//         // {
//         //     forwards=y;
//         // }
//         // lowerBodyAnim.SetFloat("forward", forwards);
//     }

//     private void OnCollisionEnter(Collision other)
//     {
        
//         if (other.transform.name=="Floor")//(other.gameObject.GetComponent<Tile>())
//         {
//             onAir=false;
//             jumps=0;
//         }
        
//     }
     
//     //--------------------------------------------------------------------------------------------------
//     //--------------------------------------------------------------------------------------------------

//     void Control()
//     {
//         // INPUTS
//         x=Input.GetAxis("Horizontal");
//         y=Input.GetAxis("Vertical");
//         xr=Input.GetAxis("Mouse X");
//         yr=Input.GetAxis("Mouse Y");

//         // LOWER BODY LOOKING
//         Vector3 velocity=new Vector3(x,0,y);
//         GetComponent<Rigidbody>().velocity=velocity*speed;

//         head.transform.LookAt(lookingGo.transform.position);
//         orbit.transform.Rotate(transform.up*4);
//         orbit.transform.position=transform.position;
//         orbit.transform.localPosition+=new Vector3(0.0f, Mathf.Sin(Time.time*1.5f), 0.0f)*2.5f;
        
//         for (int i = 0; i < orbit.transform.childCount; i++)
//         {
//             orbit.transform.GetChild(i).transform.Translate
//             ( new Vector3(0, 0, Mathf.Sin(Time.time*2))/2 );
//         }

//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             jumps++;
//             if (jumps<3)
//             {
//                 GetComponent<Rigidbody>().AddForce(transform.up*180);
//                 onAir=true;
//             }
//         }

//         // head.transform.Rotate(yr*-1,xr,0);

//         // lowerdir.transform.localPosition=velocity*5;
//         // if (y>=0)
//         // {
//         //     lower.transform.LookAt(lowerdir.transform.position);
//         // }
        
//         // lower.transform.eulerAngles=new Vector3(0,lower.transform.eulerAngles.y,0);

//         // // MOVING BODY
//         // Rigidbody r=GetComponent<Rigidbody>();
//         // float velUp=r.velocity.y;
//         // Vector3 desiredVelocity = (x * transform.right + y * transform.forward * 2);
//         // r.velocity=desiredVelocity*speed + transform.up*velUp;

//         // // ROTATATE OF head AND BODY
//         // head.transform.Rotate(yr*-1,0,0);
//         // head.transform.eulerAngles=new Vector3(head.transform.eulerAngles.x,head.transform.eulerAngles.y,0);
//         // transform.Rotate(0,xr*2.6f,0);

//         // JUMP
        
//     }

//     void Shot()
//     {
        
//         if (shot)
//         {
//             GameObject go=bullets.Dequeue();
//             go.SetActive(true); 
//             go.transform.position=lookingGo.transform.position;
//             go.GetComponent<Rigidbody>().AddForce(lookingGo.transform.forward*1400);
//             go.GetComponent<Proyectile>().droped= true;
//             go.GetComponent<Proyectile>().myQueue=bullets;
//             shot=false;
//             // AudioSource.PlayClipAtPoint(shotClip, transform.position);
//         }
//     }

//     public void ShotCatched(GameObject lookAt)
//     {
//         head.transform.LookAt(lookAt.transform.position);
//         shot=true;
//     }

//     public static void Introducing(GameObject go, Queue<GameObject> list)
//     {
//         list.Enqueue(go.gameObject);
//         go.GetComponent<Rigidbody>().velocity=Vector3.zero;
//         go.SetActive(false);
//     }
    

// }

// public class PitcherFocus : MonoBehaviour
// {
//     public GameObject gfe;
    
//     void OnTriggerEnter(Collider other)
//     {
//         if (other.transform.name=="Enemy")
//         {
//             Destroy(other.gameObject);
//         }

//         // if (other.transform.name=="Enemy")
//         // {
//         //     // gfe.GetComponent<Pitcher>().ShotCatched(gameObject);
//         //     Debug.Log("Pinga");
//         //     gfe.GetComponent<Pitcher>().lookingGo=gameObject;
//         //     gfe.GetComponent<Pitcher>().shot=true;
//         //     Debug.Log("pinga!");
//         // }
//     }
// }
*/