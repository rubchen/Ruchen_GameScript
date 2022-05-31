using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownSU : MonoBehaviour
{
    public float nowPosi;
    [SerializeField] float speed;
    [SerializeField] float upDown;

    void Start()
    {
        nowPosi = this.transform.position.y;
    }

    void Update()
    {
        transform.position =
            new Vector3(transform.position.x, nowPosi
            + Mathf.PingPong(Time.time*speed, upDown), transform.position.z);
    }
}
