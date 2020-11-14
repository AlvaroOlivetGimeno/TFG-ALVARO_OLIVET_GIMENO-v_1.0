using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacksForTheGame : MonoBehaviour
{
    //REFERENCIA A OTROS SCRIPTS u OBJETOS

    GameObject rBrain;

    public GameObject[] closeRoom;

    public GameObject stairs;
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        closeRoom = GameObject.FindGameObjectsWithTag("ClosetRoom");
        stairs = GameObject.FindGameObjectWithTag("Stairs");

    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------PUT VARIABLES IN---------------------------------------------------
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        closeRoom = GameObject.FindGameObjectsWithTag("ClosetRoom");
        stairs = GameObject.FindGameObjectWithTag("Stairs");

        //---------------------------------------RESTART MAP-------------------------------------------------------------
        if (Input.GetKey(KeyCode.R))
        {
            Destroy(stairs);
            foreach(GameObject x in closeRoom)
            {
                Destroy(x);
            }
            rBrain.GetComponent<RoomTemplates>().RestartMap();
        }
    }
}
