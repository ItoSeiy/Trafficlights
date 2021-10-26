using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをまっすぐ一方向に移動させる
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObjectStraight_Ps : MonoBehaviour
{
    /// <summary>移動する方向</summary>
    [SerializeField] Vector2 m_direction = Vector2.down;
    /// <summary>移動する速度</summary>
    [SerializeField] float m_speed = 1.5f;
    Rigidbody2D m_rb;
    private void OnEnable()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // 指定した方向に指定した速度で動かす
        m_rb.velocity = m_direction.normalized * m_speed;
    }
}