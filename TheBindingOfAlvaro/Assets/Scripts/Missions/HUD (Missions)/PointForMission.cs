using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForMission : MonoBehaviour
{
    [Header("TYPE OF POINT")]
    public float typeOfMissionPoint;  //1.Normal  2.Hard  3.Large
    
    [Header("MISSIONS LIST")]
    public GameObject[] missions;
    public GameObject[] hardMissions;
    public GameObject[] largeMissions;

    [Header("MISSIONS TEXT")]
    public GameObject[] texts;
    public GameObject[] hardTexts;
    public GameObject[] largeTexts;

    [Header("WICH MISSION IS ACTIVE")]

    public float wichMissionIsActive;

    [Header("AUTOMATIC ELEMENT")]
    
    public GameObject  missionManager;
    public GameObject player;

    //public bool empty;
    void Start()
    {
        //MISSIOINS
        missions = GameObject.FindGameObjectsWithTag("Mission");
        hardMissions = GameObject.FindGameObjectsWithTag("HardMission");
        largeMissions = GameObject.FindGameObjectsWithTag("LargeMission");

        //TEXTS
        texts = GameObject.FindGameObjectsWithTag("MissionTextPause");
        hardTexts = GameObject.FindGameObjectsWithTag("MissionHardTextPause");
        largeTexts = GameObject.FindGameObjectsWithTag("MissionLargeTextPause");

        //MISSION MANAGER
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       //POINT CONTROLLER
       PointController();
    }


    //POINT CONTROLLER

    void PointController()
    {
        switch(typeOfMissionPoint)
        {
            case 1: PointOneLogic(); break;
            case 2: PointTwoLogic(); break;
            case 3: PointThreeLogic(); break;
        }
    }
    //WICH MISSION IS ACTIVE
    float WichMissionIsActive()
    {
        foreach(GameObject mis in missions)
        {
            if(mis.GetComponent<MissionCommonScript>().missionActive && !mis.GetComponent<MissionCommonScript>().completed)
            {
                wichMissionIsActive = mis.GetComponent<MissionCommonScript>().missionType;
            }
        }

        return wichMissionIsActive;
    }

    //ACTIVATE ONLY THE MISSION I WANT
    void ActiveTextMission()
    {
        foreach(GameObject txt in texts)
        {
            if(txt.GetComponent<HUD_MissionsScipt>().missionNum == wichMissionIsActive)
            {
                txt.gameObject.SetActive(true);
            }
            else
            {
                txt.gameObject.SetActive(false);
            }
        }
    }

    //DESACTIVATE ALL MISSIONS
    void DesactivateAllNormal()
    {
        foreach(GameObject txt in texts)
        {
            txt.gameObject.SetActive(false);
        }
    }
    

    void PointOneLogic()
    {
        if(!missionManager.GetComponent<MissionManager>().stopMissions)
        {
            //----------------CHECK WICH MISSION IS ACTIVE----------------
            WichMissionIsActive();

            //-------------------

            //----------------ACTIVE THE TEXT MISSION------------------
            ActiveTextMission();

            //-----------------
        }
        else
        {
            DesactivateAllNormal();
        }
    }

    //WICH HARD MISSION IS ACTIVE
    float WichHardMissionIsActive()
    {
        
        foreach(GameObject mis in hardMissions)
        {
            if(mis.GetComponent<MissionCommonScript>().missionActive && !mis.GetComponent<MissionCommonScript>().completed && !mis.GetComponent<MissionCommonScript>().fail)
            {
                wichMissionIsActive = mis.GetComponent<MissionCommonScript>().missionType;

            }
        }
      
        return wichMissionIsActive;
    }

    //ACTIVATE ONLY THE HARD MISSION I WANT
    void ActiveTextHardMission()
    {
        foreach(GameObject txt in hardTexts)
        {
            if(txt.GetComponent<HUD_MissionsScipt>().missionNum == wichMissionIsActive)
            {
                txt.gameObject.SetActive(true);
            }
            else
            {
                txt.gameObject.SetActive(false);
            }
        }
    }

    //DESACTIVATE ALL MISSIONS
    void DesactivateAllHard()
    {
        foreach(GameObject txt in hardTexts)
        {
            txt.gameObject.SetActive(false);
        }
    }
    void PointTwoLogic()
    {
        if(!missionManager.GetComponent<MissionManager>().stopHardMissions)
        {
            //----------------CHECK WICH MISSION IS ACTIVE----------------
               
            WichHardMissionIsActive();
            

            //-------------------

            //----------------ACTIVE THE TEXT MISSION------------------
            ActiveTextHardMission();

            //-----------------
        }
        else
        {
            DesactivateAllHard();
        }
    }

    //WICH HARD MISSION IS ACTIVE
    float WichLargeMissionIsActive()
    {
        foreach(GameObject mis in largeMissions)
        {
            if(mis.GetComponent<MissionCommonScript>().missionActive && !mis.GetComponent<MissionCommonScript>().completed && !mis.GetComponent<MissionCommonScript>().fail)
            {
                wichMissionIsActive = mis.GetComponent<MissionCommonScript>().missionType;
            }
        }

        return wichMissionIsActive;
    }

    //ACTIVATE ONLY THE HARD MISSION I WANT
    void ActiveTextLargeMission()
    {
        foreach(GameObject txt in largeTexts)
        {
            if(txt.GetComponent<HUD_MissionsScipt>().missionNum == wichMissionIsActive)
            {
                txt.gameObject.SetActive(true);
            }
            else
            {
                txt.gameObject.SetActive(false);
            }
        }
    }

    //DESACTIVATE ALL MISSIONS
    void DesactivateAllLarge()
    {
        foreach(GameObject txt in largeTexts)
        {
            txt.gameObject.SetActive(false);
        }
    }
    void PointThreeLogic()
    {
        if(!missionManager.GetComponent<MissionManager>().stopLargeMissions)
        {
            //----------------CHECK WICH MISSION IS ACTIVE----------------
            WichLargeMissionIsActive();

            //-------------------

            //----------------ACTIVE THE TEXT MISSION------------------
            ActiveTextLargeMission();

            //-----------------
        }
        else
        {
            DesactivateAllLarge();
        }
    }
    
}
