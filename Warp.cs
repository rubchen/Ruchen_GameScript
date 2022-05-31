using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour //メインからボーナス
{

    public bool pushSpace;
    private Vector3 transB;
    private Vector3 transM;
    public GameObject warpB;
    public GameObject warpM;
    public GameObject player;
    [SerializeField] bool scene;//trueならBonusシーンに切り替え,falseならMainシーン
    void Start()
    {
        pushSpace = false;
        transB = warpB.transform.position;
        transM = warpM.transform.position;
    }
    void Update()
    {
        if (pushSpace &scene& Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = transB;
        }
        if (pushSpace&!scene&Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = transM;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pushSpace = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pushSpace = false;
        }
    }
}