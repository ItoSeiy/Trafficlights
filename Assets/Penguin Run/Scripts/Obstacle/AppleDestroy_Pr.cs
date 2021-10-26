using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AppleがPlayerにぶつかった時にAppleを破棄するスクリプト
/// </summary>
public class AppleDestroy_Pr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(this.gameObject);
    }
}
