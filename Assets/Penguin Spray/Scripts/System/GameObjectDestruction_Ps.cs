using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面外に出たオブジェクトを破棄するためのコンポーネント。
/// 画面内 = "Finish" タグを追加したオブジェクトのトリガーの範囲
/// </summary>
[RequireComponent(typeof(Collision2D))]
public class GameObjectDestruction_Ps : MonoBehaviour
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