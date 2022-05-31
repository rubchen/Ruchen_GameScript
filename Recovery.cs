using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    public float nowPosi;
    public AudioClip coinGetSE;
    public bool touchPlayer;
    void Start()
    {
        nowPosi = this.transform.position.y;
        touchPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector3(transform.position.x, nowPosi
            + Mathf.PingPong(Time.time / 5, 0.3f), transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ÉRÉCÉì
        if (collision.gameObject.tag == "Player" & touchPlayer)
        {
            touchPlayer = false;
            Destroy(this.gameObject);

        }
    }
}
