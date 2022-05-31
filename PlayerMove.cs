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
        //�A�j���[�V����
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //�U��
        attack = false;
        handCollider = GameObject.Find("Character1_RightHand").
            GetComponent<SphereCollider>();
        //�_���[�W
        damage = false;
        slider.value = 1;
        playerHp = maxHp;
        damageHp = false;
    }

    void Update()
    {

        //ray���g�p�����ڒn����
        if (CheckGrounded() == true)
        {

            //�O�㏈��
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

            //�����]��
            //�����L�[�̂ǂ����������Ă��鎞
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)&&!attack&&!damage)
            {
                //������ς��Ȃ�
            }
            //�������L�[��������Ă��鎞
            else if (Input.GetKey(KeyCode.A)&&!attack&&!damage)
            {
                transform.Rotate(0, rotateSpeed * -1, 0);
            }
            //�E�����L�[��������Ă��鎞
            else if (Input.GetKey(KeyCode.D)&&!attack && !damage)
            {
                transform.Rotate(0, rotateSpeed, 0);
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }

            //�U��
            if (Input.GetMouseButtonDown(0)&&!damage)
            {
                StartCoroutine("EndPunch");
                //�R���C�_�[���I���ɂ���
                handCollider.enabled = true;
            }
            //�_���[�W
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
            //�d�͂𔭐�������
            moveDirection.y -= gravity * Time.deltaTime;

            //�ړ��̎��s
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            characterController.Move(globalDirection * Time.deltaTime);
        }
    }
    //�U���I��
    IEnumerator EndPunch()
    {
        animator.SetBool("Punch", true);
        attack = true;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Punch", false);
        attack = false;
        //�R���C�_�[���I�t�ɂ���
        handCollider.enabled = false;
    }
    //�_���[�W�I��
    IEnumerator DamageFalse()
    {
        yield return new WaitForSeconds(1.0f);
        damage = false;
        animator.SetBool("Damage", false);
    }
    //HP�o�[�̓���
    IEnumerator DamageHp()
    {
        damageHp = false;
        playerHp = playerHp - attackPawar;
        slider.value = playerHp / maxHp;
        yield return new WaitForSeconds(3.0f);
        damageHp = true;
    }
    //ray���g�p�����ڒn���胁�\�b�h
    public bool CheckGrounded()
    {

        //�����ʒu�ƌ���
        var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

        //ray�̒T���͈�
        var tolerance = 0.3f;

        //ray��Hit����
        //�������F��΂�Ray
        //�������FRay�̍ő勗��
        return Physics.Raycast(ray, tolerance);
    }
}