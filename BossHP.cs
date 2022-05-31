using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    //マックスHP
    float maxHp = 500.0f;
    //現在のHP
    public float nowHp;
    public Slider slider;
    //効果音
    public AudioSource audioSource;
    public AudioClip damageAudio;

    void Start()
    {
        slider.value = 1;
        nowHp = maxHp;
        //効果音
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P_Bullet")
        {
            //ダメージ
            int damage = 10;
            nowHp -= damage;//現在のHPからダメージを引く
            slider.value = nowHp / maxHp;//Slinderに反映
            Destroy(collision.gameObject);
            //効果音
            audioSource.PlayOneShot(damageAudio);
        }
    }
}
