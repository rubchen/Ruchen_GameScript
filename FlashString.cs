using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FlashString : MonoBehaviour
{
    [SerializeField]
    Text text;
    bool up = false;
    float alfha = 1;
    float changeAlpha=0.1f;
    [SerializeField]
    float waitTime = 0.05f;
    IEnumerator flashString()
    {
        while (true)
        {
            if (alfha == 0 || alfha == 1) up = !up;
            if (up)
            {
                alfha += changeAlpha;
            }
            else
            {
                alfha -= changeAlpha;
            }
            alfha = Mathf.Clamp(alfha, 0, 1);
            text.color = new Color(0, 0, 0, alfha);
            yield return new WaitForSeconds(waitTime);
        }
    }
    void Start()
    {
        StartCoroutine(flashString());
    }
}
