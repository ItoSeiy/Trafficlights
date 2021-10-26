using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// まっすぐ下に移動し、プレイヤーに近づいたらその方向に曲げるように動かすコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObjectCurveToPlayer_Ps : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float m_speed = 1f;
    /// <summary>プレイヤーよりどれくらい上で動きを変化するか</summary>
    [SerializeField] float m_playerOffsetY = 5f;
    /// <summary>カーブする時にかける力</summary>
    [SerializeField] float m_chasingPower = 1f;
    Rigidbody2D m_rb;
    GameObject m_player;
    /// <summary>曲がる方向</summary>
    float m_x = 0f;

    void Start()
    {
        // まずまっすぐ下に移動させる
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.velocity = Vector2.down * m_speed;

        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // プレイヤーがいない時は何もしない
        if (m_player)
        {
            // プレイヤーとある程度近づいたら
            if (this.transform.position.y - m_player.transform.position.y < m_playerOffsetY)
            {
                // 左右どちらに曲がるか判定する
                if (m_x == 0)
                {
                    m_x = (m_player.transform.position.x > this.transform.position.x) ? 1 : -1;   // m_x = 1 => 右方向、m_x = -1 => 左方向を「三項演算子」を使って計算している
                }

                // カーブする
                m_rb.AddForce(m_x * Vector2.right * m_chasingPower);
            }
        }
    }
}