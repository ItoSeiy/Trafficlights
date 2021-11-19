using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ScreenShotScript : MonoBehaviour
{

	//　スクリーンショットボタン
	[SerializeField]
	private GameObject screenShotButton;
	//　ログパネル
	[SerializeField]
	private GameObject logPanel;
	//　スクリーンショットを撮ってからの待ち時間
	[SerializeField]
	private float waitTime = 5f;
	//　データの保存先ファイルパス
	private string saveFilePath = "/Projects/dotPeNGuinsystem";
	//　保存ファイル名
	private string saveFileName = "/PNGZONe.PNG";

	void Start()
	{
		//　UIの初期設定
		screenShotButton.SetActive(true);
		logPanel.SetActive(false);

		//　指定したフォルダがない時はAssetsフォルダに保存
		if (!Directory.Exists(Application.dataPath + saveFilePath))
		{
			saveFilePath = "";
		}
	}

	//　スクリーンショットボタンを押す
	public void OnScreenShot()
	{
		StartCoroutine(OperationUI());
	}

	//　スクリーンショット処理
	IEnumerator OperationUI()
	{
		//　スクリーンショットを撮る前にUIを全部非表示
		logPanel.SetActive(false);
		//　スクリーンショットを撮る
		ScreenCapture.CaptureScreenshot(Application.persistentDataPath + saveFilePath + saveFileName,1);
		//　待ち時間を入れないとlogPanelが表示されるので一定時間待つ
		yield return new WaitForSeconds(0.1f);
		logPanel.transform.GetChild(0).GetComponent<Text>().text = "スクリーンショットをトりマシタ！\n" + Application.persistentDataPath + saveFilePath + saveFileName + " にホゾンしていマス。";
		//　スクリーンショットを撮った旨を表示
		logPanel.SetActive(true);
		yield return new WaitForSeconds(waitTime);
		//　UIを元に戻す
		logPanel.SetActive(false);

	}

}
