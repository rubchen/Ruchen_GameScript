using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bonusFishRight;
    public GameObject bonusFishLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = player.transform.position;
        if (playerPos.x <= -40)
        {
            bonusFishRight.SetActive(true);
            bonusFishLeft.SetActive(true);
        }
        else
        {
            bonusFishRight.SetActive(false);
            bonusFishLeft.SetActive(false);
        }
    }
}
