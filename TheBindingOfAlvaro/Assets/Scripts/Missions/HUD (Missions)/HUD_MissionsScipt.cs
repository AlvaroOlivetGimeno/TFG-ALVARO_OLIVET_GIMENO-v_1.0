    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_MissionsScipt : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("NUM. OF MISSION:")]
    public float missionNum; 

    [Header("TYPE OF TEXT:")]
    public float textType;

    [Header("TEXT OF THE MISION (TYPE 1):")]
    public string txt;

    [Header("TEXT OF THE MISION (TYPE 2):")]
    public string txt1;
    public string txt2;
    
    [Header("LIST OF MISION:")]

    public GameObject[] mission;
    public GameObject[] hardMission;

    [Header("AUTOMATIC VARIABLES:")]

    public Text text;


    //OTRAS

    public string numOfXYouHaveToDo;
    public string numOfXYouHaveDone;
    public float minuts;
    public float seconds;

    GameObject player;
    GameObject roomBrain;
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        mission = GameObject.FindGameObjectsWithTag("Mission");
        hardMission = GameObject.FindGameObjectsWithTag("HardMission");
        roomBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------Start METOD-------------------------
        StartMetod();

        //----------------------------

        //-----------------------WRITE TEXT------------------------------
        WriteText();

        //----------------------------
    }

    //START METOD
    void StartMetod()
    {
        switch(missionNum)
        {
            case 1:
                numOfXYouHaveToDo = (roomBrain.GetComponent<RoomTemplates>().sizeOfList +1).ToString();
                numOfXYouHaveDone = player.GetComponent<ProtoBLACKBOARD_Player>().numOfRoomsSeenInTheLevel.ToString();
            break;

            case 2:
                foreach(GameObject x in mission)
                    {
                        if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                        {
                            numOfXYouHaveToDo = x.GetComponent<MissionCommonScript>().parrysToDo.ToString();
                        }   
                    }
                numOfXYouHaveDone = player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysDoneForMission.ToString();
            break;

            case 3:
                foreach(GameObject x in mission)
                    {
                        if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                        {
                            numOfXYouHaveToDo = x.GetComponent<MissionCommonScript>().enemysToKill.ToString();
                        }   
                    }
                    numOfXYouHaveDone = player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission.ToString();
            break;

            case 4:
                foreach(GameObject x in hardMission)
                {
                    if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                    {
                        numOfXYouHaveToDo = x.GetComponent<MissionCommonScript>().lifesAtMoment.ToString();
                    }
                }
            break;
            case 5:
                foreach(GameObject x in hardMission)
                {
                    if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                    {
                        minuts = x.GetComponent<MissionCommonScript>().minuts;
                        seconds = x.GetComponent<MissionCommonScript>().seconds;
                    }
                    
                }
            break;
            case 6:
                foreach(GameObject x in hardMission)
                {
                    if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                    {
                        minuts = x.GetComponent<MissionCommonScript>().minuts;
                        seconds = x.GetComponent<MissionCommonScript>().seconds;
                    }
                    
                }
            break;
            
        }
    }

    //TextController

    void WriteText()
    {
        switch(textType)
        {
            case 1: text.text = txt + " ("+ numOfXYouHaveDone +"/"+ numOfXYouHaveToDo +")"; break;
            case 2: text.text = txt1 + " " + numOfXYouHaveToDo + " " + txt2 +" (" + 
                    numOfXYouHaveDone + "/" + numOfXYouHaveToDo + ")"; break;
            case 3: text.text = txt1 + " " + numOfXYouHaveToDo + " " + txt2; break;
            case 4: text.text = txt + " " + minuts + ":" + seconds; break;
        }
    }
    
   







}
