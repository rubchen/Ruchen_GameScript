using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSwitch : MonoBehaviour
{
   
    //�w�i�J���[
    public Image[] image;
    public Image [] backImage;
    //���ʉ�
    public AudioSource audioSource;
    public AudioClip shotAudio;
    public AudioClip selectAudio;

    public int weaponNum;

    void Start()
    {
        //���ʉ�
        audioSource = gameObject.GetComponent<AudioSource>();
        weaponNum = 0;
    }
    void Update()
    {
        //�E�N���b�N�Œe�I��
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

        //1�Ԃ̒e
        if (weaponNum == 0 || weaponNum == 3)
        {
            //�w�i�J���[
            image[0].color = new Color(0.6f, 1f, 1f);
            image[1].color = Color.white;
            image[2].color = Color.white;
        }
        //2�Ԃ̒e
        else if (weaponNum == 1 || weaponNum == 4)
        {
            //�w�i�J���[
            image[0].color = Color.white;
            image[1].color = new Color(0.6f, 1f, 1f);
            image[2].color = Color.white;
        }
        //3�Ԃ̒e
        else if (weaponNum == 2 || weaponNum == 5)
        {
            //�w�i�J���[
            image[0].color = Color.white;
            image[1].color = Color.white;
            image[2].color = new Color(0.6f, 1f, 1f);
        }
        //1�T�ڂ̒e��\����2�T�ڂ̒e���\��
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
        //1�T�ڂ̒e���\���ɂ�2�T�ڂ̒e��\��
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
