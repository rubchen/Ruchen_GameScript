using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float speed;
    void Start()
    {
        speed = 15.0f;
    }

    void Update()
    {
        //左右移動
        int Key = 0;
        if (Input.GetKey(KeyCode.RightArrow)&transform.position.x < 7.5f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            Key = 1;
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)&transform.position.x>-7.5f)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            Key = -1;
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

            
        //動く方向に応じて反転
        if (Key != 0)
        {
            transform.localScale = new Vector3(-Key, 1, 1);
        }
    }
}
