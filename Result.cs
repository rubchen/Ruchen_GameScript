using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text PointText;
    int point;
    void Start()
    {
        point = GameDirector.getpoint();//獲得したポイント
        PointText.text = string.Format("{0}Point!", point);//ポイントを表示
    }

    void Update()
    {
        
    }
}
