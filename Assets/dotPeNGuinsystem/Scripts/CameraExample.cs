using UnityEngine;
using UnityEngine.UI;

public class CameraExample : MonoBehaviour
{
    // シーンに配置してある RawImage
    public RawImage m_image;
    public int m_maxSize =1920;
    public Button button;
    public void OnClick()
    {

        // まだカメラにアクセスできない場合スキップ
        if (NativeCamera.IsCameraBusy()) return;

        // 最大 512 pixel のサイズで写真を撮影
        NativeCamera.TakePicture(OnTake, m_maxSize);
    }

    // 撮影後に呼び出される
    private void OnTake(string path)
    {
        // 撮影されていない場合スキップ
        if (string.IsNullOrEmpty(path)) return;

        // 撮影した写真のテクスチャ情報を取得
        var texture = NativeCamera.LoadImageAtPath(path, m_maxSize);

        // 取得したテクスチャをシーンの RawImage に設定
        m_image.texture = texture;
    }
}