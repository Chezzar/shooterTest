using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLifeTime : MonoBehaviour
{
    AudioSource MySound;
    void Start()
    {
        MySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!MySound.isPlaying)
            Destroy(gameObject);
    }
}
