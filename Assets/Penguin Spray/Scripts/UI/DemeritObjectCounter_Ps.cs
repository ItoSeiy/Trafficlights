using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// タッチしてはいけないオブジェクトをタッチした回数をカウントしそれに応じて処理を呼び出す
/// タッチした回数をテキストに表示するスクリプト
/// </summary>
public class DemeritObjectCounter_Ps : MonoBehaviour
{
    /// <summary>タッチしてはいけないオブジェクトをタッチしたらゲームオーバになる回数</summary>
    [SerializeField, Tooltip("何回ローファーをタッチしたらゲームオーバーになるか")] 
    private int m_touchesGameOver;
    /// <summary>タッチしてはいけないオブジェクトをタッチした回数</summary>
    private int m_demeritObjectTouchCount;
    /// <summary>タッチしてはいけないオブジェクトをタッチした回数のテキスト</summary>
    [SerializeField] TextMeshProUGUI m_demeritObjectTouchCountText;
    /// <summary>タッチしてはいけないオブジェクトをタッチしたら実行するイベント</summary>
    [SerializeField] UnityEvent m_demeritObjectTouchEvent;
    void Update()
    {
        m_demeritObjectTouchCountText.text = "ローファー:" + m_demeritObjectTouchCount.ToString() +"/" + m_touchesGameOver.ToString();
    }
    public void DemeritObjectTouchCount()
    {
        m_demeritObjectTouchCount++;

        //一定数タッチしてはいけないオブジェクトをタッチしたら実行する
        if (m_touchesGameOver <= m_demeritObjectTouchCount)
        {
            m_demeritObjectTouchEvent.Invoke();
        }
    }
}
