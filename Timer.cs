using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public int battleTime;
    [SerializeField]
    public Text timerText;
    //public TMP_Text timerText;

    private int currentTime;
    private float timer;

    void Start()
    {
        currentTime = battleTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1)
        {
            timer = 0;
            battleTime--;
            DisplayBattleTime(battleTime);
        }
        else if(battleTime<=0)
        {
            battleTime = 90;
        }
    }
    private void DisplayBattleTime(int limitTime)
    {
        timerText.text = ((int)limitTime / 60).ToString("0 0") + " : "
            + ((int)limitTime % 60).ToString("0 0");
    }
}
