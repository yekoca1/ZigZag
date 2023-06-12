using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSound : MonoBehaviour
{

    public AudioSource sound;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void soundPlay()
    {
        sound.Play();
    }

    public void soundStop()
    {
        sound.Stop();
    }
}

