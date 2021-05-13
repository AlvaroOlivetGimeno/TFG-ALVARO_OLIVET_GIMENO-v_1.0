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

    [Header("AUTOMATIC VARIABLES (MIISON 5):")]
    public float missioinFiveTimerSeconds;
    public float missioinFiveTimerMinuts;
    

    [Header("AUTOMATIC VARIABLES (OTHER OBJECTS):")]
    public GameObject player;
    public GameObject roomBrain;
    public GameObject missionFeedback;

    //ALTRES  VARIABLES

    bool oneTime;



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
                    missioinFiveTimerMinuts = player.GetComponent<ProtoBLACKBOARD_Player>().minutsForMision5;    
                    missioinFiveTimerSeconds = player.GetComponent<ProtoBLACKBOARD_Player>().secondsForMision5;break;
            
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
                    missionFeedback.GetComponent<MissionFeedback>().MissionCompleted();
                    oneTime = true;
                }
            }
            else
            {
                //player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney += reward;
               
                missionFeedback.GetComponent<MissionFeedback>().MissionFailed();
                oneTime = true;
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
        }
    }

    //MISSION's
    void Mission1()
    {
        //INVESTIGA TOTES LES SALES DE UN PIS.
        if(missionActive)
        {
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
            //MATAR 'x' ENEMICS EN UN PIS

            if(enemysToKill <= player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission)
            {
                completed = true;
            }
        }
        
    }
    void Mission4()
    {
        if(missionActive)
        {
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
        if(missionActive)
        {
            ClockMission5();
            if(player.GetComponent<ProtoBLACKBOARD_Player>().contactWithStairs && missioinFiveTimerMinuts >= 0 && missioinFiveTimerSeconds >= 0)
            {
                completed = true;
            }
            else if(missioinFiveTimerMinuts <= 0 && missioinFiveTimerSeconds <= 0)
            {
                fail = true;
                completed = true;
            }
        }
        
    }

    //Final contdown
   void ClockMission5()
    {
       missioinFiveTimerSeconds -= 1 * Time.deltaTime;
       if(missioinFiveTimerSeconds <= 0)
       {
           if(missioinFiveTimerMinuts <= 0)
           {
               
           }
           else
           {
               missioinFiveTimerMinuts -= 1;
               missioinFiveTimerSeconds = 60;
           }
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
