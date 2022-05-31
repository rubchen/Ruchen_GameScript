using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour //���C������{�[�i�X
{

    public bool pushSpace;
    private Vector3 transB;
    private Vector3 transM;
    public GameObject warpB;
    public GameObject warpM;
    public GameObject player;
    [SerializeField] bool scene;//true�Ȃ�Bonus�V�[���ɐ؂�ւ�,false�Ȃ�Main�V�[��
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