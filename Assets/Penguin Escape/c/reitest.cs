using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reitest : MonoBehaviour
{
    //使ってないです


    [SerializeField] LayerMask m_layerMask = 1;
    [SerializeField] float m_rayDistance = 10;
    [SerializeField] float m_overlapRadius = default;
    void Update()
    {
        TouchTest();
        Click();
    }
    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ヒット判定にPysics2D.Raycastを使用
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, m_rayDistance, m_layerMask);
            //Debug.DrawRay(ray.origin, ray.direction * m_rayDistance, Color.green, 0, false);

            if (hit.collider)
            {
                Destroy(hit.collider.gameObject);

                if (hit.collider.tag == "Cockroach")
                    Debug.Log("Cockroachです");
                else if (hit.collider.tag == "Skunk")
                    Debug.Log("Skunkです");
                else if (hit.collider.tag == "Loafers")
                    Debug.Log("Loafersです");

                if(hit.collider.tag =="tako")
                {

                }
            }
        }
    }
    void TouchTest()
    {
        if (Input.touchCount < 0) return;

        foreach (var t in Input.touches)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);
            pos.z = 0;
            var cArray = Physics.OverlapSphere(pos, m_overlapRadius);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    foreach (var c in cArray)
                    {


                        if (c.tag == "Rope")
                            Destroy(this.gameObject); 
                        else if (c.tag == "apple")
                            Destroy(this.gameObject);
                        else if (c.tag == "black")
                            Destroy(this.gameObject);
                        //UnityEditor.Handles.DrawWireDisc(c.transform.position, Vector3.back, m_overlapRadius);
                    }

                    break;
            }
        }
    }
}
