﻿using UnityEngine;  
using System.IO;  
using System.Collections;  
using SocialConnector;  
using UnityEngine.UI;  
  
public class ShareController : MonoBehaviour  
{  
    public void Share()  
    {  
        StartCoroutine(_Share());  
    }  
  
    public IEnumerator _Share()
    {
        string imgPath = Application.persistentDataPath + "/image.png";

        // 前回のデータを削除
        File.Delete(imgPath);

        //スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot("image.png");

        // 撮影画像の保存が完了するまで待機
        while (true)
        {
            if (File.Exists(imgPath)) break;
            yield return null;
        }

        // 投稿する
        string tweetText = "テレビアニメ輪るピングドラムのゲーム「Penguin Actions」で撮ったよ！　生存戦略、しましょうか。";
        string tweetURL = "公式ホームページ　https://penguindrum10th.jp/"　+ "公式ツイッター https://twitter.com/penguindrum" +  "(ゲームURL)";
        SocialConnector.SocialConnector.Share(tweetText, tweetURL, imgPath);
    }
}