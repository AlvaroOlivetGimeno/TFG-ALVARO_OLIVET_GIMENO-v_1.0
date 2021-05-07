using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryParticlesSpeed : MonoBehaviour
    {
    
    [Header("AUTOMATIC ELEMENT:")]
    public ParticleSystem particle;

    public bool play;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(play)
        {
            particle.Play();
            play = false;
         
            
        }
       
       
    }

    
}
