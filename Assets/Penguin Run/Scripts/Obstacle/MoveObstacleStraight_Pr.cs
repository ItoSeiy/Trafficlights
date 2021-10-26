using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物をまっすぐ一方向に移動させるスクリプト
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObstacleStraight_Pr : MonoBehaviour
{
    /// <summary>移動する方向</summary>
    [SerializeField] Vector2 m_direction = Vector2.down;
    Rigidbody2D m_rb;

    void Start()
    {
    }
    public void OnInstantiate(float speed)
    {
        m_rb = GetComponent<Rigidbody2D>();
        // 指定した方向に指定した速度で動かす
        m_rb.velocity = m_direction.normalized * speed;
    }
}
