using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
   
    [Header("NUM. OF MISSIONS IN TOTAL:")]
    public float numTotalMissions;

    [Header("MISSIONS TEXT's PREFAB's:")]
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;

    [Header("POINTS OF PAUSE HUD:")]

    public GameObject[] pointsOfPauseHUD;

    [Header("MISSION's")]

    public GameObject[] missions;

    



    void Start()
    {
        pointsOfPauseHUD = GameObject.FindGameObjectsWithTag("PauseMissionPoint");
        missions = GameObject.FindGameObjectsWithTag("Mission");
    }

    // Update is called once per frame
    void Update()
    {
        MissionController();
    }

    //IS ANY POINT FREE
    public bool IsThereAPointFree()
    {
        foreach(GameObject point in pointsOfPauseHUD)
        {
            if(!point.GetComponent<PointForMission>().empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    //CHOOSE MISION
    GameObject ChooseMission()
    {
        foreach(GameObject mis in missions)
        {
            if(!mis.GetComponent<MissionCommonScript>().completed && !mis.GetComponent<MissionCommonScript>().active)
            {
                return mis.gameObject;
            }
        }

        return null;
        
    }



    //MISION CONTROLLER
    void MissionController()
    {
        if(IsThereAPointFree())
        {
            foreach(GameObject point in pointsOfPauseHUD)
            {
                if(!point.GetComponent<PointForMission>().empty)
                {
                    switch(ChooseMission().GetComponent<MissionCommonScript>().missionType)
                    {
                        case 1: Instantiate(txt1, point.transform.position, Quaternion.identity);
                                point.GetComponent<PointForMission>().empty = true;
                                ChooseMission().GetComponent<MissionCommonScript>().active = true;
                        break;
                        case 2: Instantiate(txt1, point.transform.position, Quaternion.identity);
                                point.GetComponent<PointForMission>().empty = true;
                                ChooseMission().GetComponent<MissionCommonScript>().active = true;
                        break;
                        case 3: Instantiate(txt1, point.transform.position, Quaternion.identity);
                                point.GetComponent<PointForMission>().empty = true;
                                ChooseMission().GetComponent<MissionCommonScript>().active = true;
                        break;
                    }
                   
                }
            }
        }
    }
}
