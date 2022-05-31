using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public GameObject[] FishPrefab;
    private float time;
    private int number;
    private int vecY;
    [SerializeField] int pos;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = 3.5f;
            vecY = Random.Range(-4, 4);
            number = Random.Range(0, FishPrefab.Length);
            Instantiate(FishPrefab[number], new Vector3(pos, vecY, 0), Quaternion.identity);
        }
    }
}