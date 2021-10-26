using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物が画面外にでたら破棄するスクリプト
/// </summary>
[RequireComponent(typeof(Collision2D))]
public class ObstacleDestroy_Pr : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        // ゲームの範囲から出たら消える
        if (collision.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
