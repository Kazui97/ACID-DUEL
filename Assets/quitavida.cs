using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitavida : MonoBehaviour
{
    Caractermanager controlvida;

    void Start()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player 1")
        {
            controlvida = collision.gameObject.GetComponent<Caractermanager>();

            if (controlvida.vida > 20)
            {
                controlvida.vida = controlvida.vida -20;
                Debug.Log("Vida actual" + controlvida.vida);
                controlvida.Nvida.text  = controlvida.vida.ToString();

                if(controlvida.vida <= 40)
                {
                    controlvida.Nvida.color = Color.red;
                }
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
            //Destroy(gameObject, 0.2f);

        }
    }
}
