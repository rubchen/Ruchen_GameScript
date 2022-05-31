using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrtButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");  //ボタンを押したらゲームシーンに移行する
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
