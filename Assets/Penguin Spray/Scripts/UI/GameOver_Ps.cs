using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ゲームオーバーを実行するスクリプト
/// </summary>
public class GameOver_Ps : MonoBehaviour
{
    /// <summary>ゲームオーバーのUI</summary>
    [SerializeField] GameObject m_gameOverUI;
    /// <summary>UIのキャンバス</summary>
    [SerializeField] GameObject m_canvas;
    /// <summary>ゲームオーバーの際に実行するイベント</summary>
    [SerializeField] UnityEvent m_gameOverEvent;
    /// <summary>
    /// ゲームオーバーのUIを生成
    /// 敵の生成とタイマーを止める関数
    /// </summary>
    public void GameOver()
    {
        m_gameOverUI = Instantiate(m_gameOverUI, new Vector3 (0,0,0) , Quaternion.identity);
        m_gameOverUI.transform.SetParent(m_canvas.transform,false);
        m_gameOverEvent.Invoke();
    }
}
