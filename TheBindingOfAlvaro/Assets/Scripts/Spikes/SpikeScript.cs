using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [Header("CONTACT'S:")]

    public bool contact;

    public bool contactWithLight;

    [Header("DON'T DISAPEAR IN CONTACT WITH A WALL:")]

    public bool dontDisapear;

      
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!contact || contactWithLight)
        {
            if(!dontDisapear)
            {
                Destroy(this.gameObject);
            }
            
        }
    }

    //COLLISION
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Wall")
        {
            contact = true;
        }
        if(other.gameObject.tag == "LightRoom")
        {
            contactWithLight = true;
        }     
    }
   
}
