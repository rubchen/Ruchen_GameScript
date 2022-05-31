using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] int scene;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnClick()
    {
        if (scene==1)
        {
            SceneManager.LoadScene("Title");
        }
        else if (scene==2)
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (scene==3)
        {
            SceneManager.LoadScene("tutorial");
        }
    }
}
