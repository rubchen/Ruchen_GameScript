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
        //�G��15�̂�|������1.0�b��Ƀ��U���g��ʂɈڍs
        if (enemyDieNum>=15)
        {
            Invoke("Change", 1.0f);
        }
        //�|��������\��
        text.text = string.Format("�|������:{0}", enemyDieNum);
    }
    void Change()
    {
        SceneManager.LoadScene("GameClear");
    }
    private void OnTriggerEnter(Collider other)
    {
        //�|�������𐔂���
        if (other.CompareTag("Enemy")&&!enemyHit)
        {
            enemyDieNum++;
        }
    }
}
