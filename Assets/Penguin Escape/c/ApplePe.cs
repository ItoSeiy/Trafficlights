using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApplePe : MonoBehaviour
{
    //リンゴ降下用

    float speed;

    private void Start()
    {
        Debug.Log("リンゴ　出現");
    }

    void Update()
    {
        speed = ControllerPe.allspeed;

        this.transform.position += new Vector3(0, Time.deltaTime * -speed, 0);

        if (transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
    }

    //クリック
    public void AppleClick(BaseEventData date)
    {
        ControllerPe.score = ControllerPe.score + 1000;
        Destroy(this.gameObject);
    }
}
