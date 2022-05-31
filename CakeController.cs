using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    GameObject walk1;

    void Start()
    {
        this.walk1 = GameObject.Find("walk");
    }

    void Update()
    {
        //�t���[�����Ƃɓ����ŗ���������
        transform.Translate(0, -0.1f, 0);

        //��ʂ����ɏo����I�u�W�F�N�g��j������
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //�����蔻��
        Vector2 p1 = transform.position;
        Vector2 p2 = this.walk1.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.7f;

        if (d < r1 + r2)
        {
            //�Փ˂������Ƃ�`����
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().GetCake();
            Destroy(gameObject);
        }
    }
}
