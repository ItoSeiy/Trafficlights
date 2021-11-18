using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazurePe : MonoBehaviour
{

    //抽選外れ用
    void Start()
    {
        if (this.gameObject.CompareTag("apple"))
        {
            Debug.Log("リンゴ　抽選外れ");
        }
        if (this.gameObject.CompareTag("black"))
        {
            Debug.Log("黒　抽選外れ");
        }
        Destroy(this.gameObject);
    }
}
