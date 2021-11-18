using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerPe : MonoBehaviour
{
    //スピード
    public static float allspeed;
    private bool speedup;

    //ロープ
    private float kankaku;
    public GameObject[] rope;
    private float position;
    private int number;
    
    //タコ
    public GameObject[] tako;
    private float takotime;
    public static bool takoon;

    //黒
    private float kurotime;
    public GameObject[] kuro;
    private int kurowaki;


    //リンゴ
    private float appletime;
    public GameObject[] apple; 
    private int applewaki; 
    private float appleposition;

    //時間
    private float time = 90.0f;
    public Text timeText;         

    //スコア
    public static float score = 0;
    public static float scoreup ;
    public Text scoretext;

    //[SerializeField] float m_overlapRadius = 2.5f;

    

    void Start()
    {
        kankaku = 1.0f;
        takotime = 0.0f;
        kurotime = 0.0f;
        appletime = 0.0f;
        speedup = true;
        Debug.Log("test");
    }

    
    void Update()
    {
        scoretext.text = score.ToString();
        
        kankaku -= Time.deltaTime;
        takotime -= Time.deltaTime;
        kurotime -= Time.deltaTime;
        appletime -= Time.deltaTime;

        
        //ペンギン出現用
        if (kankaku <= 0.0f)
        {
            kankaku = 2.0f;
            number = Random.Range(0, rope.Length);

            position = Random.Range(-2.5f, 2.5f);

            Instantiate(rope[number], new Vector3(position, 5, number), Quaternion.identity);
        }
        


        //時間
        time -= Time.deltaTime;
        timeText.text = time.ToString("f1") + "秒";
        if(time <= 0)
        {
            timeText.text = "終了";
            score = score * scoreup;
            Coroutine endpe = StartCoroutine("Endmain", 1.0f);
        }

        //60秒経過
        if(time <= 60.0)
        {
            //経過で速度上昇
            if(speedup == true)
            {
                allspeed = allspeed + 0.25f;
                speedup = false;
            }
            

            //タコの処理
            if(takotime <= 0.0f && takoon == false)
            {
                takoon = true;
                takotime = 20.0f;
                Instantiate(tako[0], new Vector3(-7, -4, -2), Quaternion.identity);
                Instantiate(tako[1], new Vector3(7, -4, -1), Quaternion.identity);
            }

            //黒ペンギンの処理
            if(kurotime <= 0.0f)
            {
                kurotime = 7.0f;
                kurowaki = Random.Range(0,3);

                Instantiate(kuro[kurowaki], new Vector3(4, -4, 0), Quaternion.identity);
            }

            //リンゴ処理
            if (appletime <= 0.0f)
            {
                appletime = 10.0f;
                applewaki = Random.Range(0, 2);
                appleposition = Random.Range(-2.5f, 2.5f);

                Instantiate(apple[applewaki], new Vector3(appleposition, 7, 3), Quaternion.identity);
            }
        }
    }



    //エンド

    private  IEnumerator Endmain(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("endScene");
    }


}
