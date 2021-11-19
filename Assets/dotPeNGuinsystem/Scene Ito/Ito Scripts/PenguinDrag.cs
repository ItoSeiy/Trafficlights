using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenguinDrag : MonoBehaviour, IDragHandler
{
	public void OnDrag(PointerEventData data)
	{
		transform.position = data.position;
		//Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
		//TargetPos.z = 0;
		//transform.position = TargetPos;
	}
}
