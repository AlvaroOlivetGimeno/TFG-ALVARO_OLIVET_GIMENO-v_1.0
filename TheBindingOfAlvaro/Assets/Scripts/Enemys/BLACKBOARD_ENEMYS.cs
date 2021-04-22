using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLACKBOARD_ENEMYS : MonoBehaviour
{
    [Header("ENEMY's -SHOOTERS- CONSTANTS:")]
    public float sh_LifeBasic;
    public float sh_LifeIntelligent;
    public float sh_LifeBounce;
    public float sh_TimeToShootIntelligent;
    //public float sh_TimeToShootBasic;
    public float sh_TimeToShootBounce;
    public float sh_ParryPct;
    public float sh_TimeFreezed;
    [Header("ENEMY's -SHOOTERS- BULLETS:")]
    public GameObject sh_IntelligentBullet;
    public GameObject sh_IntelligentParryBullet;
    public GameObject sh_BasicBullet;
    public GameObject sh_ParryBullet;
    public GameObject sh_BounceParryBullet;
    public GameObject sh_BounceBullet;


    [Header("ENEMY's -FOLLOWERS- CONSTANTS:")]
    public float fl_LifeBasic;
    public float fl_BasicSpeed;
    public float fl_LifeUnity;
    public float fl_UnityBigSpeed;
    public float fl_UnityMedSpeed;
    public float fl_UnitySmallSpeed;
    public float fl_LifeSpawner;
    public float fl_SpeedSpawner;
    public float fl_TimeFreezed;
    public float fl_ParryPct;

    [Header("ENEMY's -FOLLOWERS- ENEMY:")]
    public GameObject fl_TorretEnemy1;
    public GameObject fl_TorretEnemy2;

    [Header("ENEMY's -FOLLOWERS- CHILDRENS:")]
    public GameObject mediumUnityEnemy;
    public GameObject smallUnityEnemy;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
