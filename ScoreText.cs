using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Clear" ||
            SceneManager.GetActiveScene().name == "GameOverM" ||
            SceneManager.GetActiveScene().name == "GameOverB")
        {
            rect.localPosition = new Vector2(-150, 75);
            rect.localScale = new Vector2(2.0f, 2.0f);
        }
        if (SceneManager.GetActiveScene().name== "MainScene" ||
            SceneManager.GetActiveScene().name == "Bonus")
        {
            rect.localPosition = new Vector2(-266, 182);
            rect.localScale = new Vector2(1.25f, 1.25f);
        }

    }
}