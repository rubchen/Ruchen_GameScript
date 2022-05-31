using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static Goal goalInstance;
    public bool touchPlayer;
    public void Awake()
    {
        if (goalInstance==null)
        {
            goalInstance = this;
        }
    }
    void Start()
    {
        touchPlayer = false;
    }

    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchPlayer = true;
            StartCoroutine("SceneChange");
            
        }
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Clear");
    }
}