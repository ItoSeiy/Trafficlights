using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// スコアの変数を集約、管理するスクリプト
/// </summary>
public class ScoreManeger_Ps : MonoBehaviour
{
    /// <summary>点数を管理するプロパティ</summary>
    public int Score
    {
        get { return m_score; }
        set { m_score += value; }
    }
    [SerializeField] TextMeshProUGUI m_scoreText;
    private int m_score;
    void Start()
    {
        m_score = 0;
    }
    void Update()
    {
        m_scoreText.text = "スコア:" + m_score.ToString();
    }
}
