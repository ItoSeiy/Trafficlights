using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPenguinMove_Pr : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ペンギンのリジットボディ</summary>
    [SerializeField] Rigidbody2D m_rb = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    void Start()
    {
    }
    void Update()
    {
        //タッチ入力を受け取る
        Touch();
    }
    void Touch()
    {
        if (Input.touchCount < 0) return;

        //マルチタッチに対応させるためにforeachで回す
        foreach (var t in Input.touches)
        {

            switch (t.phase)
            {
                case TouchPhase.Stationary:
                    if (t.position.x < Screen.width / 2 && this.tag == "LeftTouch")
                    {
                        m_rb.AddForce(Vector2.left * m_movePower);
                    }
                    else if (t.position.x > Screen.width / 2 && this.tag == "RightTouch")
                    {
                        m_rb.AddForce(Vector2.right * m_movePower);
                    }
                    break;
            }
        }
    }
}
