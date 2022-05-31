using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;//制限時間30秒
    public static int point = 0;

    public void GetCake()  //ケーキの得点
    {
        point += 100;
    }

    public void GetLever()  //レバーの得点
    {
        point -= 75;
    }
    public static int getpoint()
    {
        return point;//得点を保管
    }

    void Start()
    {
        point = 0;//得点リセット
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");  //制限時間
        this.pointText.GetComponent<Text>().text = point.ToString() + "point";  //得点
        if (time <= 0.0)
        {
            if (point >= 0)
            {
                SceneManager.LoadScene("ResultScene");  //ポイントが0点以上の場合リザルト画面に移る
            }
            else
            {
                SceneManager.LoadScene("ResultScene2");//ポイントがマイナスの場合リザルト画面2に移る
            }
        }
        
    }
}
