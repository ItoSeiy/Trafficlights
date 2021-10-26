using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// スタートボタンを押したらカウントダウンを始め、ゲームを開始するスクリプト
/// </summary>
public class GameStartManeger_Ps : MonoBehaviour
{
    /// <summary>システムをまとめるゲームオブジェクト</summary>
    [SerializeField] GameObject m_systemObject;
    /// <summary>シーンに出ている敵のプレハブ</summary>
    [SerializeField] GameObject m_enemyPrefab;
    /// <summary>セットアクティブがFalseのUI</summary>
    [SerializeField] GameObject m_dynamicUI;
    /// <summary>ゲーム説明のUI</summary>
    [SerializeField] GameObject m_startExplanationUI;
    /// <summary>カウントダウンテキスト</summary>
    [SerializeField] TextMeshProUGUI m_startCountDownText;
    /// <summary>ボタンを押されてからゲームをスタートする時間</summary>
    [SerializeField] float m_startTime;
    /// <summary>シーンがロードされた際に行うイベント</summary>
    [SerializeField] UnityEvent m_sceneRoadEvents;
    /// <summary>スタートボタンが押された際に行うイベント</summary>
    [SerializeField] UnityEvent m_startButtonPushedEvent;

    /// <summary>カウントダウンタイマー</summary>
    private float m_countDownTimer;
    /// <summary>ボタンが押されたことを判定するフラグ</summary>
    private bool m_startButtonPusshed;
    void Start()
    {
        m_sceneRoadEvents.Invoke();
        //カウントダウンタイマーにスタートするまでの時間を代入する
        m_countDownTimer = m_startTime;
    }
    void Update()
    {
        //スタートボタンが押されていないとき　又は　タイマーが0秒になった時は実行しない
        if (!m_startButtonPusshed || m_countDownTimer <= 0f) return;

        //カウントダウンテキストを表示する
        m_startCountDownText.text = m_countDownTimer.ToString("F0");
        m_countDownTimer -= Time.deltaTime;
    }
    /// <summary>ボタンが押されたときに実行する</summary>
    public void StartButtonPushed()
    {
       m_startButtonPusshed = true;

        //m_startTimeの時間分たったら関数を実行する
        Invoke("GameStart", m_startTime);

        //説明UIを破棄する
        Destroy(m_startExplanationUI);
    }
    /// <summary>
    /// システムのオブジェクト、UIのアクティブをオンにする
    /// カウントダウンテキストを破棄する
    /// </summary>
    private void GameStart()
    {
        m_startButtonPushedEvent.Invoke();
        //カウントダウンUIを破棄
        Destroy(m_startCountDownText);
    }
}
