using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGenerator : MonoBehaviour
{
    public GameObject leverPrefab;
    float span = 2.5f; //‚¨‚¿‚é•p“x
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(leverPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
