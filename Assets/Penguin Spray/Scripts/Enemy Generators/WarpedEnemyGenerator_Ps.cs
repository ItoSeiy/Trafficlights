using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ワープしてきたEnemyをランダムで生成するかさらにワープするかを処理するスクリプト
/// </summary>
public class WarpedEnemyGenerator_Ps : MonoBehaviour
{
    /// <summary>生成するプレハブの配列</summary>
    [SerializeField] GameObject[] m_enemy = null;
    /// <summary>生成するプレハブのポジション</summary>
    [SerializeField] Transform m_spawnPoint = null;
    /// <summary>Enemyを生成する確率</summary>
    [SerializeField, Range(0, 100)] int m_probability;
    /// <summary>更にワープする際に実行するイベント</summary>
    [SerializeField] UnityEvent m_warpe = default;
    public void RomdomWarp()
    {
        int m_ramdom = Random.Range(0, 100);
        int m_randomObjectIndex = Random.Range(0, m_enemy.Length);
        if (m_ramdom <= m_probability)
        {
            GameObject m_go = Instantiate(m_enemy[m_randomObjectIndex]);
            m_go.transform.position = m_spawnPoint.position;
        }
        else
        {
            m_warpe.Invoke();
        }
    }
}
