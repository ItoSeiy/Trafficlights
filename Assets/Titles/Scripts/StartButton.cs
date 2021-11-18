using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    public Button Button;
    public Animation Roll;
    public float deleteTime;
    // Start is called before the first frame update
    public void OnClick()
    {
        Roll.Play();
        Destroy(Button,deleteTime);
    }
}

    // Update is called once per frame

