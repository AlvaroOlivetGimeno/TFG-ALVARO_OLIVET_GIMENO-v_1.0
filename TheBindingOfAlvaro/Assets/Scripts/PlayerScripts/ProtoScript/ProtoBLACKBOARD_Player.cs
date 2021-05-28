using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoBLACKBOARD_Player : MonoBehaviour
{
    [Header("CHARACTER GENERAL VARIABLES:")]

    public float actualLevel = 1;
    public float characterSpeed;
    public float delayTimeToShoot;
    public float characterMoney;
    public float characterCristals;
    public float timeOfParry;
    public float habilityType = 0; //0.NADA  1.DOBLE TIR  2.TIR SIMULTANI 3.TIR SUPERIOR  4.TIR CONGELANT   5.SUPER TIR  6.MINIMUM  7.MAXIMUM
    public float stateType = 0; //0.Nada  1.Minimum    2.Maximum    
    public float specialStateType = 0; //1.inbulnerabilitat 2.Tir Quadruple 3.TotalParry 4.Depredador 5.SuperKill
    public float specialHabilityCatcth = 0;
    public float characterLife;
    public float characterSpaceLife;
    public float MINIMDelay;
    public float MAXSpeed;
    public float MAXDamage;
    public float MAXLife;
    public float timeSpecialHability;
    public float timeEffectSpecialEnemysInvert;
    public float timeEffectSpecialEnemysSquid;
    public bool activePause = false;
    public bool activeLoading = false;
    public bool activeInfoMenu = false;
    public bool SpecialHabilityIsActive;

    [Header("LOADING SPECIAL HABILITY THINGS:")]
    public bool loadingSpecialHability = true;
    public float enemysKillToReloadSpecialHability;

    
    [Header("CAMARA SHAKE VARIABLES:")]

    public float duration;
    public float magnitude;

    [Header("CAMARA MAP VARIABLES:")]

    public bool cameraMapIsActive;

    [Header("CHARACTER MINIMUM-STATE VARIABLES:")]

    public float minimumSpeed;
    public Vector3 minimumScale;
    public float minimumDelayTimeToShoot;

    [Header("CHARACTER MAXIMUM-STATE VARIABLES:")]

    public float maximumSpeed;
    public Vector3 maximumScale;
    public float maximumDelayTimeToShoot;

    [Header("CHARACTER BASIC BULLET:")]

    public GameObject Bullet;
    public GameObject superiorBullet;
    public GameObject freezeBullet;
    public GameObject minimumBullet;
    public GameObject maximumBullet;
    

    [Header("POINTS OF BULLETS FOR SHOOTING:")]

    public GameObject Up;
    public GameObject Up1;
    public GameObject Up2;
    public GameObject Down;
    public GameObject Down1;
    public GameObject Down2;
    public GameObject Right;
    public GameObject Right1;
    public GameObject Right2;
    public GameObject Left;
    public GameObject Left1;
    public GameObject Left2;

    [Header("PARRY COLLIDER & PARTICLES:")]

    public GameObject p_Collider;
    public GameObject p_Particles;
    public GameObject superKill_Particles;


    [Header("SUPER KILL COLLIDER:")]

    public GameObject sK_Collider;

    [Header("SPECIAL HABILITY FEEDBACK:")]

    public Color superParryColor;
    public Color inbulnerabilityColor;
    public Color hunterColor;

    [Header("SKIN COLORS:")]
    
    public float skinColorState = 0;
    public Color green;
    public Color blue;
    public Color yellow;
    public Color white;
    public Color purple;

    [Header("SKIN TATTO SPRITE's:")]

    public float skinDrawState = 0;
    public Sprite ojoChungo;
    public Sprite tattuEye1;
    public Sprite tattuEye2;
    public Sprite tattuEye3;
    public Sprite tattuEye4;




    [Header("AUTOMATIC OBJECTS:")]
    public GameObject mCamera;
    public GameObject cameraMap;
    public GameObject feedback;

    [Header("AUTOMATIC BOOLS:")]
    public bool invertControls;
    public bool blackScreen;

    [Header("CHARACTER VARIABLES FOR MISSIONS OR INDICATORS -NOT AUTOMATICS!-:")]

    public int numOfParrysToDoInTheMission;
    public int numOfEnemysToKillInTheMission;

    [Header("CHARACTER VARIABLES FOR MISSIONS OR INDICATORS -AUTOMATICS-:")]
    
    public bool parryMissionActive;
    public float numOfRoomsSeenInTheLevel; //ES CALCULA A CAMERA POINT
    public float numOfParrysDone;  //ES CALCULA A ENEMY TORRET, A REVOTE();

    public float numOfParrysTried;
    public int numOfParrysDoneForMission;
    public bool killEnemysMissionActive;
    public int totalEnemysKilled;
    public int totalEnemysKilledForMission;
    public int basicTorretKilled;
    public int bounceTorretKilled;
    public int intelligentTorretKilled;
    public int basicFollowerKilled;
    public int unityFollowerKilled;
    public int spawnerFollowerKilled;
    public int inverterKilled;
    public int squidKilled;
    public int mothersKilled;
    public bool contactWithStairs;

    public float minutsForMision5;
    public float secondsForMision5;
    public float minutsForMision6;
    public float secondsForMision6;
    public bool contactWithShopOrSpecialRoom;

    public float cristalsFound;

    public float totalMoneyOnTheGameThatPlayerCanWin;

    public float characterMoneyThatPlayerWin ;

    public float moneyWastedInShop;

    public bool iHaveFoundOrBuyAnSpecialHability;

    public float totalEnemys;

    public float totalHittedBullets;

    public float totalBulletsShooted;

    public float enemyRoomsOnMap;

    public float enemyRoomsCompleted;



    [Header("-MISSION's-")]

    [Header("CHARACTER BOOL FOR ACTIVATE CERTAIN THINGS:")]

    public bool activeHardMissions;

    public bool activeLargeMissions;

    [Header("-SKIN's (SHOP)-")]
    public bool activeShopColorSkins;
    public bool activeShopDrawSkins;

    [Header("-SKIN's (SPECIAL ROOM)-")]
    public bool activeSpecialRoomSkins;

    [Header("-MAP-")]
    public bool activeMapMecanic;

    [Header("-PARRY SHIELD-")]
    public bool activeParryShield;

    [Header("-ENEMY TRAIL-")]
    public bool activeEnemyTrail;

    [Header("-ENEMY SUPER DAMAGE-")]
    
    public bool activeSuperDamage;

    
    



    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        feedback= GameObject.FindGameObjectWithTag("Feedback");
        cameraMap = GameObject.FindGameObjectWithTag("CameraMap");

        sK_Collider.gameObject.SetActive(false);
        cameraMap.gameObject.SetActive(false);

        actualLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //calculos que hacer
        totalEnemysKilled = basicTorretKilled + bounceTorretKilled + intelligentTorretKilled +
                            basicFollowerKilled + unityFollowerKilled + spawnerFollowerKilled +
                            inverterKilled + squidKilled + mothersKilled;
    }
}
