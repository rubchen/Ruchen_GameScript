using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextResult : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string mark;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.playerHp<=0)
        {
            Player.playerHp = 0;
        }
        scoreText.text = string.Format("{0}point"+mark, Player.score+Player.playerHp);
    }
}
