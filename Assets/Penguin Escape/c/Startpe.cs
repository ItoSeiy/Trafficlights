using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startpe : MonoBehaviour
{

    //ボタン
    public void OnClick()
    {
        SceneManager.LoadScene("selectscene");
    }
    
}
