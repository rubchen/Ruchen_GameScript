using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpAnimation : MonoBehaviour
{
    [SerializeField] Animator spaceAnim;
    void Start()
    {
        spaceAnim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spaceAnim.SetBool("Space", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spaceAnim.SetBool("Space", false);
        }
    }
}