using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static GameObject singleton;
    public GameObject Bgm;
    void Awake()
    {
        if (singleton==null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="Title"||
            SceneManager.GetActiveScene().name == "Story"||
            SceneManager.GetActiveScene().name == "Tutorial")
        {
            Bgm.SetActive(true);
        }
        else
        {
            Bgm.SetActive(false);
        }
    }
}
