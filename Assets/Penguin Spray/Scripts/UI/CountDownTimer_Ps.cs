
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
/// <summary>
/// タイマーを管理するスクリプト
/// </summary>
public class CountDownTimer_Ps : MonoBehaviour
{
	/// <summary>
	/// すべての敵を破棄したかどうかを管理するプロパティ
	/// </summary>
	public bool AllEnemiesDestroyed
    {
        get { return m_allEnemiesDestroyed; }
		set { m_allEnemiesDestroyed = value; }
    }
	/// <summary>トータル制限時間</summary>
	private float m_totalTime;
	///<summary>制限時間(分)</summary>
	[SerializeField] private int m_minute;
	/// <summary>制限時間(秒)</summary>
	[SerializeField] private float m_seconds;
	/// <summary>前回Update時の秒数</summary>
	private float m_oldSeconds;
	/// <summary>タイマーのテキスト</summary>
	[SerializeField] TextMeshProUGUI m_timerText;
	/// <summary>タイムアップのUI</summary>
	[SerializeField] GameObject m_timeUpUI;
	/// <summary>UIのキャンバス</summary>
	[SerializeField] GameObject m_canvas;
	/// <summary>タイムアップになった時に行うイベント</summary>
	[SerializeField] UnityEvent m_timeUpEvent = default;
	/// <summary>すべての敵が破棄されたかどうかを判定するフラグ</summary>
	private bool m_allEnemiesDestroyed;
	void Start()
	{
		m_totalTime = m_minute * 60 + m_seconds;
		m_oldSeconds = 0f;
	}

	void Update()
	{
		//すべての敵を破棄したらタイマーのカウントダウンを行わない
		if (m_allEnemiesDestroyed) return;

		TimerCountDown();
	}
	private void TimerCountDown()
    {
		//　制限時間が0秒以下なら何もしない
		if (m_totalTime <= 0f)
		{
			return;
		}
		//　一旦トータルの制限時間を計測；
		m_totalTime = m_minute * 60 + m_seconds;
		m_totalTime -= Time.deltaTime;

		//　再設定
		m_minute = (int)m_totalTime / 60;
		m_seconds = m_totalTime - m_minute * 60;

		//　タイマー表示用UIテキストに時間を表示する
		if ((int)m_seconds != (int)m_oldSeconds)
		{
			m_timerText.text = m_minute.ToString("00") + ":" + ((int)m_seconds).ToString("00");
		}
		m_oldSeconds = m_seconds;
		//　制限時間以下になったら敵のみをDestroysし、TimeUPのUIを生成する
		if (m_totalTime <= 0f)
		{
			m_timeUpEvent.Invoke();
			m_timeUpUI = Instantiate(m_timeUpUI, new Vector3(0, 0, 0), Quaternion.identity);
			m_timeUpUI.transform.SetParent(m_canvas.transform, false);
		}
    }
}

