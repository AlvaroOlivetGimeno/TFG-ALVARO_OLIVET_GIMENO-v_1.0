using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
   
    [Header("NUM. OF MISSIONS IN TOTAL:")]
    public float numTotalMissionsActive;

    public float numTotalHardMissionsActive;

    [Header("MISSION's -NORMAL-")]

    public GameObject[] missions;

    [Header("MISSION's -HARD-")]

    public GameObject[] hardMissions;

    int rndVar;

    int missionsActive;
    int hardMissionsActive;

    [Header("MISSION's COMPLETED")]  
    public int missionsDone;
    public int hardMissionsDone;
    public bool stopMissions;
    public bool stopHardMissions;
    
    
    GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        missions = GameObject.FindGameObjectsWithTag("Mission");
        hardMissions = GameObject.FindGameObjectsWithTag("HardMission");
        
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------CHOOSE RANDOM MISSION----------------------------  
        ChooseRandomMision();
        ChooseRandomHardMision();

        //------------------

        //---------------------------CHECK IF ITS COMPLETED---------------------------
        CheckIfItsCompleted();

        //---------------------

    }

    //Choose Mision Randomly
    void ChooseRandomMision()
    {
        if(missionsDone != missions.Length)
        {
            if(numTotalMissionsActive > missions.Length)
            {
                Debug.LogWarning("CUIDADO! NO TIENES TANTAS MISIONES!");
            }
            else
            {
                if(missionsActive < numTotalMissionsActive)
                {
                    rndVar = Random.Range(0,missions.Length);

                    if(!missions[rndVar].GetComponent<MissionCommonScript>().missionActive && !missions[rndVar].GetComponent<MissionCommonScript>().completed)
                    {
                        missions[rndVar].GetComponent<MissionCommonScript>().missionActive = true;
                        ActiveMissionInPlayerBlackBoard(missions[rndVar].GetComponent<MissionCommonScript>().missionType);
                        missionsActive++;
                    }
                    else
                    {
                        ChooseRandomMision();
                    }
                }
                else
                {
                    //Debug.Log("SE ACABO");
                }
            }
        }
        else
        {
            stopMissions = true;      
        }  
    }

    void ChooseRandomHardMision()
    {
        if(hardMissionsDone != hardMissions.Length)
        {
            if(numTotalHardMissionsActive > hardMissions.Length)
            {
                Debug.LogWarning("CUIDADO! NO TIENES TANTAS MISIONES!");
            }
            else
            {
                if(hardMissionsActive < numTotalHardMissionsActive)
                {
                    rndVar = Random.Range(0,hardMissions.Length);

                    if(!hardMissions[rndVar].GetComponent<MissionCommonScript>().missionActive && !hardMissions[rndVar].GetComponent<MissionCommonScript>().completed)
                    {
                        hardMissions[rndVar].GetComponent<MissionCommonScript>().missionActive = true;
                        ActiveMissionInPlayerBlackBoard(hardMissions[rndVar].GetComponent<MissionCommonScript>().missionType);
                        hardMissionsActive++;
                    }
                    else
                    {
                        ChooseRandomHardMision();
                    }
                }
                else
                {
                    //Debug.Log("SE ACABO");
                }
            }
        }
        else
        {
            stopHardMissions = true;      
        }
        
        
    }
    //ACTIVE MISSION IN BLACBOARD
    void ActiveMissionInPlayerBlackBoard(float x)
    {
        switch(x)
        {
            case 2:  player.GetComponent<ProtoBLACKBOARD_Player>().parryMissionActive = true;  break;
            case 3:  player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive = true;  break;
        }
    }

    //Check if its active and complete
    void CheckIfItsCompleted()
    {
        foreach(GameObject mis in missions)
        {
            if(mis.GetComponent<MissionCommonScript>().completed && mis.GetComponent<MissionCommonScript>().missionActive && !mis.GetComponent<MissionCommonScript>().motherKnow)
            {
                missionsActive = missionsActive -1;
                missionsDone += 1;
                mis.GetComponent<MissionCommonScript>().motherKnow = true;
            }
        }
        
        foreach(GameObject mis in hardMissions)
        {
            if(mis.GetComponent<MissionCommonScript>().completed && mis.GetComponent<MissionCommonScript>().missionActive && !mis.GetComponent<MissionCommonScript>().motherKnow)
            {
                hardMissionsActive = hardMissionsActive -1;
                hardMissionsDone += 1;
                mis.GetComponent<MissionCommonScript>().motherKnow = true;
                
                foreach(GameObject ms in hardMissions)
                {
                    ms.GetComponent<MissionCommonScript>().anuled = true;
                }
                
                stopHardMissions = true;
            }
        }
        
    }

    //REINICIATE MISIONS
    public void RestartMisions()
    {
        player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysDoneForMission = 0;
        player.GetComponent<ProtoBLACKBOARD_Player>().numOfRoomsSeenInTheLevel = 0;
        player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission = 0;
        player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs = false;

        foreach(GameObject mis in missions)
        {
            missionsDone = 0;
            missionsActive = 0;
            stopMissions = false;
            //RESET BLACBOARD PLAYER VARIABLES
           
            mis.GetComponent<MissionCommonScript>().RestartMetodh();
           
        }
        foreach(GameObject mis in hardMissions)
        {
            hardMissionsDone = 0;
            hardMissionsActive =  0;
            stopHardMissions = false;
           
            mis.GetComponent<MissionCommonScript>().RestartMetodh();
           
        }
        
    }
    
    
}
