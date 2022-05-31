using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Start Scene");//ボタンを押されたらスタート画面に移行する
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
