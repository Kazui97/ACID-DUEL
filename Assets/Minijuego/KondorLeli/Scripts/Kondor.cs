using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kondor : MonoBehaviour
{
    public GameObject pitchersContainer, pitcherpoint, toActive, toDrop;
    int onclickTimer;
    bool dropmode, activemode;
    public float x,y,xr=0,yr=0, speed, sensibility;

    void Awake()
    {
        for (int i = 0; i < pitchersContainer.transform.childCount; i++)
        {
            pitchersContainer.transform.GetChild(i).gameObject.SetActive(false);
            pitchersContainer.transform.GetChild(i).GetComponent<Pitcher>().kondor=gameObject;
            
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxis("Horizontal");
        y=Input.GetAxis("Vertical");
        xr=Input.GetAxis("Mouse X");
        yr=Input.GetAxis("Mouse Y");

        Rigidbody rg=GetComponent<Rigidbody>();
        transform.Rotate(yr*-1*sensibility,xr*sensibility,0);
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        float velUp=rg.velocity.y;
        Vector3 vel=(x * transform.right + y * transform.forward * 2);
        rg.velocity=vel*speed;
        rg.velocity=new Vector3(rg.velocity.x, velUp, rg.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.velocity=new Vector3(rg.velocity.x, speed, rg.velocity.z);
        }

        GameObject auxA=pitchersContainer.transform.GetChild(0).gameObject,
        auxB=pitchersContainer.transform.GetChild(1).gameObject,
        auxC=pitchersContainer.transform.GetChild(2).gameObject;

        if (Input.GetMouseButtonDown(0))
        {
            dropmode = !dropmode;
            if (activemode)
            {
                activemode=false;
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            activemode = !activemode;
            if (dropmode)
            {
                dropmode=false;
            }
        }
        toDrop.SetActive(dropmode);
        toActive.SetActive(activemode);
        toDrop.transform.Rotate(transform.up*3);
        toActive.transform.Rotate(transform.up*3);
        
        if (dropmode)
        {
            Debug.Log("ready");
            if (Input.GetKeyDown(KeyCode.Alpha1) && auxA.activeSelf==false)
            {
                auxA.SetActive(true);
                auxA.GetComponent<Pitcher>().normalLook=false;
                auxA.GetComponent<Pitcher>().taked=false;
                auxA.GetComponent<Pitcher>().falling=true;
                auxA.transform.position=pitcherpoint.transform.position;
                dropmode=false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && auxB.activeSelf==false)
            {
                auxB.SetActive(true);
                auxB.GetComponent<Pitcher>().normalLook=false;
                auxB.GetComponent<Pitcher>().taked=false;
                auxB.GetComponent<Pitcher>().falling=true;
                auxB.transform.position=pitcherpoint.transform.position;
                dropmode=false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && auxC.activeSelf==false)
            {
                auxC.SetActive(true);
                auxC.GetComponent<Pitcher>().normalLook=false;
                auxC.GetComponent<Pitcher>().taked=false;
                auxC.GetComponent<Pitcher>().falling=true;
                auxC.transform.position=pitcherpoint.transform.position;
                dropmode=false;
            }
            
        }
        else if (activemode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                auxA.GetComponent<Pitcher>().normalLook=!auxA.GetComponent<Pitcher>().normalLook;
                activemode=false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                auxB.GetComponent<Pitcher>().normalLook=!auxB.GetComponent<Pitcher>().normalLook;
                activemode=false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                auxC.GetComponent<Pitcher>().normalLook=!auxC.GetComponent<Pitcher>().normalLook;
                activemode=false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && auxA.activeSelf)
            {
                auxA.GetComponent<Pitcher>().target=transform.position;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && auxA.activeSelf)
            {
                auxB.GetComponent<Pitcher>().target=transform.position;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && auxA.activeSelf)
            {
                auxC.GetComponent<Pitcher>().target=transform.position;
            }
        }

        
    }
}
