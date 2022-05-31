using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float gravity;
    public float speed;
    public float buckSpeed;
    public float jumpSpeed;
    public float rotateSpeed;
    public float maxHp=500;
    public float playerHp;
    public int attackPawar = 10;
    public Slider slider;
    public bool damage;
    public bool damageHp;
    public static PlayerMove playerMoveIns;
    private bool attack;
    private Collider handCollider;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        if (playerMoveIns==null)
        {
            playerMoveIns = this;
        }
    }
    void Start()
    {
        //アニメーション
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //攻撃
        attack = false;
        handCollider = GameObject.Find("Character1_RightHand").
            GetComponent<SphereCollider>();
        //ダメージ
        damage = false;
        slider.value = 1;
        playerHp = maxHp;
        damageHp = false;
    }

    void Update()
    {

        //rayを使用した接地判定
        if (CheckGrounded() == true)
        {

            //前後処理
            if (Input.GetKey(KeyCode.W)&&!attack && !damage)
            {
                moveDirection.z = speed;
                animator.SetBool("Run", true);
            }
            else if (Input.GetKey(KeyCode.S)&&!attack && !damage)
            {
                moveDirection.z = -buckSpeed;
                animator.SetBool("Back", true);
            }
            else
            {
                moveDirection.z = 0;
                animator.SetBool("Run", false);
                animator.SetBool("Back", false);
            }

            //方向転換
            //方向キーのどちらも押されている時
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)&&!attack&&!damage)
            {
                //向きを変えない
            }
            //左方向キーが押されている時
            else if (Input.GetKey(KeyCode.A)&&!attack&&!damage)
            {
                transform.Rotate(0, rotateSpeed * -1, 0);
            }
            //右方向キーが押されている時
            else if (Input.GetKey(KeyCode.D)&&!attack && !damage)
            {
                transform.Rotate(0, rotateSpeed, 0);
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }

            //攻撃
            if (Input.GetMouseButtonDown(0)&&!damage)
            {
                StartCoroutine("EndPunch");
                //コライダーをオンにする
                handCollider.enabled = true;
            }
            //ダメージ
            if (damage)
            {
                animator.SetBool("Damage", true);
                StartCoroutine("DamageFalse");
            }
            if (damageHp&&damage)
            {
                StartCoroutine("DamageHp");
            }
            if (playerHp<=0)
            {
                SceneManager.LoadScene("GameOver");
            }
            //重力を発生させる
            moveDirection.y -= gravity * Time.deltaTime;

            //移動の実行
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            characterController.Move(globalDirection * Time.deltaTime);
        }
    }
    //攻撃終了
    IEnumerator EndPunch()
    {
        animator.SetBool("Punch", true);
        attack = true;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Punch", false);
        attack = false;
        //コライダーをオフにする
        handCollider.enabled = false;
    }
    //ダメージ終了
    IEnumerator DamageFalse()
    {
        yield return new WaitForSeconds(1.0f);
        damage = false;
        animator.SetBool("Damage", false);
    }
    //HPバーの動き
    IEnumerator DamageHp()
    {
        damageHp = false;
        playerHp = playerHp - attackPawar;
        slider.value = playerHp / maxHp;
        yield return new WaitForSeconds(3.0f);
        damageHp = true;
    }
    //rayを使用した接地判定メソッド
    public bool CheckGrounded()
    {

        //初期位置と向き
        var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

        //rayの探索範囲
        var tolerance = 0.3f;

        //rayのHit判定
        //第一引数：飛ばすRay
        //第二引数：Rayの最大距離
        return Physics.Raycast(ray, tolerance);
    }
}