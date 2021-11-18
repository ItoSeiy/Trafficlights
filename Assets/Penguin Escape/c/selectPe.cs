using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class select : MonoBehaviour
{
    //難易度

    public void OnClick1()
    {
        ControllerPe.allspeed = 3.0f;
        ControllerPe.scoreup = 1.0f;
        SceneManager.LoadScene("mainScene");

    }

    public void OnClick2()
    {
        ControllerPe.allspeed = 4.0f;
        ControllerPe.scoreup = 1.25f;
        SceneManager.LoadScene("mainScene");
    }

    public void OnClick3()
    {
        ControllerPe.allspeed = 4.5f;
        ControllerPe.scoreup = 1.5f;
        SceneManager.LoadScene("mainScene");
    }
}
