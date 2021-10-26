using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ゲームオーバーを実行するスクリプト
/// </summary>
public class GameOver_Pr : MonoBehaviour
{
    /// <summary>ゲームオーバーのUI</summary>
    [SerializeField] GameObject m_gameOverUI;
    /// <summary>UIのキャンバス</summary>
    [SerializeField] GameObject m_canvas;
    /// <summary>タイマーのUI</summary>
    [SerializeField] GameObject m_timer;
    /// <summary>ゲームオーバーの際に実行するイベント</summary>
    [SerializeField] UnityEvent m_gameOverEvent;
    /// <summary>
    /// ゲームオーバーのUIを生成
    /// 敵の生成、タイマー、背景の動きを止める関数
    /// </summary>
    public void GameOver()
    {
        //ゲームオーバーのUIをCanvas上に生成する
        m_gameOverUI = Instantiate(m_gameOverUI, new Vector3(0, 0, 0), Quaternion.identity);
        m_gameOverUI.transform.SetParent(m_canvas.transform, false);
        //ゲームオーバUIの子オブジェクトにタイマーを追加する
        m_timer.transform.parent = m_gameOverUI.transform;
        //インスペクター上にセットした処理を実行する
        m_gameOverEvent.Invoke();
    }
}
