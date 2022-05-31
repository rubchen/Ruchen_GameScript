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
        //“G‚ğ15‘Ì‚ğ“|‚µ‚½‚ç1.0•bŒã‚ÉƒŠƒUƒ‹ƒg‰æ–Ê‚ÉˆÚs
        if (enemyDieNum>=15)
        {
            Invoke("Change", 1.0f);
        }
        //“|‚µ‚½”‚ğ•\¦
        text.text = string.Format("“|‚µ‚½”:{0}", enemyDieNum);
    }
    void Change()
    {
        SceneManager.LoadScene("GameClear");
    }
    private void OnTriggerEnter(Collider other)
    {
        //“|‚µ‚½”‚ğ”‚¦‚é
        if (other.CompareTag("Enemy")&&!enemyHit)
        {
            enemyDieNum++;
        }
    }
}
