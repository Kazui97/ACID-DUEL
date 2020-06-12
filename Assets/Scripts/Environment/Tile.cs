using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    float decremento=1f;
    float velocidad=-0.4f;
    public AudioClip acidSound;
    public Animator disolveAnimation;
    private Material material_Objeto;

    
    public bool colision_bala=false;
    public bool vulnerable;

    void Start()
    {
        gameObject.name="Plataforma_zocalos";
        material_Objeto = GetComponent<Renderer>().material;
        if (vulnerable)
        {
            disolveAnimation=GetComponent<Animator>();
            disolveAnimation.enabled=false;
        }
        
    }

    public void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<Bullet>() && vulnerable)
        {
            
            colision_bala=true;
            AudioSource.PlayClipAtPoint(acidSound,transform.position);
            if (vulnerable)
            {
                disolveAnimation.enabled=true;
            }
            
            other.gameObject.GetComponent<Bullet>().onCorrosion=true;
            Destroy(transform.parent.gameObject,1.5f);
            //Destroy(gameObject, 1.5f);
        }

        
        
    }
    
    void Update()
    {
        
        if(colision_bala==true)
        {
            transform.localScale = new Vector3(1,decremento,1);

            decremento=decremento+(velocidad*Time.deltaTime);

        }




    }
}
