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
    



    void Start()
    {
        
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
            Debug.Log("MISSIONS TOTES FETES");          
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
    
    
}
