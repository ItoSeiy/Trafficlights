using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;
using System.Xml;

public class CameraPrev : MonoBehaviour
{
    public RawImage RawImage;
    public WebCamTexture webCam;

    private AndroidJavaObject _javaClass = null;
    private List<Vector2> _prevSizeList = new List<Vector2>();
    private List<List<Vector2>> _deviceList = new List<List<Vector2>>();
    private List<string> _devidList = new List<string>();
    private int[] _Orientation;
    private int _nowCamIDIndex;
    private int _nowCamSizeIndex;
    private Vector2 defaulRawImageSize;
    private WebCamDevice[] _devices;

    void Awake()
    {
        // Nativeライブラリの初期化
        _javaClass = new AndroidJavaObject("com.example.getcam.GetCamParameter");

        // デバイスIDの取得
        string[] idstmp = _javaClass.Call<string[]>("GetCamIDList");
        foreach (string idtmp in idstmp)
        {
            _devidList.Add(idtmp);
        }

        // プレビューサイズの取得
        string sizelist;
        sizelist = _javaClass.Call<string>("GetPreviewSize");

        // XMLをリストに変換
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(sizelist));
        XmlNode root = xmlDoc.FirstChild;
        XmlNodeList talkList = xmlDoc.GetElementsByTagName("device");
        Vector2 tmpsize;
        foreach (XmlNode devtmp in talkList)
        {
            _prevSizeList = new List<Vector2>();
            _prevSizeList.Clear();
            XmlNodeList nodelist = devtmp.ChildNodes;
            foreach (XmlNode s in nodelist)
            {
                tmpsize.x = float.Parse(s.Attributes["Width"].Value);
                tmpsize.y = float.Parse(s.Attributes["Height"].Value);
                _prevSizeList.Add(tmpsize);
            }
            _deviceList.Add(_prevSizeList);
        }

        // カメラの取り付け向き取得
        _Orientation = _javaClass.Call<int[]>("GetOrientation");

    }
    // Start is called before the first frame update
    void Start()
    {
        // UnityのWebCamTextureでカメラリスト取得
        _devices = WebCamTexture.devices;
        // デフォルト表示エリア保存
        defaulRawImageSize = RawImage.GetComponent<RectTransform>().sizeDelta;
        // カメラ0を設定
        _nowCamIDIndex = 0;
        // プレビューサイズインデックス0設定
        _nowCamSizeIndex = 0;
        // カメラ起動
        StartCamera();
    }

    public List<Vector2> GetCameraSize()
    {
        return _deviceList[_nowCamIDIndex];
    }

    public void SetCameraSize(int index)
    {
        _nowCamSizeIndex = index;
    }

    public List<string> GetDeviceIDList()
    {
        return _devidList;
    }

    public void SetDeviceID(int devindex)
    {
        _nowCamIDIndex = devindex;
    }

    public void RsetDevice()
    {
        //表示エリアを初期化
        RawImage.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
        RawImage.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        RawImage.GetComponent<RectTransform>().sizeDelta = defaulRawImageSize;

        // 起動中のカメラ停止
        webCam.Stop();
        webCam = null;

        // カメラ起動
        StartCamera();
    }

    public void StartCamera()
    {
        // 指定カメラを起動させる
        webCam = new WebCamTexture(_devices[_nowCamIDIndex].name);
        // RawImageのテクスチャにWebCamTextureのインスタンスを設定
        RawImage.texture = webCam;
        // 縦横のサイズを要求（_deviceListからorientationを考慮して決定する。ここでは直値）
        webCam.requestedWidth = (int)_deviceList[_nowCamIDIndex][_nowCamSizeIndex].x;
        webCam.requestedHeight = (int)_deviceList[_nowCamIDIndex][_nowCamSizeIndex].y;
        // カメラ起動
        webCam.Play();
        // 起動させて初めてvideoRotationAngle、width、heightに値が入り、
        // アスペクト比、何度回転させれば正しく表示されるかがわかる
        if ((webCam.videoRotationAngle == 90) || (webCam.videoRotationAngle == 270))
        {
            // 表示するRawImageを回転させる
            Vector3 angles = RawImage.GetComponent<RectTransform>().eulerAngles;
            angles.z = -webCam.videoRotationAngle;
            RawImage.GetComponent<RectTransform>().eulerAngles = angles;
        }
        // 回転済みなので、widthはx、heightはyでそのままサイズ調整
        // 全体を表示させるように、大きい方のサイズを表示枠に合わせる
        float scaler;
        Vector2 sizetmp = RawImage.GetComponent<RectTransform>().sizeDelta;
        if (webCam.width > webCam.height)
        {
            scaler = sizetmp.x / webCam.width;
        }
        else
        {
            scaler = sizetmp.y / webCam.height;
        }
        // サイズ調整
        sizetmp.x = webCam.width * scaler;
        sizetmp.y = webCam.height * scaler;
        if (_devices[_nowCamIDIndex].isFrontFacing && !webCam.videoVerticallyMirrored)
        {
            //インカメラで反転していない場合は反転させる
            Vector3 scaletmp = RawImage.GetComponent<RectTransform>().localScale;
            if ((webCam.videoRotationAngle == 90) || (webCam.videoRotationAngle == 270))
            {
                scaletmp.y = -1;
            }
            else
            {
                scaletmp.x = -1;
            }
            RawImage.GetComponent<RectTransform>().localScale = scaletmp;
        }
        // 表示領域サイズ設定
        RawImage.GetComponent<RectTransform>().sizeDelta = sizetmp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
