using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TouchManager : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_moveSpeed = 5f;
    /// <summary>ペンギンのリジットボディ</summary>
    [SerializeField] Rigidbody2D m_rb = default;
    Dictionary<int, Touch> m_fingers = new Dictionary<int, Touch>();

    void Update()
    {
        //タッチ入力を受け取る
        Touch();
    }

    void Touch()
    {
        if (m_rb == null) return;

        //マルチタッチに対応させるためにforeachで回す
        foreach (var t in Input.touches)
        {
            switch (t.phase)
            {
                case TouchPhase.Began:
                    m_fingers.Add(t.fingerId, t);
                    break;
                case TouchPhase.Ended:
                    m_fingers.Remove(t.fingerId);
                    break;
                case TouchPhase.Canceled:
                    m_fingers.Remove(t.fingerId);
                    break;
            }
        }

        if (m_fingers.Count == 1)
        {
            if (m_fingers.FirstOrDefault().Value.position.x < Screen.width / 2)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        else
        {
            Stop();
        }
    }

    void MoveLeft()
    {
        m_rb.velocity = Vector2.left * m_moveSpeed;
    }

    void MoveRight()
    {
        m_rb.velocity = Vector2.right * m_moveSpeed;
    }

    void Stop()
    {
        m_rb.velocity = Vector2.zero;
    }
}
