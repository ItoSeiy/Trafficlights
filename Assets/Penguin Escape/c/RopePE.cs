using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RopePE : MonoBehaviour
{
    //ペンギン用


    float speed;

    public bool go;



    private void Start()
    {
        go = true;
        transform.Rotate(new Vector3(0, 0, 180));
    }

    void Update()
    {
        speed = ControllerPe.allspeed;

        if (go == true)
        {
            this.transform.position += new Vector3(0, Time.deltaTime * -speed, 0);
        }
        else
        {
            this.transform.position += new Vector3(0, Time.deltaTime * speed * 1.5f, 0);
        }

        if (transform.position.y <= -1)
        {
            go = false;           
        }

        if (transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }

        
             
    }

    //クリック
    public void RopeClick(BaseEventData date)
    {
        ControllerPe.score = ControllerPe.score + 100; 
        Destroy(this.gameObject);
    }
}
