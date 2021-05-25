using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBrainScript : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public GameObject player;

    public GameObject enemyBrain;

    public GameObject roomManager;

    [Header("PLAYER PCT:")]

    public float pctMon;
    public float pctGameplay;
    public float pctAction;
    public float pctInteraction;

    [Header("PLAYER TAXONOMY POSITION:")]

    public float xPos;
    public float yPos;

    [Header("1.Num of Room's -INDICATORS-")]
    [Header("GAMEPLAY/MON -INDICATORS-")]
    [Header("INDICATORS VARIABLES")]
    public float roomsSeen;
    public float totalRooms;
    public float roomPctMon;
    public float roomPctGameplay;

    [Header("2.Num of Cristal's -INDICATORS-")]

    public float cristalsFound;
    public float totalCristals;
    public float cristalPctMon;
    public float cristalPctGameplay;

    [Header("3.Num of Money -INDICATORS-")]

    public float moneyWin;
    public float totalMoneyYouCanWin;
    public float moneyPctMon;
    public float moneyPctGameplay;

    [Header("4.Num of Money Wasted -INDICATORS-")]

    public float moneyWasted;
    public float totalMoneyOfThePlayer;
    public float wastedMoneyPctMon;
    public float wastedMoneyPctGameplay;

    [Header("5.Num of SpecialHabilityCatch -INDICATORS-")]

    public bool specialHabilityCatch;
    public float specialHabilityPctMon;
    public float specialHabilityPctGameplay;

    [Header("6.Num of Enemys's Killed -INDICATORS-")]
    [Header("ACTION/INTERACTION -INDICATORS-")]
    
    public float totalEnemysKilled;
    public float totalOfEnemys;
    public float enemysKilledPctAction;
    public float enemysKilledPctInteraction;

    [Header("7.Num of Parry's Failed -INDICATORS-")]

    public float numOfParrysDoneCorrecly;
    public float numOfParrysTried;
    public float parryPctAction;
    public float parryPctInteraction;

    [Header("8.Num of Live Loosed -INDICATORS-")]

    public float actualLive;
    public float totalLivePlayerCanHave;
    public float livePctAction;
    public float livePctInteraction;

    [Header("9.Num of Bullet's -INDICATORS-")]

    public float hittedBullet;
    public float totalBulletsShooted;
    public float bulletPctAction;
    public float bulletPctInteraction;

    [Header("10.Num of Bullet's -INDICATORS-")]

    public float numOfEnemyRoomsCompleted;
    public float totalenemyRooms;
    public float enemyRoomPctAction;
    public float enemyRoomPctInteraction;

    
    [Header("1.NUM OF ROOM's SUMATOR: ")]
    [Header("DIFICULTY VARIABLES:")]
    public float numOfRoomsSumator;

    [Header("2.ENEMY's LIFE SUMATOR: ")]

    public float enemyLifeSumator;

    [Header("3.ENEMY's -SHOOTER's- DELAY TO SHOOT RESTATOR: ")]

    public float enemyShooterDelayToShootRestator;

    [Header("4.ENEMY's -FOLLOWER's- VELOCITY SUMATOR: ")]

    public float enemyFollowerSpeedSumator;

    [Header("5.ENEMY's -SPECIAL- TIMER's: ")]

    public float enemySpecialTimeMotherSpawnRestator;

    public float playerAfectedTimeSumator;

    [Header("TAXONOMY BOOL's:")]

    public bool actionProfile;
    public bool maestryProfile;
    public bool creativityProfile;
    public bool achievementProfile;



    [Header("DON'T LOOK AT THIS (STUPID VARIABLE)")]

    public float counter = 0;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");
        roomManager = GameObject.FindGameObjectWithTag("RoomBrain");

    }

    // Update is called once per frame
    void Update()
    {
        //INDICATORS:
        IndicatorUpdate();

        //GLOBAL PCT:
        GlobalPctUpdate();

        //POSITION:
        PositionUpdate();


    }

    //INDICATOR UPDATE

    void IndicatorUpdate()
    {
        //--------------------------------------MON + GAMEPLAY----------------------------------------
        Indicator1(); //ROOMS
        Indicator2(); //CRISTALS;
        Indicator3(); //MONEY
        Indicator4(); //MONEY WASTED
        Indicator5(); //SPECIAL HABILITY
        //--------------------------------------------------------------------------------------------

        //----------------------------------ACTION + INTERACTION--------------------------------------
        Indicator6(); //ENEMYS KILLED
        Indicator7(); //PARRYS DONE
        Indicator8(); //LIVE 
        Indicator9(); //BULLETS
        Indicator10(); //ENEMY ROOMS
        //--------------------------------------------------------------------------------------------
    }

    void Indicator1()
    {
        roomsSeen = player.GetComponent<ProtoBLACKBOARD_Player>().numOfRoomsSeenInTheLevel;
        totalRooms = roomManager.GetComponent<RoomTemplates>().sizeOfList;

        roomPctMon = (roomsSeen/totalRooms) * 100;

        roomPctGameplay = 100 - roomPctMon;
    }

    void Indicator2()
    {
        cristalsFound = player.GetComponent<ProtoBLACKBOARD_Player>().cristalsFound;
        totalCristals = player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel;

        cristalPctMon = (cristalsFound/totalCristals) * 100;

        cristalPctGameplay = 100 - cristalPctMon;
    }

    void Indicator3()
    {
        moneyWin = player.GetComponent<ProtoBLACKBOARD_Player>().characterMoneyThatPlayerWin;
        totalMoneyYouCanWin = player.GetComponent<ProtoBLACKBOARD_Player>().totalMoneyOnTheGameThatPlayerCanWin;

        moneyPctMon = (moneyWin/totalMoneyYouCanWin) * 100;

        moneyPctGameplay = 100 - moneyPctMon;
    }

    void Indicator4()
    {
        moneyWasted = player.GetComponent<ProtoBLACKBOARD_Player>().moneyWastedInShop;
        totalMoneyOfThePlayer = player.GetComponent<ProtoBLACKBOARD_Player>().characterMoneyThatPlayerWin;

        wastedMoneyPctMon = (moneyWasted/totalMoneyOfThePlayer) * 100;

        wastedMoneyPctGameplay = 100 - wastedMoneyPctMon;
    }
    
    void Indicator5()
    {
        specialHabilityCatch = player.GetComponent<ProtoBLACKBOARD_Player>().iHaveFoundOrBuyAnSpecialHability;
        
        if(specialHabilityCatch)
        {
            specialHabilityPctMon = 100;
            specialHabilityPctGameplay = 0;
        }
        else
        {
            specialHabilityPctMon = 0;
            specialHabilityPctGameplay = 100;
        }
        
    }

    void Indicator6()
    {
        totalEnemysKilled = player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilled;
        totalOfEnemys = player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemys;

        enemysKilledPctAction = (totalEnemysKilled/totalOfEnemys) * 100;

        enemysKilledPctInteraction = 100 - enemysKilledPctAction;
    }

    void Indicator7()
    {
        numOfParrysDoneCorrecly = player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysDone;
        numOfParrysTried = player.GetComponent<ProtoBLACKBOARD_Player>().numOfParrysTried;

        parryPctInteraction = (numOfParrysDoneCorrecly/numOfParrysTried) * 100;

        parryPctAction = 100 - parryPctInteraction;
    }

    void Indicator8()
    {
        actualLive = player.GetComponent<ProtoBLACKBOARD_Player>().characterLife;
        totalLivePlayerCanHave = player.GetComponent<ProtoBLACKBOARD_Player>().characterSpaceLife;

        livePctInteraction = (actualLive/totalLivePlayerCanHave) * 100;

        livePctAction = 100 - livePctInteraction;
    }

    void Indicator9()
    {
        hittedBullet = player.GetComponent<ProtoBLACKBOARD_Player>().totalHittedBullets;
        totalBulletsShooted = player.GetComponent<ProtoBLACKBOARD_Player>().totalBulletsShooted;

        bulletPctInteraction = (hittedBullet/totalBulletsShooted) * 100;

        bulletPctAction = 100 - bulletPctInteraction;
    }

    void Indicator10()
    {
        numOfEnemyRoomsCompleted = player.GetComponent<ProtoBLACKBOARD_Player>().enemyRoomsCompleted;
        totalenemyRooms = player.GetComponent<ProtoBLACKBOARD_Player>().enemyRoomsOnMap;

        enemyRoomPctAction = (numOfEnemyRoomsCompleted/totalenemyRooms) * 100;

        enemyRoomPctInteraction = 100 - enemyRoomPctAction;
    }
    

    void GlobalPctMon()
    {
        pctMon = (roomPctMon + cristalPctMon + moneyPctMon + wastedMoneyPctMon + specialHabilityPctMon) / 5;
    }

    void GlobalPctGameplay()
    {
        pctGameplay = (roomPctGameplay + cristalPctGameplay + moneyPctGameplay + wastedMoneyPctGameplay + specialHabilityPctGameplay) / 5;
    }

    void GlobalPctAction()
    {
        pctAction = (enemysKilledPctAction + parryPctAction + livePctAction + bulletPctAction + enemyRoomPctAction) / 5;
    }

    void GlobalPctInteraction()
    {
        pctInteraction = (enemysKilledPctInteraction + parryPctInteraction + livePctInteraction + bulletPctInteraction + enemyRoomPctInteraction) / 5;
    }

    void GlobalPctUpdate()
    {
        //MON
        GlobalPctMon();

        //GAMEPLAY
        GlobalPctGameplay();

        //ACTION
        GlobalPctAction();

        //INTERACTION
        GlobalPctInteraction();
    }

    void Xpos()
    {
        xPos = (pctMon/2) + (-pctGameplay/2);
    }
    void Ypos()
    {
        yPos = (pctAction/2) + (-pctInteraction/2);
    }

    void PositionUpdate()
    {
        Xpos();
        Ypos();
    }

    public void DifficultyUprage()
    {
        //RO0M's 
        roomManager.GetComponent<RoomTemplates>().MaxNumOfRooms += numOfRoomsSumator;
        roomManager.GetComponent<RoomTemplates>().MinNumOfRooms += numOfRoomsSumator;

        //EN3MY's LIFE
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeBasic += enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeBounce +=enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeIntelligent +=enemyLifeSumator;

        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeBasic +=enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeUnity +=enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeSpawner +=enemyLifeSumator;

        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sp_InverterLife +=enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sp_SquidLife +=enemyLifeSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherLife +=enemyLifeSumator;


        //SHO0TER's DELAY:
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootBounce -= enemyShooterDelayToShootRestator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootIntelligent -= enemyShooterDelayToShootRestator;

        //FOLL0WER's SPEED:
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed += enemyFollowerSpeedSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_SpeedSpawner += enemyFollowerSpeedSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityBigSpeed += enemyFollowerSpeedSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityMedSpeed += enemyFollowerSpeedSumator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_UnitySmallSpeed += enemyFollowerSpeedSumator;

        //SP3CIAL's TIMER's:
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherTimeSpawn -= enemySpecialTimeMotherSpawnRestator;

        player.GetComponent<ProtoBLACKBOARD_Player>().timeEffectSpecialEnemysInvert += playerAfectedTimeSumator;
        player.GetComponent<ProtoBLACKBOARD_Player>().timeEffectSpecialEnemysSquid += playerAfectedTimeSumator;
        
    }

    void ActionProfile()
    {
        if(xPos <= -1 && xPos >= -50 && yPos >= 1 && yPos <= 50)
        {
            actionProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = true;
        }
        else
        {
            if(xPos>= 25 || yPos <= -25)
            {
                actionProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = false;
            }
            else
            {
                if(xPos <= -25 || yPos >= 25)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = true; 
                }
                else
                {
                    actionProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = false;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = false;
                }
            }   
        }
    }

    void MaestryProfile()
    {
        if(xPos <= -1 && xPos >= -50 && yPos <= -1 && yPos >= -50)
        {
            maestryProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 60;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = true;
            

        }
        else
        {
            if(xPos>= 25 || yPos >= 25)
            {
                maestryProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 30;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = false;
            }
            else
            {
                if(xPos <= -25 || yPos <= -25)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = true;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 60; 
                }
                else
                {
                    maestryProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = false;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 30;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = false;
                }
            }   
        }
    }

    void CreativityProfile()
    {
        if(xPos >= 1 && xPos <= 50 && yPos <= -1 && yPos >= -50)
        {
            creativityProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 20;
            
        }
        else
        {
            if(xPos <= -25 || yPos >= 25)
            {
                creativityProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 10;
            }
            else
            {
                if(xPos >= 25 || yPos <= -25)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = true; 
                }
                else
                {
                    creativityProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = false;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 10;
                }
            }   
        }
    }

     void AchievementProfile()
    {
        if(xPos >= 1 && xPos <= 50 && yPos >= 1 && yPos <= 50)
        {
            achievementProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = true;


        }
        else
        {
            if(xPos <= -25 || yPos <= -25)
            {
                achievementProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = false;
            }
            else
            {
                if(xPos >= 25 || yPos >= 25)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = true;
                }
                else
                {
                    achievementProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = false;
                }
            }   
        }
    }





    public void TaxonomyChange()
    {
        

        if(counter == 2)
        {
            Debug.Log("CALCULAAAAAAAAAANDO");
            ActionProfile();
            MaestryProfile();
            CreativityProfile();
            AchievementProfile();

            counter = 0;
        }
    }





}
