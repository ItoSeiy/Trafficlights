using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KuroPe : MonoBehaviour
{
    //黒いののやつ

    float speed;

    private void Start()
    {

        Debug.Log("黒　出現");
    }

    void Update()
    {
        speed = ControllerPe.allspeed;

        this.transform.position += new Vector3(Time.deltaTime * -speed, 0, 0);

        if (transform.position.x <= -4)
        {
            Destroy(this.gameObject);
        }
    }

    //クリック
    public void KuroClick(BaseEventData date)
    {   
        if (ControllerPe.takoon == false)
        {
            ControllerPe.score = ControllerPe.score + 500;
            Destroy(this.gameObject);
        }
    }
}
