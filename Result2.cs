using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result2 : MonoBehaviour
{
    public Text PointText;
    int point;
    void Start()
    {
        point = GameDirector.getpoint();//�l�������|�C���g
        PointText.text = string.Format("{0}Point�c", point);//�|�C���g��\��
    }

    void Update()
    {

    }
}
