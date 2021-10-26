using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物を生成、破壊するスクリプト
/// </summary>
public class ObstacleManeger_Pr : MonoBehaviour
{
    /// <summary>ウエーブとして生成するプレハブの配列</summary>
    [SerializeField] GameObject[] m_obstaclePrefabs = null;
    /// <summary>敵を生成する位置として設定するオブジェクト</summary>
    [SerializeField] Transform m_spawnPoint = null;
    /// <summary>敵のスピードの初期値</summary>
    [SerializeField] float m_initialObstacleMoveSpeed;
    /// <summary>障害物が動くスピード(引数)</summary>
    private float m_obstacleMoveSpeed;
    /// <summary>障害物が生成されたときのカウンター変数</summary>
    private int m_spawnCounter;
    /// <summary>障害物の添え字</summary>
    int m_randomObstacleIndex;
    private void OnEnable()
    {
        m_obstacleMoveSpeed = m_initialObstacleMoveSpeed;
        ObstacleGeneration();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Parent")
            ObstacleGeneration();
    }
    public void ObstacleGeneration()
    {
        // 生成するプレハブの添え字を出力する
        Debug.LogFormat("Obstacle Index: {0}", m_randomObstacleIndex);

        //生成するオブジェクトの添え字を乱数で決める
        m_randomObstacleIndex = Random.Range(0, m_obstaclePrefabs.Length);

        // 敵を生成する
        GameObject go = Instantiate(m_obstaclePrefabs[m_randomObstacleIndex]);
        go.transform.position = m_spawnPoint.position;

        //スポーンのカウンター変数をカウントアップする
        m_spawnCounter++;
        Debug.LogFormat("Spawan count: {0}", m_spawnCounter);

        //スポーンされた回数が5の倍数の時に障害物の移動スピードを上げる
        if(m_spawnCounter % 5 == 0 )
        {
            m_obstacleMoveSpeed++;
            Debug.Log("Obstacle Speed UP");
            Debug.LogFormat("Obsttacle Move Speed: {0}", m_obstacleMoveSpeed);
        }

        //障害物を取得して生成する
        GameObject[] obstacleObjects = GameObject.FindGameObjectsWithTag("Parent");
        foreach(var o in obstacleObjects)
        {
            MoveObstacleStraight_Pr moveObstacle = o.GetComponent<MoveObstacleStraight_Pr>();
            moveObstacle.OnInstantiate(m_obstacleMoveSpeed);
        }
    }
    /// <summary>
    /// ゲームシーン内にいる障害物をすべて破棄する
    /// </summary>
    public void  AllObstacleDestroy()
    {
        GameObject[] obstacaleObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] appleObjects = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var o in obstacaleObjects)
            Destroy(o);
        foreach (var a in appleObjects)
            Destroy(a);
    }
}
