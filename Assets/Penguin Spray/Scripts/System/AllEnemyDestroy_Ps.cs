using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 生成されている敵のオブジェクトをすべて破棄スクリプト
/// </summary>
public class AllEnemyDestroy_Ps : MonoBehaviour
{
    public void AllEnemyDeastroy()
    {
        GameObject[] cockroachObjects = GameObject.FindGameObjectsWithTag("Cockroach");
        GameObject[] skunkObjects = GameObject.FindGameObjectsWithTag("Skunk");
        GameObject[] loafersObjects = GameObject.FindGameObjectsWithTag("Loafers");

        foreach (var c in cockroachObjects)
            Destroy(c);
        foreach (var s in skunkObjects)
            Destroy(s);
        foreach (var l in loafersObjects)
            Destroy(l);
    }
}
