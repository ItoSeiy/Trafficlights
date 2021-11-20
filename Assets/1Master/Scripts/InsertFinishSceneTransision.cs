using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class InsertFinishSceneTransision : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] string _titileScene;
    private void Start()
    {
        _videoPlayer.loopPointReached += LoopPointReached;
        _videoPlayer.Play();
    }
    public void LoopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(_titileScene);
    }
}

