using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Shop")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "SpecialRoom")
        { 
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Stairs")
        {
            Destroy(this.gameObject);
        }
    }


}
