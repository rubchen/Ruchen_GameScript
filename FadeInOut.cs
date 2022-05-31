using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    //フェードイン
    public GameObject panelFade;
    Image fadealpha;
    private bool fadein;
    private float alpha;
    //フェードアウト
    public GameObject fadeOutPanel;
    Image fadeOutAlpha;
    private float outAlpha;
    void Start()
    {
        fadealpha = panelFade.GetComponent<Image>();
        fadeOutAlpha = fadeOutPanel.GetComponent<Image>();
        alpha = fadealpha.color.a;
        outAlpha = fadeOutAlpha.color.a;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.goalInstance.touchPlayer||Player.playerHp<=0)
        {
            panelFade.SetActive(true);
            FadeOut();
        }
        if (fadein)
        {
            FadeIn();
        }
    }
    void FadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            panelFade.SetActive(false);
        }
    }
    void FadeOut()
    {
        outAlpha += 0.01f;
        fadeOutAlpha.color = new Color(0, 0, 0, outAlpha);
    }

}
