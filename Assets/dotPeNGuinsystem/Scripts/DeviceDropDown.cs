using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceDropDown : MonoBehaviour
{
    public GameObject CameraPrev;
    public GameObject CameraSizeDropDown;
    private List<string> _deviceidlist;
    private List<Vector2> _devicesizelist;
    private Dropdown _devicedd;

    // Start is called before the first frame update
    void Start()
    {
        // デバイスIDリストの取得
        _deviceidlist = CameraPrev.GetComponent<CameraPrev>().GetDeviceIDList();
        // DropDownコンポーネント取得
        _devicedd = GetComponent<Dropdown>();
        // Optionクリア
        _devicedd.ClearOptions();
        // デバイスリストを設定
        _devicedd.AddOptions(_deviceidlist);
        // プレビューサイズリストの取得
        _devicesizelist = CameraPrev.GetComponent<CameraPrev>().GetCameraSize();
        // サイズリスト更新
        CameraSizeDropDown.GetComponent<SizeDropDown>().SetDeviceSizeList(_devicesizelist);
    }

    public void OnSelected()
    {
        // デバイスID変更を通知
        CameraPrev.GetComponent<CameraPrev>().SetDeviceID(_devicedd.value);
        // プレビューサイズリストの取得
        _devicesizelist = CameraPrev.GetComponent<CameraPrev>().GetCameraSize();
        // サイズリスト更新
        CameraSizeDropDown.GetComponent<SizeDropDown>().SetDeviceSizeList(_devicesizelist);
    }

    // Update is called once per frame
    void Update()
    {

    }
}