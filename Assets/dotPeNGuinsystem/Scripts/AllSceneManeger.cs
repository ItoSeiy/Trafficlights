using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneManeger : MonoBehaviour
{
    [SerializeField] string _titleScene;
    [SerializeField] string _slectScen;
    [SerializeField] string _penguinSlide;
    [SerializeField] string _penguinSpray;
    public void TitleBack()
    {
        SceneManager.LoadScene(_titleScene);
    }
}
