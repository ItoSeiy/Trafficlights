using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// RaycastとOverlapCircleを管理するスクリプト
/// </summary>
public class Ray_Ps : MonoBehaviour
{
    /// <summary>RayCastを当てるレイヤー</summary>
    [SerializeField] LayerMask m_layerMask = 1;
    /// <summary>Rayを飛ばす距離</summary>
    [SerializeField] float m_rayDistance = 10;
    /// <summary>タッチ機能のオーバラップの半径</summary>
    [SerializeField] float m_overlapRadius = default;
    /// <summary>Cockroachをタッチした際に実行するイベント</summary>
    [SerializeField] UnityEvent m_cockroachTouch;
    /// <summary>Skunkをタッチした際に実行するイベント</summary>
    [SerializeField] UnityEvent m_skunkTouch;
    /// <summary>Loafersにタッチした際に実行するイベント</summary>
    [SerializeField] UnityEvent m_loaferstouch;
    [SerializeField] AudioSource m_audioSource;
    void Update()
    {
        Touch();
        Click();
    }
    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_audioSource.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ヒット判定にPysics2D.Raycastを使用
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, m_rayDistance, m_layerMask);
            Debug.DrawRay(ray.origin, ray.direction * m_rayDistance, Color.green, 0, false);

            if (hit.collider)
            {
                if (hit.collider.tag == "Cockroach")
                {
                    var gj = hit.transform.GetChild(0).gameObject;
                    gj.SetActive(true);
                    m_cockroachTouch.Invoke();
                    StartCoroutine(StartWorkingRoutine(hit.collider));
                }
                else if (hit.collider.tag == "Skunk")
                {
                    var gj = hit.transform.GetChild(0).gameObject;
                    gj.SetActive(true);
                    m_skunkTouch.Invoke();
                    StartCoroutine(StartWorkingRoutine(hit.collider));
                }
                else if (hit.collider.tag == "Loafers")
                {
                    var gj = hit.transform.GetChild(0).gameObject;
                    gj.SetActive(true);
                    m_loaferstouch.Invoke();
                    StartCoroutine(StartWorkingRoutine(hit.collider));
                }
            }
        }
    }
    IEnumerator StartWorkingRoutine(Collider2D col)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(col.gameObject);

    }
    void Touch()
    {
        if (Input.touchCount < 0) return;

        //マルチタッチに対応させるためにforeachで回す
        foreach (var t in Input.touches)
        {
            m_audioSource.Play();
            Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);
            pos.z = 0;
            var cArray = Physics2D.OverlapCircleAll(pos, m_overlapRadius);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    foreach (var c in cArray)
                    {

                        if (c.tag == "Cockroach")
                        {
                            var gj = c.transform.GetChild(0).gameObject;
                            gj.SetActive(true);
                            m_cockroachTouch.Invoke();
                            StartCoroutine(StartWorkingRoutine(c));
                        }
                        else if (c.tag == "Skunk")
                        {
                            m_skunkTouch.Invoke();
                            StartCoroutine(StartWorkingRoutine(c));
                        }
                        else if (c.tag == "Loafers")
                        {
                            m_loaferstouch.Invoke();
                            StartCoroutine(StartWorkingRoutine(c));
                        }
                        //UnityEditor.Handles.DrawWireDisc(c.transform.position, Vector3.back, m_overlapRadius);
                    }
                    break;
            }
        }
    }
}