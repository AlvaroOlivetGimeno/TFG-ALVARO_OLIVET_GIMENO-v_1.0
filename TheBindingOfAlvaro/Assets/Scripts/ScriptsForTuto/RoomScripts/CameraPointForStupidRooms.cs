using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointForStupidRooms : MonoBehaviour
{
   [Header("MAP OBJECT -AUTOMATIC-:")]
    public GameObject myCameraMapObj;

    GameObject player;    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //MAP OBJECT LOGIC
    void MapObjectLogic()
    {
        if(myCameraMapObj != null)
        {
            if(player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic && player.GetComponent<ProtoBLACKBOARD_Player>().cameraMapIsActive )
            {
               myCameraMapObj.SetActive(true);
            }
            else
            {
                myCameraMapObj.SetActive(false);
            }
        }
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "MapObject")
        {
            myCameraMapObj = collision.gameObject;
        }
      
    }
}
