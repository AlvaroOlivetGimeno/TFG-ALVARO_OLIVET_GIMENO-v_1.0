using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBrainScript : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public GameObject player;

    public GameObject enemyBrain;

    public GameObject roomManager;

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
    
}
