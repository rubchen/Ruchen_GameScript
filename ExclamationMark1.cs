using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark1 : MonoBehaviour
{

    [SerializeField] Animator cautionAnimation;
    void Start()
    {
        cautionAnimation = GetComponent<Animator>();
        
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            cautionAnimation.SetBool("Caution", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            cautionAnimation.SetBool("Caution", false);
        }
    }
}
