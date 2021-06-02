using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [Header("AUTOMATIC VARIABLES:")]

    public AudioSource audioSource;

    [Header("BOOL FOR BSO:")]

    public bool iHaveApeear;

    [Header("START MUTED:")]

    public bool muted;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  

        StartMetodh(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartMetodh()
    {
        if(muted)
        {
            NullVolumen();
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
    public void NullVolumen()
    {
        audioSource.volume = 0;
    }

    public void normalVolumen(float x)
    {
        audioSource.volume = x;
    }
    public void PlayOnAwakeSound()
    {
        audioSource.playOnAwake = true;
    }
}
