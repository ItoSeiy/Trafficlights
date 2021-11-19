using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneManeger : MonoBehaviour
{
    [SerializeField] private string _titleScene;
    [SerializeField] private string _penguinSlide;
    [SerializeField] private string _penguinSpray;
    [SerializeField] private string _penguinEscape;
    [SerializeField] private string _penguinSystem;
    [SerializeField] float _sceneChangeTime = 5f;

    public void TitleBackButton()
    {
        Invoke("Title", _sceneChangeTime);
    }
    public void PenguinSlideButton()
    {
        Invoke("PenguinSlide", _sceneChangeTime);
    }
    public void PenguinSprayButton()
    {
        Invoke("PenguinSpray", _sceneChangeTime);
    }
    /*public void PenguinEscapeButton()
    {
        Invoke(_penguinEscape, _sceneChangeTime);
    }*/
    public void PenguinSystemButton()
    {
        Invoke("", _sceneChangeTime);
    }



    private void Title()
    {
        SceneManager.LoadScene(_titleScene);
    }
    private void PenguinSlide()
    {
        SceneManager.LoadScene(_penguinSlide);
    }
    private void PenguinSpray()
    {
        SceneManager.LoadScene(_penguinSpray);
    }
    /*private void PenguinEscape()
    {
        Debug.LogWarning("NoneScene");
        SceneManager.LoadScene(_penguinEscape);
    }*/
    private void MasterPenguinSystem()
    {
        SceneManager.LoadScene(_penguinSystem);
    }
}
