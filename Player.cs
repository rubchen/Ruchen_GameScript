using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Animator anim;
    public float speed;
    public float rigthX;
    public float leftX;
    //���_
    public TextMeshProUGUI scoreText;
    public static int score;
    //HP
    public Slider slider;
    public static float maxHp=120;
    public static float playerHp;
    //���G����A�A�j���[�V����
    public bool onDamage;
    //�m�b�N�o�b�N
    public bool dmg;
    public Rigidbody2D rigid2D;
    //���ʉ�
    public AudioSource audioSource;
    public AudioClip damageSE;
    public AudioClip coinSE;

    void Start()
    {
        playerHp = maxHp;
        score = 0;
        speed = 10.0f;
        anim = GetComponent<Animator>();
        onDamage=false;
        dmg = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        GetComponent<Player>().enabled = false;
        StartCoroutine("FadeInPlayer");
    }

    void Update()
    {
        //�ړ�
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        Vector3 pos = transform.position;
        //��
        if (Input.GetKey(KeyCode.UpArrow) & transform.position.y < 4.0f)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        //��
        if (Input.GetKey(KeyCode.DownArrow) & transform.position.y > -4.0f)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        
        //�E
        if (Input.GetKey(KeyCode.RightArrow)&transform.position.x < rigthX)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            scale.x = -1;
        }
        //��
        if (Input.GetKey(KeyCode.LeftArrow)& transform.position.x > leftX)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            scale.x = 1;
            
        }
        transform.localScale = scale;
        //�����A�j���[�V����
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Swim", true);
        }
        //�ҋ@���̃A�j���[�V����
        else
        {
            anim.SetBool("Swim", false);
        }
        Vector3 playerPos = this.gameObject.transform.position;
        //�{�[�i�X�X�e�[�W���̈ړ�����
        if (playerPos.x<=-40)
        {
            rigthX = -50;
            leftX = -62;
        }
        else
        {
            rigthX = 150;
            leftX = -15;
        }
        scoreText.text = string.Format("Score:{0}", score);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="MermaidCoin")
        {
            audioSource.PlayOneShot(coinSE);
        }
        if (col.gameObject.tag== "hart")
        {
            playerHp += 5;
            if (playerHp >= maxHp)
            {
                playerHp = maxHp;
            }
            slider.value = playerHp / maxHp;
        }
        //�_���[�W���̏���
        if (col.gameObject.tag == "Enemy" && !onDamage)
        {
            //���G�ƃA�j���[�V������HP�o�[
            OnDamageEffect();
            int damage = 8;
            playerHp -= damage;
            slider.value = playerHp /maxHp;
            anim.SetBool("Damage", true);

        }
        if (col.gameObject.tag == "Enemy" && !dmg)
        {
            NockBuck();
            //�m�b�N�o�b�N
            float boundsPower = 10.0f;
            //�Փˈʒu�̎擾
            Vector3 hitPos = col.contacts[0].point;
            //�Փˈʒu����������x�N�g�������߂�
            Vector3 boundVec = this.transform.position - hitPos;
            //�t�����ɂ͂˂�
            Vector3 forceDir = boundsPower * boundVec.normalized;
            this.GetComponent<Rigidbody2D>().AddForce(forceDir, ForceMode2D.Impulse);
            //���ʉ���炷
            audioSource.PlayOneShot(damageSE);
            //����s�\�ɂ���
            GetComponent<Player>().enabled = false;
        }

    }
    /// <summary>
    /// ���ꂽ���̏���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "seaUrchin")
        {
            StartCoroutine("dmgFalse");
        }
    }
    /// <summary>
    /// ���G����
    /// </summary>
    void OnDamageEffect()
    {
        onDamage = true;
        StartCoroutine("WaitForIt");
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        onDamage = false;
        anim.SetBool("Damage", false);
    }
    /// <summary>
    /// �m�b�N�o�b�N
    /// </summary>
    void NockBuck()
    {
        dmg = true;
        StartCoroutine("dmgFalse");
    }
    /// <summary>
    /// 0.2�b��Ƀm�b�N�o�b�N���~�߁A����\�ɂ���
    /// </summary>
    /// <returns></returns>
    IEnumerator dmgFalse()
    {
        yield return new WaitForSeconds(0.3f);
        this.dmg = false;
        rigid2D.velocity = Vector3.zero;
        GetComponent<Player>().enabled = true;
    }
    IEnumerator FadeInPlayer()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<Player>().enabled = true;
    }
}