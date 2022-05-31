using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeSE : MonoBehaviour
{
    public bool DontDestroyOnLoad = true;
    public AudioSource audioSource;
    public AudioClip sceneShange;
    public float time=3.0f;
    void Start()
    {
        if (DontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(sceneShange);
            Destroy(this.gameObject, time);
        }
    }
}
