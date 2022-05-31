using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;//��������30�b
    public static int point = 0;

    public void GetCake()  //�P�[�L�̓��_
    {
        point += 100;
    }

    public void GetLever()  //���o�[�̓��_
    {
        point -= 75;
    }
    public static int getpoint()
    {
        return point;//���_��ۊ�
    }

    void Start()
    {
        point = 0;//���_���Z�b�g
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");  //��������
        this.pointText.GetComponent<Text>().text = point.ToString() + "point";  //���_
        if (time <= 0.0)
        {
            if (point >= 0)
            {
                SceneManager.LoadScene("ResultScene");  //�|�C���g��0�_�ȏ�̏ꍇ���U���g��ʂɈڂ�
            }
            else
            {
                SceneManager.LoadScene("ResultScene2");//�|�C���g���}�C�i�X�̏ꍇ���U���g���2�Ɉڂ�
            }
        }
        
    }
}
