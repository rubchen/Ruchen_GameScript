using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private Transform rangeA;
    [SerializeField] private Transform rangeB;
    private float time;
    private int number;//ゾンビが出た数

    void Start()
    {
        time = 1.0f;
        number = 0;
    }

    void Update()
    {
        time -= Time.deltaTime;
        //5秒ごとにゾンビを出す
        if (time <= 0.0f)
        {
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            time = 5.0f;
            Instantiate(zombie, new Vector3(x, 0, 130),zombie.transform.rotation);
            number++;
        }
        //ゾンビを15体倒したらストップする
        if (number>=15)
        {
            time = 1.0f;
        }
    }
}
