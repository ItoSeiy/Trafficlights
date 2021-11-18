using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tako2Pe : MonoBehaviour
{
    public float speed = 5;

    public bool idou;

    public float pos;

    public int takohp = 5;

    float startpos;

    



    private void Start()
    {
        idou = true;

        startpos = this.gameObject.transform.position.x;

        
    }

    void Update()
    {
        if (idou == true)
        {
            this.transform.position += new Vector3(Time.deltaTime * -speed, 0, 0);
        }      

        //ポジション到着
        if (startpos + pos >= this.gameObject.transform.position.x)
        {
            idou = false;
        }


        //解除
        if (takohp <= 0)
        {
            ControllerPe.score = ControllerPe.score + 50;
            ControllerPe.takoon = false;
            this.transform.position += new Vector3(Time.deltaTime * speed * 2, 0, 0);
            if (startpos <= this.gameObject.transform.position.x)
            {

                Destroy(this.gameObject);
            }
        }


    }

    //クリック
    public void Tako2Click(BaseEventData date)
    {       
            takohp--;              
    }

}
