using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// シーンの移動を管理するスクリプト
/// </summary>
public class SceneManeger_Ps : MonoBehaviour
{
    [SerializeField]private string m_titleScene;
    [SerializeField] private string m_penguinSprayScene;
    public void TitleBack()
    {
        SceneManager.LoadScene(m_titleScene);
    }
    public void StartPenguinSpray()
    {
        SceneManager.LoadScene(m_penguinSprayScene);
    }
}
