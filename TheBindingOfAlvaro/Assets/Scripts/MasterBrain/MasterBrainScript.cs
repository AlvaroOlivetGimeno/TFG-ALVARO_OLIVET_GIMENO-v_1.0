using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBrainScript : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public GameObject player;

    public GameObject enemyBrain;

    public GameObject roomManager;

    public GameObject bsoSoundManager;

    [Header("PLAYER PCT [EJES]:")]

    public float pctMon = 0;
    public float pctGameplay= 0;
    public float pctAction= 0;
    public float pctInteraction= 0;

    [Header("PLAYER TAXONOMY POSITION:")]

    public float xPos= 0;
    public float yPos= 0;

    [Header("PLAYER PCT [PROFILES]:")]

    public float pctProfileAction = 0;
    public float pctProfileMaestry= 0;
    public float pctProfileAchievement= 0;
    public float pctProfileCreativity= 0;

    [Header("1.Num of Room's -INDICATORS-")]
    [Header("GAMEPLAY/MON -INDICATORS-")]
    [Header("INDICATORS VARIABLES")]
    public float roomsSeen= 0;
    public float totalRooms= 0;
    public float roomPctMon= 0;
    public float roomPctGameplay= 0;

    [Header("2.Num of Cristal's -INDICATORS-")]

    public float cristalsFound= 0;
    public float totalCristals= 0;
    public float cristalPctMon= 0;
    public float cristalPctGameplay= 0;

    [Header("3.Num of Money -INDICATORS-")]

    public float moneyWin= 0;
    public float totalMoneyYouCanWin= 0;
    public float moneyPctMon= 0;
    public float moneyPctGameplay= 0;

    [Header("4.Num of Money Wasted -INDICATORS-")]

    public float moneyWasted= 0;
    public float totalMoneyOfThePlayer= 0;
    public float wastedMoneyPctMon= 0;
    public float wastedMoneyPctGameplay= 0;

    [Header("5.Num of SpecialHabilityCatch -INDICATORS-")]

    public bool specialHabilityCatch;
    public float specialHabilityPctMon= 0;
    public float specialHabilityPctGameplay= 0;

    [Header("6.Num of Enemys's Killed -INDICATORS-")]
    [Header("ACTION/INTERACTION -INDICATORS-")]
    
    public float totalEnemysKilled= 0;
    public float totalOfEnemys= 0;
    public float enemysKilledPctAction= 0;
    public float enemysKilledPctInteraction= 0;

    [Header("7.Num of Parry's Failed -INDICATORS-")]

    public float numOfParrysDoneCorrecly= 0;
    public float numOfParrysTried= 0;
    public float parryPctAction= 0;
    public float parryPctInteraction= 0;

    [Header("8.Num of Live Loosed -INDICATORS-")]

    public float actualLive= 0;
    public float totalLivePlayerCanHave= 0;
    public float livePctAction= 0;
    public float livePctInteraction= 0;

    [Header("9.Num of Bullet's -INDICATORS-")]

    public float hittedBullet= 0;
    public float totalBulletsShooted= 0;
    public float bulletPctAction= 0;
    public float bulletPctInteraction= 0;

    [Header("10.Num of Bullet's -INDICATORS-")]

    public float numOfEnemyRoomsCompleted= 0;
    public float totalenemyRooms= 0;
    public float enemyRoomPctAction= 0;
    public float enemyRoomPctInteraction= 0;

    
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

    [Header("6.ENEMY's -FREEZE- TIMER's: ")]

    public float enemyFreezeRestator;

    [Header("TAXONOMY BOOL's:")]

    public bool actionProfile;
    public bool maestryProfile;
    public bool creativityProfile;
    public bool achievementProfile;

    [Header("POSITIONS SAVED")]

    public float posXLvl2;
     public float posYLvl2;
    public float posXLvl4;
    public float posYLvl4;
    public float posXLvl6;
    public float posYLvl6;
    public float posXLvl8;
    public float posYLvl8;
    

    [Header("FINAL POS")]

    public float finalXpos;
    public float finalYpos;

    [Header("PROFILE CHOOSEN")]
    public float choosenProfile; 

    [Header("DON'T LOOK AT THIS (STUPID VARIABLE)")]

    public float counter = 0;
    public float counter2 = 0;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");
        roomManager = GameObject.FindGameObjectWithTag("RoomBrain");
        bsoSoundManager = GameObject.FindGameObjectWithTag("BSOSoundManager");

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
        totalRooms = roomManager.GetComponent<RoomTemplates>().sizeOfList + 1;

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


    void PctProfiles()
    {
        pctProfileAction = (pctAction+ pctGameplay) / 2;
        pctProfileMaestry = (pctGameplay+ pctInteraction) / 2;
        pctProfileAchievement = (pctAction+ pctMon) / 2;
        pctProfileCreativity = (pctMon+ pctInteraction) / 2;

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

        //PCT PROFILES
        PctProfiles();
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

        //FR33ZE TIME
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeFreezed -= enemyFreezeRestator;
        enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().fl_TimeFreezed += enemyFreezeRestator;
        
    }

    void ActionProfile()
    {
        if(xPos <= 0 && xPos >= -50 && yPos >= 0 && yPos <= 50)
        {
            Debug.Log("ACTION LV2");
            actionProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = true;

        }
        else
        {
            if(xPos > 25 || yPos < -25)
            {
                Debug.Log("ACTION -FORA DELS LIMITS-");
                actionProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = false;
            }
            else
            {
                if(xPos < -0.5 && xPos >= -25 || yPos > 0.5 && yPos <= 25) //xPos entre -5 i -25 i yPos entre 5 i 25
                {
                    Debug.Log("ACTION LV1");
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = true; 
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = false;
                }
                else
                {
                    Debug.Log("ACTION -no esta entre -5 i -25 o 5 i 25-");
                    actionProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail = false;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().activeEnemysEveryWhere = false;
                }
            }   
        }
    }

    void MaestryProfile()
    {
        if(xPos <= 0 && xPos >= -50 && yPos <= 0 && yPos >= -50)
        {
            Debug.Log("MAESTRY LV2");
            maestryProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 75;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = true;
            

        }
        else
        {
            if(xPos> 25 || yPos > 25)
            {
                Debug.Log("MAESTRY -FORA DELS LIMITS-");
                maestryProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 30;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = false;
            }
            else
            {
                if(xPos < -0.5 && xPos >= -25 || yPos < -0.5 && yPos >= -25) //xPos entre -5 i -25 i yPos entre -5 i -25
                {
                    Debug.Log("MAESTRY LV1");
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield = true;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct = 75; 
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeSuperDamage = false;
                }
                else
                {
                    Debug.Log("MAESTRY -no esta entre -5 i -25 o -5 i -25-");
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
        if(xPos >= 0 && xPos <= 50 && yPos <= 0 && yPos >= -50)
        {
            Debug.Log("CREATIVITY LV2");
            creativityProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = true;
            enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 20;
            
        }
        else
        {
            if(xPos < -25 || yPos > 25)
            {
                Debug.Log("CREATIVITY -FORA DELS LIMITS-");
                creativityProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = false;
                enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 10;
            }
            else
            {
                if(xPos > 0.5 && xPos <= 25 || yPos < -0.5 && yPos >= -25) //xPos entre 5 i 25 i yPos entre -5 i -25
                {
                    Debug.Log("CREATIVITY LV1");
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins = true; 
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic = false;
                    enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct = 10;
                }
                else
                {
                    Debug.Log("CREATIVITY -no esta entre 5 i 25 o -5 i -25-");
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
        if(xPos >= 0 && xPos <= 50 && yPos >= 0 && yPos <= 50)
        { 
            Debug.Log("ACHIEVMENT LV2");
            achievementProfile = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = true;
            player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = true;

        }
        else
        {
            if(xPos < -25 || yPos < -25)
            {
                Debug.Log("ACHIEVMENT -FORA DELS LIMITS-");
                achievementProfile = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = false;
                player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = false;
            }
            else
            {
                if(xPos > 0.5 && xPos <= 25 || yPos > 0.5 && yPos <= 25) //xPos entre 5 i 25 i yPos entre 5 i 25
                {
                    Debug.Log("ACHIEVMENT LV1");
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = true;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = false;
                }
                else
                {
                    Debug.Log("ACHIEVEMENT -no esta entre 5 i 25 o 5 i 25-");
                    achievementProfile = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeHardMissions = false;
                    player.GetComponent<ProtoBLACKBOARD_Player>().activeLargeMissions = false;
                }
            }   
        }
    }

    void SumTheChoosenPorfile()
    {
        if(counter2 == 2)
        {
            posXLvl2 = xPos;
            posYLvl2 = yPos;
        }
        if(counter2 == 4)
        {
            posXLvl4 = xPos;
            posYLvl4 = yPos;
        }
        if(counter2 == 6)
        {
            posXLvl6 = xPos;
            posYLvl6 = yPos;
        }
        if(counter2 == 8)
        {
            posXLvl8 = xPos;
            posYLvl8 = yPos;
        }
       
    }

    void FinalPos()
    {
        finalXpos = (posXLvl2 + posXLvl4 + posXLvl6 + posXLvl8) / 4;
        finalYpos = (posYLvl2+ posYLvl4 + posYLvl8 + posYLvl6) / 4;
    }

    void WhooseTheBiggerProfileSumator()
    {
        FinalPos();

        if(finalXpos < 0 && finalYpos > 0)
        {
            choosenProfile = 1;
        }
        else if(finalXpos < 0 && finalYpos < 0)
        {
            choosenProfile = 2;
        }
        else if(finalXpos > 0 && finalYpos > 0)
        {
            choosenProfile = 3;
        }
        else if(finalXpos > 0 && finalYpos < 0)
        {
            choosenProfile = 4;
            
        }


    }


    public void TaxonomyChange()
    {
        if(player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel == 10)
        {
            WhooseTheBiggerProfileSumator();
        }
        else
        {
            if(counter > 1)            
            {
                MaestryProfile();
                CreativityProfile();
                AchievementProfile();
                ActionProfile();
                SumTheChoosenPorfile();
                player.GetComponent<ProtoBLACKBOARD_Player>().iHaveFoundOrBuyAnSpecialHability = false;
                specialHabilityCatch = false;
                counter = 0;
            }
        }
        
    }

 





}
