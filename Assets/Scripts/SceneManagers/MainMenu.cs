using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject cam;
    GameObject main, levels, options, looktarget;
    GameObject mainPan, levelsPan, optionsPan, canvas;
    public int screen=1;
    // Start is called before the first frame update
    void Start()
    {
        canvas=GameObject.Find("Canvas").gameObject;
        mainPan=canvas.transform.GetChild(0).gameObject;
        levelsPan=canvas.transform.GetChild(1).gameObject;
        optionsPan=canvas.transform.GetChild(2).gameObject;

        main=GameObject.Find("MainP");
        levels=GameObject.Find("LevelsP");
        options=GameObject.Find("OptionsP");
        looktarget=new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        // cylinder.transform.localScale+=new Vector3(0.0f, Mathf.Sin(Time.time*8), 0.0f)/27;
        

        if (screen==1) //MAIN
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position, main.transform.position, 0.08f);
            looktarget.transform.position=Vector3.Lerp
            (looktarget.transform.position, main.transform.GetChild(0).transform.position,0.05f);
            // mainPan.SetActive(true);
            // levelsPan.SetActive(false);
            // optionsPan.SetActive(false);
        }
        mainPan.SetActive((cam.transform.position-main.transform.position).magnitude<1);

        if (screen==2) //LEVELS
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position, levels.transform.position, 0.08f);
            looktarget.transform.position=Vector3.Lerp
            (looktarget.transform.position, levels.transform.GetChild(0).transform.position,0.05f);
            // mainPan.SetActive(false);
            // levelsPan.SetActive(true);
            // optionsPan.SetActive(false);
        }
        levelsPan.SetActive((cam.transform.position-levels.transform.position).magnitude<1);

        if (screen==3) //OPTIONS
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position, options.transform.position, 0.08f);
            looktarget.transform.position=Vector3.Lerp
            (looktarget.transform.position, options.transform.GetChild(0).transform.position,0.05f);
            // mainPan.SetActive(false);
            // levelsPan.SetActive(false);
            // optionsPan.SetActive(true);
        }
        optionsPan.SetActive((cam.transform.position-options.transform.position).magnitude<1);

        
        cam.transform.LookAt(looktarget.transform.position);
        
    }

    public void ToMain()
    {
        screen=1;
    }
    public void ToLevels()
    {
        screen=2;
    }
    public void ToOptions()
    {
        screen=3;
    }
}
