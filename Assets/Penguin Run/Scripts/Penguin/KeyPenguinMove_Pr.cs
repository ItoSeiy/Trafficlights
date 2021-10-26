using UnityEngine;

/// <summary>
/// ペンギンをキーボードで操作するスクリプト
/// </summary>
public class KeyPenguinMove_Pr : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField]  float m_movePower = 5f;
    /// <summary>リジットボディ</summary>
    Rigidbody2D  m_rb;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //キーボード入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(m_h, 0);
        m_rb.velocity = dir.normalized * m_movePower;
    }
}