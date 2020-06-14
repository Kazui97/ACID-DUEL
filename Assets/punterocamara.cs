using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punterocamara : MonoBehaviour
{
    public float pospuntero;
    public Transform player;
    private float sensivilityX;
    private float mousex;
    private float sensivilityY;
    private float mousey;


    void Start()
    {
        transform.position = player.position + new Vector3(0, pospuntero, 0);

        this.sensivilityX = 4f;
        this.sensivilityY = 1.5f;
    }

  
    void Update()
    {
        transform.position = player.position + new Vector3(0, pospuntero, 0);

        mousex = Input.GetAxis("Mouse X") * sensivilityX;
        mousey = Input.GetAxis("Mouse Y") * sensivilityY;
        Vector3 rotation = transform.eulerAngles;

        float rotationX;

        if (rotation.x > 90)
        {
            rotationX = rotation.x - 360;
        }
        else
            rotationX = rotation.x;

        if((mousey < 0 && rotationX < 75) || (mousey > 0 && rotationX> -60))
        {
            transform.Rotate(-mousey, 0, 0);
        }

        transform.RotateAround(transform.position, Vector3.up, this.mousex);

    }
}
