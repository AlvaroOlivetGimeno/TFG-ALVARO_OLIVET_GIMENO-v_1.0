using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    
    public  GameObject roomBrain;
    void Start()
    {
        roomBrain = GameObject.FindGameObjectWithTag("RoomBrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //COLLISION
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ProtoBLACKBOARD_Player>().actualLevel +=1;
            roomBrain.GetComponent<RoomTemplates>().nextLevel = true;
            //Destroy(this.gameObject);
        }
    }
}
