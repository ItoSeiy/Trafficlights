using UnityEngine;

public class Example : MonoBehaviour
{
    private void Update()
    {
        // 画面がタップされていない場合スキップ
        if (!Input.GetMouseButtonDown(0)) return;

        // まだカメラにアクセスできない場合スキップ
        if (NativeCamera.IsCameraBusy()) return;

    }

    // 撮影後に呼び出される
    private void OnRecord(string path)
    {
        // 撮影されていない場合スキップ
        if (string.IsNullOrEmpty(path)) return;
    }
}