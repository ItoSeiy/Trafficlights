using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ペンギンが障害物に当たったら破棄するスクリプト
/// </summary>
public class PenguinDestroy_Pr : MonoBehaviour
{
    /// <summary>無敵モードを判定するフラグのプロパティ</summary>
    public bool InvicivleMode
    {
        get { return m_invicibleMode; }
        set { m_invicibleMode = value; }
    }
    /// <summary>ゲームオーバー時に実行するイベント</summary>
    [SerializeField] UnityEvent m_destoroyEvents;
    /// <summary>無敵モードを判定するフラグ</summary>
    private bool m_invicibleMode;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_invicibleMode) return;//無敵モードだった時点で処理を終わる

        if (collision.tag == "Obstacle")
        {
            Destroy(this.gameObject);
            m_destoroyEvents.Invoke();
        }
    }
}
