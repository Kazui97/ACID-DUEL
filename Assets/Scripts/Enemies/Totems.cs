using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totems : MonoBehaviour
{
    GameObject[] basicTotems;

    public GameObject bulletsContainer, targetLook;
    public Queue<GameObject> bullets = new Queue<GameObject>();
    private void Awake()
    {
        basicTotems=GameObject.FindGameObjectsWithTag("basicTotem");
        

        for (int i = 0; i < bulletsContainer.transform.childCount; i++)
        {
            bullets.Enqueue(bulletsContainer.transform.GetChild(i).gameObject);
            bulletsContainer.transform.GetChild(i).gameObject.AddComponent<Bullet>();
            bulletsContainer.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
