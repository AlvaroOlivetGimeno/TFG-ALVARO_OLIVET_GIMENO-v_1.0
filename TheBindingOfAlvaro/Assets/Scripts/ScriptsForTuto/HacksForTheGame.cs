using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacksForTheGame : MonoBehaviour
{
    //REFERENCIA A OTROS SCRIPTS u OBJETOS

    public float numMaxOfHabilitys;
    GameObject rBrain;
   public ProtoBLACKBOARD_Player bb_Player;

    public GameObject[] closeRoom;

    public GameObject stairs;
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        closeRoom = GameObject.FindGameObjectsWithTag("ClosetRoom");
        stairs = GameObject.FindGameObjectWithTag("Stairs");
        //bb_Player.GetComponent<ProtoBLACKBOARD_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------PUT VARIABLES IN---------------------------------------------------
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        closeRoom = GameObject.FindGameObjectsWithTag("ClosetRoom");
        stairs = GameObject.FindGameObjectWithTag("Stairs");

        //---------------------------------------RESTART MAP-------------------------------------------------------------
        RestartMapHack();

        //-------------------------------------CHANGE HABILITY---------------------------------------
        ChangeHabilityHack();

    }

    //RESTART MAP WITH R
    void RestartMapHack()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Destroy(stairs);
            foreach (GameObject x in closeRoom)
            {
                Destroy(x);
            }
            rBrain.GetComponent<RoomTemplates>().RestartMap();
        }
    }

    //CHANGE HABILITY
    void ChangeHabilityHack()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bb_Player.habilityType = bb_Player.habilityType +1;
            
            if(bb_Player.habilityType == 5)
            {
                bb_Player.stateType = 1;
            }
            else if(bb_Player.habilityType ==6 )
            {
                bb_Player.stateType = 2;
            }
            else
            {
                bb_Player.stateType = 0;
            }

            if(bb_Player.habilityType > numMaxOfHabilitys)
            {
                bb_Player.habilityType = 0;
                bb_Player.stateType = 0;
            }
        }
    }

    void UpgradeStatistics()
    {

    }

    

}
