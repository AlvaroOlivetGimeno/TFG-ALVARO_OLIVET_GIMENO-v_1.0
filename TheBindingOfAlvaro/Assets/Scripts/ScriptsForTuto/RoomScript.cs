using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{

    //OTHER SCRIPTS NEEDED
    GameObject rBrain;

    //OTHER VARABLES NEEDED

    int rand;
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        rBrain.GetComponent<RoomTemplates>().AddToList(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int wichRoomIAm()
    {
        rand = Random.Range(0,10);

        if(rand >= 5)
        {
            return 1;
        }
        if(rand == 6)
        {
            return 2;
        }
        if(rand == 7)
        {
            return 3;
        }
        if(rand == 8)
        {
            return 4;
        }
        if(rand == 9)
        {
            return 5;
        }
        if(rand == 10)
        {
            return 6;
        }
        else
        {
            return 1;
        }
    }
}
