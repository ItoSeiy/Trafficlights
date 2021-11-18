using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPe : MonoBehaviour
{

    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = ControllerPe.score.ToString();
    }
    
    //ボタン
    public void mainClick()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void OnClick()
    {
        SceneManager.LoadScene("mainScene");
    }
}
