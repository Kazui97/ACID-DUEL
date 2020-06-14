using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    public Transform puntero;

    Vector3 dir;

    public float distance;


    void Start()
    {
        this.dir = new Vector3(0, 0, this.distance);
        transform.position = this.puntero.position - this.puntero.rotation * this.dir;
        transform.LookAt(this.puntero);
        
    }

   
    void Update()
    {
        this.distance += Input.GetAxis("Mouse ScrollWheel");
        this.distance = Mathf.Clamp(distance, 0.1f, 6f);
    }

    private void LateUpdate()
    {
        this.dir.Set(0, 0, this.distance);
        transform.position = this.puntero.position - this.puntero.rotation * this.dir;
        transform.LookAt(this.puntero);
        
    }
}
