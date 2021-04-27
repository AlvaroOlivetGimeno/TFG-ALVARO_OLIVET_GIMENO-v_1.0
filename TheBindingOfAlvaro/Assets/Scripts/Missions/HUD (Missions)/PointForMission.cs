using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForMission : MonoBehaviour
{
    [Header("MISSIONS LIST")]
    public GameObject[] missions;

    [Header("MISSIONS TEXT")]
    public GameObject[] texts;

    [Header("WICH MISSION IS ACTIVE")]

    public float wichMissionIsActive;

    [Header("AUTOMATIC ELEMENT")]
    
    public GameObject  missionManager;

    //public bool empty;
    void Start()
    {
        missions = GameObject.FindGameObjectsWithTag("Mission");
        texts = GameObject.FindGameObjectsWithTag("MissionTextPause");
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
    }

    // Update is called once per frame
    void Update()
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
            DesactivateAll();
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
    void DesactivateAll()
    {
        foreach(GameObject txt in texts)
        {
            txt.gameObject.SetActive(false);
        }
    }



    
    
}
