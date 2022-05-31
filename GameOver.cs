using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Player.playerHp<=0)
        {
            StartCoroutine("SceneChange");
        }
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }
}