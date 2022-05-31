using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    [SerializeField] float end;
    [SerializeField] int rigthOrLeft;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //‰E=1 ¶=2
        if (rigthOrLeft == 1)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (rigthOrLeft == 2)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (rigthOrLeft == 1 & transform.position.x >= end)
        {
            Destroy(this.gameObject);
        }
        else if (rigthOrLeft == 2 & transform.position.x <= end)
        {
            Destroy(this.gameObject);
        }
        
    }
}