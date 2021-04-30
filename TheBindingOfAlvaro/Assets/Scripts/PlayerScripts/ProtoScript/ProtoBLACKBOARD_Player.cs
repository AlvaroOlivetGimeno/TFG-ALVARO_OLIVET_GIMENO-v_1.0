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

    [Header("PARRY COLLIDER:")]

    public GameObject p_Collider;

    [Header("SUPER KILL COLLIDER:")]

    public GameObject sK_Collider;


    [Header("AUTOMATIC OBJECTS:")]
    public GameObject mCamera;

    [Header("AUTOMATIC BOOLS:")]
    public bool invertControls;
    public bool blackScreen;


    [Header("CHARACTER VARIABLES FOR MISSIONS OR INDICATORS:")]
    public float numOfRoomsSeenInTheLevel; //ES CALCULA A CAMERA POINT
    public int numOfParrysDone;  //ES CALCULA A ENEMY TORRET, A REVOTE();

    public int totalEnemysKilled;

    public int basicTorretKilled;
    public int bounceTorretKilled;
    public int intelligentTorretKilled;
    public int basicFollowerKilled;
    public int unityFollowerKilled;
    public int spawnerFollowerKilled;
    public int inverterKilled;
    public int squidKilled;
    public int mothersKilled;


    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");

        sK_Collider.gameObject.SetActive(false);
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
