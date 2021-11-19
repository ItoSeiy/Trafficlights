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
    [SerializeField] float _normalSceneChangeTime = 4.5f;
    [SerializeField] float _systemSceneChangeTime = 5f;

    [SerializeField] GameObject[] _insertDestroyObject;
    [SerializeField] GameObject _slideInsert;
    [SerializeField] GameObject _sprayInsert;
    [SerializeField] GameObject _escapeInsert;
    [SerializeField] GameObject _systemInsert;

    //public void TitleBackButton()
    //{
    //    Invoke("Title", _sceneChangeTime);
    //}
    public void PenguinSlideButton()
    {
        Invoke("PenguinSlide", _normalSceneChangeTime);
        Insert("PenguinSlide");
    }
    public void PenguinSprayButton()
    {
        Invoke("PenguinSpray", _normalSceneChangeTime);
        Insert("PenguinSpray");
    }
    /*public void PenguinEscapeButton()
    {
        Invoke(_penguinEscape, _sceneChangeTime);
    }*/
    public void PenguinSystemButton()
    {
        Invoke("PenguinSystem", _systemSceneChangeTime);
        Insert("PenguinSystem");
    }

    private void Insert(string sceneName)
    {
        switch(sceneName)
        {
            case "PenguinSlide":
                Invoke("SlideInsert", 1f);
                break;
            case "PenguinSpray":
                Invoke("SprayInsert", 1f);
                break;
            case "PenguinSystem":
                Invoke("SystemInsert", 1f);
                break;
        }    
    }
    private void SlideInsert()
    {
        foreach (var g in _insertDestroyObject)
        {
            Destroy(g);
        }
        _slideInsert.SetActive(true); 
    }
    private void SprayInsert() 
    {
        foreach (var g in _insertDestroyObject)
        {
            Destroy(g);
        }
        _sprayInsert.SetActive(true); 
    }
    private void SystemInsert() 
    {
        foreach (var g in _insertDestroyObject)
        {
            Destroy(g);
        }
        _systemInsert.SetActive(true); 
    }

    //private void Title()
    //{
    //    SceneManager.LoadScene(_titleScene);
    //}
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
    private void PenguinSystem()
    {
        SceneManager.LoadScene(_penguinSystem);
    }
}
