using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// アタッチされたCockroachを生成するスクリプト
/// </summary>
public class EnemyGenerator_Ps : MonoBehaviour
{
    /// <summary>タイムアップを判定するプロパティ</summary>
    public bool TimeUp
    {
        get { return m_timeUp; }
        set { m_timeUp = value; }
    }
    /// <summary>ウエーブとして生成するプレハブの配列</summary>
    [SerializeField] GameObject[] m_enemyPrefabs = null;
    /// <summary>敵を生成する位置として設定するオブジェクト</summary>
    [SerializeField] Transform m_spawnPoint = null;
    /// <summary>１ウェーブ内での敵プレハブの生成間隔（秒）</summary>
    [SerializeField] float m_spawnIntervalInWave = 2f;
    /// <summary>１ウェーブ内での m_spawnIntervalInWave をカウントするためのカウンター</summary>
    float m_timer;
    /// <summary時間切れか判定するフラグ</summary>
    bool m_timeUp;
    /// <summary>CockroachのIndex</summary>
    int m_randomObjectIndex;

    void Update()
    {
        if (m_timeUp)
            return; // ここで関数を抜ける

        // ウェーブ内で敵の生成間隔を待つ
        m_timer += Time.deltaTime;
        if (m_timer > m_spawnIntervalInWave)
        {
            // まだウェーブを生成し、タイマーをリセットして m_spawnCounter をカウントアップする
            m_timer = 0;
            Debug.LogFormat("Enemy Index: {0}", m_randomObjectIndex);

            m_randomObjectIndex = Random.Range(0, m_enemyPrefabs.Length);
            // 敵を生成する
            GameObject go = Instantiate(m_enemyPrefabs[m_randomObjectIndex]);
            go.transform.position = m_spawnPoint.position;
        }
    }
}
