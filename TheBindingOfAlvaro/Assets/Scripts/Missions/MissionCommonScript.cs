using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCommonScript : MonoBehaviour
{
    [Header("NUM. OF MISSION:")]
    public float missionType; //1.Salas  2.Parrys  3.Enemys  4.No pierdas vida  5.Pasar nivell en x temps  6.matar x enemics en x temps
                              //7.Vida al max      8.Velocitat al maxim   9.speed al max 

    [Header("REWARD OF THE MISSION:")]
    public float reward;


    [Header("IS THIS MISION ACTIVE?")]
    public bool missionActive;

    //[Header("RECICLABLE MISSION??")]
    // public bool recicle;
    
    [Header("MISSION COMPLETED?")]
    public bool completed = false;

    [Header("MISSION FAILED?")]
    public bool fail = false;
    public bool anuled = false;

    [Header("DOES YOUR MOTHER KNOW THAT YOUR OUT?")]
    public bool motherKnow = false;

    [Header("AUTOMATIC VARIABLES (MIISON 2):")]
    public int parrysToDo;

    //Variables d'altres scripts

    [Header("AUTOMATIC VARIABLES (MIISON 3):")]
    public int enemysToKill;

    [Header("AUTOMATIC VARIABLES (MIISON 3):")]
    public int enemyChossen;
    public int choosenEnemyToKill;

    [Header("AUTOMATIC VARIABLES (MIISON 4):")]
    public float lifesAtMoment;
    public bool failDontLoosingLife;

    [Header("AUTOMATIC VARIABLES (MIISON 5 + 6):")]
    public float seconds;
    public float minuts;
    public float enemysToKillMissionSix;

    [Header("AUTOMATIC VARIABLES (MIISON 7):")]
    public float speed;
    public float MAXSpeed;

    [Header("AUTOMATIC VARIABLES (MIISON 8):")]
    public float life;
    public float MAXLife;

    [Header("AUTOMATIC VARIABLES (MIISON 9):")]
    public float delayToShoot;
    public float MINDelayToShoot;
    

    [Header("AUTOMATIC VARIABLES (OTHER OBJECTS):")]
    public GameObject player;
    public GameObject roomBrain;
    public GameObject missionFeedback;

    //ALTRES  VARIABLES

    bool oneTime;

    //REWARD VARIABLES

    bool sumMoneyOneTime;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        roomBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        missionFeedback = GameObject.FindGameObjectWithTag("MissionFeedbackManager");

        StartMetod();
    }

    // Update is called once per frame
    void Update()
    {
        if(!anuled)
        {
            //--------------------------MISSION CONTROLLER-----------------------
            MissionChooser();
        
            //--------------

            //--------------------------MISSION COMPLETED-----------------------
            MissionCompleted();

            //-------------

            //---------------------------SUM REWARD----------------------------
           

            //-------------
        }
        

        
    }

    //START METODH
    public void StartMetod()
    {
        switch(missionType)
        {
            case 1: break;
            case 2: parrysToDo = Random.Range(5,player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysToDoInTheMission); break;
            case 3: enemysToKill = Random.Range(10,player.GetComponent<ProtoBLACKBOARD_Player>().numOfEnemysToKillInTheMission); break;
            case 4: player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs = false;
                    lifesAtMoment = player.GetComponent<ProtoBLACKBOARD_Player>().characterLife; break;
            case 5: player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs = false; 
                    minuts = player.GetComponent<ProtoBLACKBOARD_Player>().minutsForMision5;    
                    seconds = player.GetComponent<ProtoBLACKBOARD_Player>().secondsForMision5;break;
            case 6: player.GetComponent<ProtoBLACKBOARD_Player>().contactWithShopOrSpecialRoom = false; 
                    minuts = player.GetComponent<ProtoBLACKBOARD_Player>().minutsForMision6;    
                    seconds = player.GetComponent<ProtoBLACKBOARD_Player>().secondsForMision6;break;
            case 7: speed = player.GetComponent<ProtoBLACKBOARD_Player>().characterSpeed;
                    MAXSpeed = player.GetComponent<ProtoBLACKBOARD_Player>().MAXSpeed; break;
            case 8: life = player.GetComponent<ProtoBLACKBOARD_Player>().characterLife;
                    MAXLife = player.GetComponent<ProtoBLACKBOARD_Player>().MAXLife; break;
            case 9: delayToShoot = player.GetComponent<ProtoBLACKBOARD_Player>().delayTimeToShoot;
                    MINDelayToShoot = player.GetComponent<ProtoBLACKBOARD_Player>().MINIMDelay; break;
            
        }
    }
    
    //MISSION COMPLETED
    void MissionCompleted()
    {
        if(completed)
        {
            if(!fail)
            {
                if(!oneTime)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney += reward;
                    player.GetComponent<ProtoBLACKBOARD_Player>().characterMoneyThatPlayerWin += reward;
                    missionFeedback.GetComponent<MissionFeedback>().MissionCompleted();
                    oneTime = true;
                }
            }
            else
            {
                if(!oneTime)
                {
                    missionFeedback.GetComponent<MissionFeedback>().MissionFailed();
                    oneTime = true;
                }
            }  
        }
    }
    
    //Mission Controller
    void MissionChooser()
    {
        switch(missionType)
        {
            case 1: Mission1(); break;
            case 2: Mission2(); break;
            case 3: Mission3(); break;
            case 4: Mission4(); break;
            case 5: Mission5(); break;
            case 6: Mission6(); break;
            case 7: Mission7(); break;
            case 8: Mission8(); break;
            case 9: Mission9(); break;
        }
    }

    //MISSION's
    void Mission1()
    {
        //INVESTIGA TOTES LES SALES DE UN PIS.
        if(missionActive)
        {
            SumRewardIfMissionIsActive();

            if(roomBrain.GetComponent<RoomTemplates>().MapIsFinished)
            {
                if(player.GetComponent<ProtoBLACKBOARD_Player>().numOfRoomsSeenInTheLevel  == (roomBrain.GetComponent<RoomTemplates>().sizeOfList +1))
                {
                    completed = true;
                }
            }
        }
        
 
    }

    void Mission2()
    {
        
        if(missionActive)
        {
            SumRewardIfMissionIsActive();

            //REBOTA 'x' cops una bala amb parry
            if(player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysDoneForMission >= parrysToDo)
            {
                
                completed = true;
            }
        }
        

    }

    void Mission3()
    {
        if(missionActive)
        {
            SumRewardIfMissionIsActive();

            //MATAR 'x' ENEMICS EN UN PIS

            if(enemysToKill <= player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission)
            {
                completed = true;
            }
        }
        
    }
    void Mission4()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions)
        {
            SumRewardIfMissionIsActive();

            if(player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs && player.GetComponent<ProtoBLACKBOARD_Player>().characterLife >= lifesAtMoment)
            {
                completed = true;
            }
            else if(player.GetComponent<ProtoBLACKBOARD_Player>().characterLife < lifesAtMoment)
            {
                fail = true;
                completed = true;
            }
        }   
    }
    void Mission5()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions)
        {
            SumRewardIfMissionIsActive();

            Clock();
            if(player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs && minuts >= 0 && seconds >= 0)
            {
                completed = true;
            }
            else if(minuts <= 0 && seconds <= 0)
            {
                fail = true;
                completed = true;
            }
        }
    }
    void Mission6()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions)
        {
            SumRewardIfMissionIsActive();

            Clock();
            if(player.GetComponent<ProtoBLACKBOARD_Player>().contactWithShopOrSpecialRoom && minuts >= 0 && seconds >= 0)
            {
                completed = true;
            }
            else if(minuts <= 0 && seconds <= 0)
            {
                fail = true;
                completed = true;
            }
        }   
    }

    void Mission7()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions)
        {
            SumRewardIfMissionIsActive();

            if(speed>= MAXSpeed)
            {
                completed = true;
            }
        }
    }

     void Mission8()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions)
        {
            SumRewardIfMissionIsActive();

            if(life>= MAXLife)
            {
                completed = true;
            }
        }
    }

     void Mission9()
    {
        if(missionActive && player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions)
        {
            SumRewardIfMissionIsActive();

            if(delayToShoot <= MINDelayToShoot)
            {
                completed = true;
            }
        }
    }


    //Final contdown
   void Clock()
    {
       seconds -= 1 * Time.deltaTime;
       if(seconds <= 0)
       {
           if(minuts <= 0)
           {
               
           }
           else
           {
               minuts -= 1;
               seconds = 60;
           }
       }
    }

    //SUM REWARD
    void SumRewardIfMissionIsActive()
    {
        if(!sumMoneyOneTime)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().totalMoneyOnTheGameThatPlayerCanWin += reward;
            sumMoneyOneTime = true;
        }
    }


    //RESTART METODH
    public void RestartMetodh()
    {
        StartMetod();
        fail = false;
        anuled = false;
        missionActive = false;
        completed = false;
        oneTime = false;
        motherKnow = false;
    }
    
    









}
