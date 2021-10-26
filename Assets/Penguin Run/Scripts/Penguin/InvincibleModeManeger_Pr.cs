using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// 無敵モードを管理するスクリプト
/// </summary>
public class InvincibleModeManeger_Pr : MonoBehaviour
{
    /// <summary>スライダーのUI</summary>
    [SerializeField] Slider m_invincibleModeSlider;
    /// <summary>一度Appleに触れた時にスライダーを変更する値</summary>
    [SerializeField, Range(0, 100)] private float m_alppleOnTrigerSliderValue;
    /// <summary>無敵モードの時間</summary>
    [SerializeField] float m_invicivleTime;
    /// <summary>無敵モードのカウントダウンテキスト</summary>
    [SerializeField] TextMeshProUGUI m_invicibleModeCountDownText;
    ///<summary>無敵モードのカウントダウンタイマー</summary>
    private float m_invicibleModeCountDownTimer;
    /// <summary>無敵モード時に実行するイベント</summary>
    [SerializeField] UnityEvent m_inviciblemodeEvent;
    /// <summary>無敵モード解除時に実行するイベント</summary>
    [SerializeField] UnityEvent m_isNotinviciblemodeEvent;
    /// <summary>タイマー</summary>
    private float m_timer;
    /// <summary>無敵モードを判定するフラグ</summary>
    private bool m_isInvicibleMode;
    private void Update()
    {
        if (!m_isInvicibleMode) return; //無敵モードではないとき処理を終わる
       
        //無敵モードになったらカウントを始める
        m_timer += Time.deltaTime;

        // 無敵モードのカウントダウンをタイマーに代入し表示する
        m_invicibleModeCountDownTimer -= Time.deltaTime;
        m_invicibleModeCountDownText.text = "無敵時間残り:" + m_invicibleModeCountDownTimer.ToString("00");

        //無敵モードの時間が切れたら無敵モードを解除する
        if (m_timer >= m_invicivleTime)
        {
            m_isNotinviciblemodeEvent.Invoke();
            m_isInvicibleMode = false;
            m_timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            if (m_isInvicibleMode) return;
            //スライダーに変更する分の値を代入する
            m_invincibleModeSlider.value += m_alppleOnTrigerSliderValue;

            //スライダーが最大値に達したら無敵モードを起動する
            if (m_invincibleModeSlider.value == m_invincibleModeSlider.maxValue)
            {
                m_invincibleModeSlider.value = 0;
                m_invicibleModeCountDownTimer = m_invicivleTime;
                m_inviciblemodeEvent.Invoke();
                m_isInvicibleMode = true;
            }
        }   
    }
}
