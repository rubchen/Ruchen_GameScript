using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFadeOut : MonoBehaviour
{
    public GameObject fadeOutPanel;
    Image fadeOutAlpha;
    private float outAlpha;
    void Awake()
    {
        fadeOutAlpha = fadeOutPanel.GetComponent<Image>();
        outAlpha = fadeOutAlpha.color.a;
    }
    void Start()
    {
        fadeOutPanel.SetActive(false);
    }

    void Update()
    {
        if (Button.buttonInstance.clickButton)
        {
            fadeOutPanel.SetActive(true);
            FadeOut();
        }
    }
    void FadeOut()
    {
        outAlpha += 0.01f;
        fadeOutAlpha.color = new Color(0, 0, 0, outAlpha);
    }
}
