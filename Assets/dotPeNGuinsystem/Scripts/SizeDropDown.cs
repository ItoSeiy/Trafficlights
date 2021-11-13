using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeDropDown : MonoBehaviour
{
    public GameObject CameraPrev;
    private List<Vector2> _devicesizelist;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetDeviceSizeList(List<Vector2> sizelist)
    {
        // sizeリストを文字列変換
        List<string> sizeliststr = setSizeList(sizelist);
        // Optionクリア
        GetComponent<Dropdown>().ClearOptions();
        // デバイスリストを設定
        GetComponent<Dropdown>().AddOptions(sizeliststr);
        // 初期化
        GetComponent<Dropdown>().value = 0;
        // デバイスサイズ変更を通知
        CameraPrev.GetComponent<CameraPrev>().SetCameraSize(0);
    }

    private List<string> setSizeList(List<Vector2> sizelist)
    {
        List<string> tmp = new List<string>();
        foreach (Vector2 size in sizelist)
        {
            tmp.Add(size.x.ToString() + " X " + size.y.ToString());
        }
        return tmp;
    }
    public void OnSelected()
    {
        // デバイスサイズ変更を通知
        CameraPrev.GetComponent<CameraPrev>().SetCameraSize(GetComponent<Dropdown>().value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}