using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
   
    [Header("NUM. OF MISSIONS IN TOTAL:")]
    public float numTotalMissionsActive;

    [Header("MISSION's")]

    public GameObject[] missions;

    int rndVar;

    int missionsActive;

    [Header("MISSION's COMPLETED")]  
    public int missionsDone;
    public bool stopMissions;
    
    
    GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        missions = GameObject.FindGameObjectsWithTag("Mission");
        
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------CHOOSE RANDOM MISSION----------------------------  
        ChooseRandomMision();

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
                //Destroy(mis.gameObject);
                mis.GetComponent<MissionCommonScript>().motherKnow = true;
            }
        }
    }

    //REINICIATE MISIONS
    public void RestartMisions()
    {
        foreach(GameObject mis in missions)
        {
            missionsDone = 0;
            missionsActive = 0;
            stopMissions = false;
            mis.GetComponent<MissionCommonScript>().RestartMetodh();
           
        }
    }
    
    
}
