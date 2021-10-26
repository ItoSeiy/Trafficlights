using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
///Enemyを一定確率で生成するスクリプト
///また一定確率では別のところにSkunkが再生成される
/// </summary>
public class RandomEnemyGenerator_Ps : MonoBehaviour
{
    /// <summary>タイムアップを管理するプロパティ</summary>
    public bool TimeUp
    {
        get { return m_timeUp; }
        set { m_timeUp = value; }
    }
    /// <summary>生成するプレハブの配列</summary>
    [SerializeField] GameObject[] m_enemy = null;
    /// <summary>敵を生成する位置として設定するオブジェクト</summary>
    [SerializeField] Transform m_spawnPoint = null;
    /// <summary>敵の生成間隔（秒）(ただしランダム) </summary>
    [SerializeField] float m_randomSpawnInterval = 2f;
    /// <summary>１ウェーブ内での m_spawnIntervalInWave をカウントするためのカウンター</summary>
    float m_timer;
    /// <summary>Skunk又はLoafersが生成される確率</summary>
    [SerializeField, Range(0 , 100)] int m_probability;
    [SerializeField, Range(0 , 100)] int m_warpeProbability = default;
    [SerializeField] UnityEvent m_warpe = default;
    /// <summary>時間切れを判定するフラグ/// </summary>
    private bool m_timeUp = false;
    /// <summary>SkunkかLoafersを生成させるIndex</summary>
    int m_randomObjectIndex;

    /// <summary>一定確率でEnemyを生成させるための乱数</summary>
    private int m_random;
    /// <summary>一定確率でEnemyをワープさせるための乱数</summary>
    private int m_random2;
    void Update()
    {
        if (m_timeUp)
            return;

        RandomWarp();
    }
    public void RandomWarp()
    {
        // ウェーブ内で敵の生成間隔を待つ
        m_timer += Time.deltaTime;
        if (m_timer > m_randomSpawnInterval)
        {
            m_random = Random.Range(0, 100);
            m_random2 = Random.Range(0, 100);
            Debug.LogFormat("Enemy Warpe Probability value: {0}", m_random);
            m_timer = 0;
            //一定確率でスカンク又はローファーを生成する
            if (m_random <= m_probability)
            {             
                m_randomObjectIndex = Random.Range(0, m_enemy.Length);
                GameObject m_go = Instantiate(m_enemy[m_randomObjectIndex]);
                m_go.transform.position = m_spawnPoint.position;

            }
            else if(m_random2 <= m_warpeProbability)
            {
                m_warpe.Invoke();
            }
        }
    }
}
