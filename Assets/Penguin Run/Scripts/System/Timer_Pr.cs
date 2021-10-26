using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// カウントアップするタイマーを管理するスクリプト
/// </summary>
public class Timer_Pr : MonoBehaviour
{
	/// <summary>タイマー表示用テキスト</summary>
	[SerializeField]TextMeshProUGUI m_timerText;
	[SerializeField]private int m_minute;
	[SerializeField]private float m_seconds;
	/// <summary>前のUpdateの時の秒数</summary>
	private float m_oldSeconds;

	void Start()
	{
		m_minute = 0;
		m_seconds = 0f;
		m_oldSeconds = 0f;
	}

	void Update()
	{
		Timer();
	}
	public void Timer()
    {
		m_seconds += Time.deltaTime;
		if (m_seconds >= 60f)
		{
			m_minute++;
			m_seconds = m_seconds - 60;
		}
		//　値が変わった時だけテキストUIを更新
		if ((int)m_seconds != (int)m_oldSeconds)
		{
			m_timerText.text = m_minute.ToString("00") + ":" + ((int)m_seconds).ToString("00");
		}
		m_oldSeconds = m_seconds;
    }
}