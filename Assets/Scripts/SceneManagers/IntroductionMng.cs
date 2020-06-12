using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionMng : MonoBehaviour
{ 
    public int activedIndex=-1, talkerIndex=-1;
    public GameObject player, enemy, clipsContainer, audioContainer, talkersContainer, indicatorsCointainer;
    public GameObject[] posters, voices, talkers, indicators;
    public GameObject win, lose, msg, tracks;
    
    bool playSpeak, play=true;
    public GameObject talkerSpeaking;
    public AudioSource voicePlaying, soundtrack;
    public AudioClip reach;
    int[] reachPlays;
    float sdtrackVol; 
    int closeTalkers=0;
    
    private void Awake()
    {
        // POSTERS
        posters=new GameObject[clipsContainer.transform.childCount];
        for (int i = 0; i < clipsContainer.transform.childCount; i++)
        {
            posters[i]=clipsContainer.transform.GetChild(i).gameObject;
        }

        // VOICE CLIPS
        voices=new GameObject[audioContainer.transform.childCount];
        for (int i = 0; i < audioContainer.transform.childCount; i++)
        {
            voices[i]=audioContainer.transform.GetChild(i).gameObject;
        }

        // TALKERS
        talkers=new GameObject[talkersContainer.transform.childCount];
        for (int i = 0; i < talkersContainer.transform.childCount; i++)
        {
            talkers[i]=talkersContainer.transform.GetChild(i).gameObject;
        }

        // INDICATORS
        indicators=new GameObject[indicatorsCointainer.transform.childCount];
        for (int i = 0; i < indicatorsCointainer.transform.childCount; i++)
        {
            indicators[i]=indicatorsCointainer.transform.GetChild(i).gameObject;
            indicators[i].SetActive(true);
        }

        sdtrackVol=soundtrack.volume;
        reachPlays=new int[3] {0,0,0};
        voicePlaying=null;
    }

    void Update()
    {
        if (play)
        {
            Interactions();
            Indicators();
        }
        player.GetComponent<Control>().play=play;
    }

    void Interactions()
    {
        // PLAY VOICE AUDIO
        if (Input.GetKeyDown(KeyCode.G) &&  playSpeak)
        {
            if (voicePlaying!=null && voicePlaying.isPlaying)
            {
                voicePlaying.Stop();
                
            }
            voices[talkerIndex].GetComponent<AudioSource>().Play();
            voicePlaying=voices[talkerIndex].GetComponent<AudioSource>();
            playSpeak=false;
        }
        
        if (voicePlaying!=null)
        {
            if (voicePlaying.isPlaying)
            {
                soundtrack.volume=sdtrackVol*0.4f;
            }else
            {
                soundtrack.volume=sdtrackVol;
            }
            if (Input.GetKey(KeyCode.G)==false)
            {
                voicePlaying.Stop();
            }
        }
        
        

        // VERIFY PLAYER CLOSE TO POSTER
        int index=-1;
        foreach (var item in posters)
        {
            index++;
            item.gameObject.SetActive((item.transform.position-player.transform.position).magnitude<3.5f);
            item.transform.LookAt(player.transform.GetChild(1).transform.position);
            item.transform.eulerAngles=new Vector3(0,item.transform.eulerAngles.y,0);
            
            if ((item.transform.position-player.transform.position).magnitude<2.5f)
            {
                activedIndex=index;
            }
        }

        // VERIFY PLAYER CLOSE TO TALKER
        index=-1;
        foreach (var item in talkers)
        {
            index++;
            if ((item.transform.position-player.transform.position).magnitude<3.5f)
            {
                item.transform.GetChild(0).transform.LookAt(player.transform.position);
                talkerIndex=index;
                playSpeak=true;
                closeTalkers++;
            }else
            {
                item.transform.eulerAngles=Vector3.zero;
            }
        }
        msg.SetActive(closeTalkers>0);
        closeTalkers=0;
        
    }
    
    void Indicators()
    {
        // INDICATORS
        // if (activedIndex==1)
        // {
        //     foreach (var item in indicators)
        //     {
        //         item.gameObject.SetActive(true);
        //     }            
        // }
        if (activedIndex==4)
        {
            enemy.SetActive(true);
        }
        
        if ((indicators[0].transform.position-player.transform.position).magnitude<2)
        {
            if (reachPlays[0]<1) //-----> Play indicator audio FX
            {
                // AudioSource.PlayClipAtPoint(reach, player.transform.position);
                GetComponent<AudioSource>().PlayOneShot(reach);
            }
            reachPlays[0]++;

            indicators[0].SetActive(false); //--> Desactivar indicador
        }
        if ((indicators[1].transform.position-player.transform.position).magnitude<2)
        {
            if (reachPlays[1]<1) //-----> Play indicator audio FX
            {
                GetComponent<AudioSource>().PlayOneShot(reach);
            }
            reachPlays[1]++;

            indicators[1].SetActive(false); // --> Desactivar indicador
        }
        if (indicators[2].transform.childCount==1)
        {
            if (reachPlays[2]<1) //-----> Play indicator audio FX
            {
                GetComponent<AudioSource>().PlayOneShot(reach);
            }
            reachPlays[2]++;

            indicators[2].SetActive(false); // --> Desactivar indicador
        }

        indicators[3].transform.position=enemy.transform.position;
        if (enemy.transform.position.y<-15 && indicators[2].activeSelf==false)
        {
            win.SetActive(true);
            play=false;
        }
        if (player.transform.position.y<-20)
        {
            lose.SetActive(true);
            play=false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (reachPlays[i]>3)
            {
                reachPlays[i]=2;
            }
        }
    
    }
}


