using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");//ボタンが押されたらゲームシーンに移行する
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
