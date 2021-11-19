using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ScreenShotScript : MonoBehaviour
{

	[SerializeField]
	private GameObject ShotButton;
	//　スクリーンショットボタン
	[SerializeField]
	private GameObject screenShotButton;
	//　ログパネル
	[SerializeField]
	private Text logPanel;
	[SerializeField]
	private float waitTime = 5f;
	//　データの保存先ファイルパス
	private string saveFilePath = "/Projects/ScreenShot";
	//　保存ファイル名
	private string saveFileName = "/dotPNGsystem.PNG";

	void Start()
	{

		//　指定したフォルダがない時はAssetsフォルダに保存
		//if (!Directory.Exists(Application.persistentDataPath + saveFilePath))
		//{
		//	saveFilePath = "";
		//}
	}

	//　スクリーンショットボタンを押す
	public void OnScreenShot()
	{
		StartCoroutine(OperationUI());
	}

	//　スクリーンショット処理
	IEnumerator OperationUI()
	{
		ScreenCapture.CaptureScreenshot(Application.persistentDataPath + saveFilePath + saveFileName);

		//　待ち時間を入れないとlogPanelが表示されるので一定時間待つ
		yield return new WaitForSeconds(0.1f);
		yield return new WaitForSeconds(waitTime);
		logPanel.text = "スクリーンショットを撮りました！\n" + Application.persistentDataPath + saveFilePath + saveFileName + " に保存されました。";
		//　スクリーンショットを撮った旨を表示

	}
	//　画面サイズをテキストに表示
	//public void ChangeSuperSizeText(Single value)
	//{
	//	superSizeText.text = value.ToString();

}
