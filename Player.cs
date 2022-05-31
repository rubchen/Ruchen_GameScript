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
    //得点
    public TextMeshProUGUI scoreText;
    public static int score;
    //HP
    public Slider slider;
    public static float maxHp=120;
    public static float playerHp;
    //無敵判定、アニメーション
    public bool onDamage;
    //ノックバック
    public bool dmg;
    public Rigidbody2D rigid2D;
    //効果音
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
        //移動
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        Vector3 pos = transform.position;
        //上
        if (Input.GetKey(KeyCode.UpArrow) & transform.position.y < 4.0f)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        //下
        if (Input.GetKey(KeyCode.DownArrow) & transform.position.y > -4.0f)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        
        //右
        if (Input.GetKey(KeyCode.RightArrow)&transform.position.x < rigthX)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            scale.x = -1;
        }
        //左
        if (Input.GetKey(KeyCode.LeftArrow)& transform.position.x > leftX)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            scale.x = 1;
            
        }
        transform.localScale = scale;
        //歩くアニメーション
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Swim", true);
        }
        //待機中のアニメーション
        else
        {
            anim.SetBool("Swim", false);
        }
        Vector3 playerPos = this.gameObject.transform.position;
        //ボーナスステージ時の移動制限
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
        //ダメージ時の処理
        if (col.gameObject.tag == "Enemy" && !onDamage)
        {
            //無敵とアニメーションとHPバー
            OnDamageEffect();
            int damage = 8;
            playerHp -= damage;
            slider.value = playerHp /maxHp;
            anim.SetBool("Damage", true);

        }
        if (col.gameObject.tag == "Enemy" && !dmg)
        {
            NockBuck();
            //ノックバック
            float boundsPower = 10.0f;
            //衝突位置の取得
            Vector3 hitPos = col.contacts[0].point;
            //衝突位置から向かうベクトルを求める
            Vector3 boundVec = this.transform.position - hitPos;
            //逆方向にはねる
            Vector3 forceDir = boundsPower * boundVec.normalized;
            this.GetComponent<Rigidbody2D>().AddForce(forceDir, ForceMode2D.Impulse);
            //効果音を鳴らす
            audioSource.PlayOneShot(damageSE);
            //操作不能にする
            GetComponent<Player>().enabled = false;
        }

    }
    /// <summary>
    /// 離れた時の処理
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
    /// 無敵判定
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
    /// ノックバック
    /// </summary>
    void NockBuck()
    {
        dmg = true;
        StartCoroutine("dmgFalse");
    }
    /// <summary>
    /// 0.2秒後にノックバックを止め、操作可能にする
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