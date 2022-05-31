using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownFH : MonoBehaviour
{
    public float speed;
    [SerializeField] float PosY;
    public bool trigger;
    void Start()
    {
        speed = 5;
        trigger = false;
    }

    void Update()
    {
        if (trigger & transform.position.y >= PosY)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        else if (!trigger&transform.position.y<=9)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    public void OnTriggerStay2D(Collider2D collision )
    {
        if (collision.gameObject.tag=="Player" )
        {
            trigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            trigger = false;
        }
        
    }
}
