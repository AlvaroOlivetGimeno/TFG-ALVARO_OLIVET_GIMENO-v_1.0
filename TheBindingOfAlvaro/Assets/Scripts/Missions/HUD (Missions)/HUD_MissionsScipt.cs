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

    [Header("AUTOMATIC VARIABLES:")]

    public Text text;


    //OTRAS

    public int numOfXYouHaveToDo;
    public int numOfXYouHaveDone;
    GameObject player;
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        mission = GameObject.FindGameObjectsWithTag("Mission");

        
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
        switch(textType)
        {
            case 1: break;
            case 2:

                switch(missionNum)
                {
                    case 2:
                    foreach(GameObject x in mission)
                    {
                        if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                        {
                            numOfXYouHaveToDo = x.GetComponent<MissionCommonScript>().parrysToDo;
                        }   
                    }
                    numOfXYouHaveDone = player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysDone;

                    break;

                    case 3:
                        foreach(GameObject x in mission)
                        {
                            if(x.GetComponent<MissionCommonScript>().missionType == missionNum)
                            {
                                numOfXYouHaveToDo = x.GetComponent<MissionCommonScript>().enemysToKill;
                            }   
                        }
                    numOfXYouHaveDone = player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilled;
            break;
                }
                
            break;

           
        }
    }

    //TextController

    void WriteText()
    {
        switch(textType)
        {
            case 1: text.text = txt; break;
            case 2: text.text = txt1 + " " + numOfXYouHaveToDo.ToString() + " " + txt2 +" (" + 
                    numOfXYouHaveDone.ToString() + "/" + numOfXYouHaveToDo.ToString() + ")"; break;
            case 3: break;
        }
    }







}
