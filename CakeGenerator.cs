using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGenerator : MonoBehaviour
{
    public GameObject cakePrefab;
    float span = 1.0f;//�o�Ă���p�x
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {//�����_���ɗ�������
            this.delta = 0;
            GameObject go = Instantiate(cakePrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}