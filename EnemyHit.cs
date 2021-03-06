using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public int enemyDieNum;
    public Text text;
    private bool enemyHit;
    void Start()
    {
        enemyDieNum = 0;
        enemyHit = false;
    }

    void Update()
    {
        //敵を15体を倒したら1.0秒後にリザルト画面に移行
        if (enemyDieNum>=15)
        {
            Invoke("Change", 1.0f);
        }
        //倒した数を表示
        text.text = string.Format("倒した数:{0}", enemyDieNum);
    }
    void Change()
    {
        SceneManager.LoadScene("GameClear");
    }
    private void OnTriggerEnter(Collider other)
    {
        //倒した数を数える
        if (other.CompareTag("Enemy")&&!enemyHit)
        {
            enemyDieNum++;
        }
    }
}
