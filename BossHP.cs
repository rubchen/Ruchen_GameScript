using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    //�}�b�N�XHP
    float maxHp = 500.0f;
    //���݂�HP
    public float nowHp;
    public Slider slider;
    //���ʉ�
    public AudioSource audioSource;
    public AudioClip damageAudio;

    void Start()
    {
        slider.value = 1;
        nowHp = maxHp;
        //���ʉ�
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P_Bullet")
        {
            //�_���[�W
            int damage = 10;
            nowHp -= damage;//���݂�HP����_���[�W������
            slider.value = nowHp / maxHp;//Slinder�ɔ��f
            Destroy(collision.gameObject);
            //���ʉ�
            audioSource.PlayOneShot(damageAudio);
        }
    }
}
