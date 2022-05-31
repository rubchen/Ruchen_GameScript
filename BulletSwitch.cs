using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSwitch : MonoBehaviour
{
   
    //”wŒiƒJƒ‰[
    public Image[] image;
    public Image [] backImage;
    //Œø‰Ê‰¹
    public AudioSource audioSource;
    public AudioClip shotAudio;
    public AudioClip selectAudio;

    public int weaponNum;

    void Start()
    {
        //Œø‰Ê‰¹
        audioSource = gameObject.GetComponent<AudioSource>();
        weaponNum = 0;
    }
    void Update()
    {
        //‰EƒNƒŠƒbƒN‚Å’e‘I‘ğ
        if (Input.GetMouseButtonDown(1))
        {
            if (weaponNum <= 4)
            {
                weaponNum++;
            }
            else
            {
                weaponNum = 0;
            }
            audioSource.PlayOneShot(selectAudio);
        }
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(shotAudio);
        }

        //1”Ô‚Ì’e
        if (weaponNum == 0 || weaponNum == 3)
        {
            //”wŒiƒJƒ‰[
            image[0].color = new Color(0.6f, 1f, 1f);
            image[1].color = Color.white;
            image[2].color = Color.white;
        }
        //2”Ô‚Ì’e
        else if (weaponNum == 1 || weaponNum == 4)
        {
            //”wŒiƒJƒ‰[
            image[0].color = Color.white;
            image[1].color = new Color(0.6f, 1f, 1f);
            image[2].color = Color.white;
        }
        //3”Ô‚Ì’e
        else if (weaponNum == 2 || weaponNum == 5)
        {
            //”wŒiƒJƒ‰[
            image[0].color = Color.white;
            image[1].color = Color.white;
            image[2].color = new Color(0.6f, 1f, 1f);
        }
        //1T–Ú‚Ì’e‚ğ•\¦‚µ2T–Ú‚Ì’e‚ğ”ñ•\¦
        if (weaponNum == 0 || weaponNum == 1 || weaponNum == 2)
        {
            for (int i = 0; i < backImage.Length; i++)
            {
                if (i%2==0)
                {
                    backImage[i].enabled=true;
                }
                else
                {
                    backImage[i].enabled = false;
                }
            }
        }
        //1T–Ú‚Ì’e‚ğ”ñ•\¦‚É‚µ2T–Ú‚Ì’e‚ğ•\¦
        else if (weaponNum == 3 || weaponNum == 4 || weaponNum == 5)
        {
            for (int i = 0; i < backImage.Length; i++)
            {
                if (i % 2 != 0)
                {
                    backImage[i].enabled = true;
                }
                else
                {
                    backImage[i].enabled = false;
                }
            }
        }

       
    }
}
