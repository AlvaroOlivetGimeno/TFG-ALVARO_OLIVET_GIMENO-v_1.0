using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [Header("DIFERENT TYPES OF ROOMS:")]

    public bool contact;
      
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!contact)
        {
            Destroy(this.gameObject);
        }
    }

    //COLLISION
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Wall")
        {
            contact = true;
        }   
    }
}
