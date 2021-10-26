using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解像度を管理するスクリプト
/// </summary>
public class Resolution_Ps : MonoBehaviour
{
    public int ScreenWidth;
    public int ScreenHeight;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.Android ||
        Application.platform == RuntimePlatform.IPhonePlayer ||
        Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Screen.SetResolution(ScreenWidth, ScreenHeight, false);
        }
    }
}