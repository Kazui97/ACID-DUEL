using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    int timelife=0;
    public bool droped, onCorrosion;
    public Queue<GameObject> myQueue = new Queue<GameObject>();
    void Update()
    {
        if (droped)
        {
            timelife++;
            if (timelife==55 || onCorrosion)
            {
                Control.Introducing(gameObject, myQueue);
                
                timelife=0;
                droped=false;
                onCorrosion=false;

                // | INSTANCIA CUBO BLANCO AL DESAPARECER EL PROYECTIL |

                /*GameObject ins=GameObject.CreatePrimitive(PrimitiveType.Cube);
                ins.transform.position=transform.position;
                ins.transform.localScale=ins.transform.localScale*0.5f;*/
            }
        }
    }
}
