using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject panelFade;
    Image fadealpha;
    private float alpha;
    private bool fadein;
    void Start()
    {
        fadealpha = panelFade.GetComponent<Image>();
        alpha = fadealpha.color.a;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein)
        {
            StartFadeIn();
        }
    }
    void StartFadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            panelFade.SetActive(false);
        }
    }
}
