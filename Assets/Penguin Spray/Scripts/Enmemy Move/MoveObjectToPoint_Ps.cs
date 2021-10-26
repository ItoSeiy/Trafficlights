using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定した場所に向かって移動するコンポーネント
/// </summary>
public class MoveObjectToPoint_Ps : MonoBehaviour
{
    /// <summary>移動先の座標</summary>
    [SerializeField] Vector3 m_targetPosition = Vector3.zero;
    /// <summary>移動速度</summary>
    [SerializeField] float m_speed = 1f;
    /// <summary>移動先にこの距離まで近づいたら、移動をやめる（メートル）</summary>
    [SerializeField] float m_stoppingDistance = 0.05f;

    void Update()
    {
        if (Vector2.Distance(this.transform.position, m_targetPosition) > m_stoppingDistance)
        {
            Vector2 dir = m_targetPosition - this.transform.position;
            this.transform.Translate(dir.normalized * m_speed * Time.deltaTime);
        }
    }
}
