using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移を管理するスクリプト
/// </summary>
public class SceneManeger_Pr : MonoBehaviour
{
    [SerializeField]private string m_titleScene;
    [SerializeField]private string m_penguinRunScene;
    public void TitleBack()
    {
        SceneManager.LoadScene(m_titleScene);
    }
    public void StartPenguinRun()
    {
        SceneManager.LoadScene(m_penguinRunScene);
    }

}
