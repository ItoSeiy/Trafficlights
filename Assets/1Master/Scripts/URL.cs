using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    public void HomePage()
    {
        Application.OpenURL("https://penguindrum10th.jp/");
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/penguindrum");
    }
}
