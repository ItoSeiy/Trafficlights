using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景を自動スクロールさせるスクリプト
/// </summary>
public class BackGround_Pr : MonoBehaviour
{
    /// <summary>背景のスプライト</summary>
    [SerializeField] SpriteRenderer m_backGround;
    /// <summary>スクロールスピード</summary>
    [SerializeField] float speed = 1;

    void Update()
    {
        //下方向にスクロール
        m_backGround.transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-11まで来れば、10まで移動する
        if (m_backGround.transform.position.y <= -11f)
        {
            m_backGround.transform.position = new Vector2(0,10f);
        }
    }
}