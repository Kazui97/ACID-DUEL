using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminadoanimacion : MonoBehaviour
{
    ////public Animator Animaciones;
    public float vel;

    void Start()
    {
        //Animaciones = GetComponent<Animator>();

    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
           // Animaciones.SetBool("caminar", true);
            //Animaciones.SetBool("quieto", false);
            transform.position += transform.forward * vel * Time.deltaTime;
        }
        else
        {
            //Animaciones.SetBool("caminar", false);
            //Animaciones.SetBool("quieto", true);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * vel * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -20f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 20f * Time.deltaTime, 0);
        }
    }
}
