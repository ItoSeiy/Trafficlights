using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// ゲームをスタート時のイベントを実行するスクリプト
/// </summary>
public class GameStartManeger_Pr : MonoBehaviour
{
    /// <summary>スタートボタンが押されたときのカウントダウンテキスト</summary>
    [SerializeField] TextMeshProUGUI m_startCountDouwnText;
    /// <summary>スタート時の説明UI</summary>
    [SerializeField] GameObject m_startExplanationUI;
    /// <summary>ボタンを押されてからゲームをスタートする時間</summary>
    [SerializeField] float m_startTime;
    /// <summary>シーンを読み込んだ時に実行するイベント</summary>
    [SerializeField] UnityEvent m_sceneRoadEvent;
    /// <summary>ゲームがスタートされた時に実行するイベント</summary>
    [SerializeField] UnityEvent m_gameStartEvent;
    /// <summary>スタートボタンが押されたときのカウントダウンタイマー</summary>
    private float m_countDownTimer;
    /// <summary>スタートボタンが押されたかどうかを判定するフラグ</summary>
    private bool m_startButtonPushed;
    private void Start()
    {
        //シーンが読み込まれた際に実行するイベントをインスペクター上に設定する
        m_sceneRoadEvent.Invoke();
        //カウントダウンタイマーにスタートするまでの時間を代入する
        m_countDownTimer = m_startTime;
    }
    void Update()
    {
        //スタートボタンが押されていないとき　又は　タイマーが0秒になった時は実行しない
        if (!m_startButtonPushed || m_countDownTimer <= 0) return;

        //カウントダウンテキストを表示する
        m_startCountDouwnText.text = m_countDownTimer.ToString("F0");
        m_countDownTimer -= Time.deltaTime;
    }
    public void StartButtonPushed()
    {
        m_startButtonPushed = true;
        //スタートボタンが押されたときに説明UIを破棄する
        Destroy(m_startExplanationUI);
        //スタート時間になったら関数を実行する
        Invoke("GameStart", m_startTime);
    }
    private void GameStart()
    {
        //ゲームスタート時にカウントダウンテキストを破棄する
        Destroy(m_startCountDouwnText);
        //ゲームスタート時に実行するイベントをインスペクター上に設定する
        m_gameStartEvent.Invoke();
    }
}
