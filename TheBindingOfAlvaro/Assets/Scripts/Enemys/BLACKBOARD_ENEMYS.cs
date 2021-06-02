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

    [Header("ENEMY's -SPECIAL- CONSTANTS:")]
    public float sp_InverterLife;
    public float sp_SquidLife;
    public float sp_MotherLife;
    public float sp_MotherTimeSpawn;
    public float sp_MotherChildSpeed;
    public float sp_MotherChildLife;

    [Header("SHOOTER -DEATH- PARTICLES:")]
    [Header("ENEMY's DEATH PARTICLES:")]
    public GameObject sh_basicDeathP;
    public GameObject sh_bounceDeathP;
    public GameObject sh_intelligentDeathP;

    [Header("FOLLOWER -DEATH- PARTICLES:")]
    public GameObject fl_basicDeathP;
    public GameObject fl_spawnDeathP;
    public GameObject fl_unity1DeathP;
    public GameObject fl_unity2DeathP;
    public GameObject fl_unity3DeathP;

    [Header("SPECIAL -DEATH- PARTICLES:")]
    public GameObject sp_inverterDeathP;
    public GameObject sp_squidDeathP;
    public GameObject sp_motherDeathP;
    public GameObject sp_childDeathP;

    

    [Header("ENEMY's -SPECIAL- PARTICLES:")]
    public GameObject freezeParticles;

    [Header("ENEMY's -SPECIAL- PARTICLES:")]
    public GameObject sp_ParticlesInverter;
    public GameObject sp_ParticlesSquid;
    public GameObject sp_ParticlesMother;

    [Header("ENEMY's -SPECIAL- ENEMY's:")]
    public GameObject sp_LittleMother;


    [Header("ENEMY's ROOM VARIABLES:")]

    public float enemyRoomPct;
    public float closeDoorsPct;
    public float spawnEnemyPct;
    public float spawnObstacle;

    [Header("ENEMY's -SHOOTERS- PREFABS:")]

    public GameObject basicShooter;
    public GameObject inteligentShooter;
    public GameObject bounceShooter;

    [Header("ENEMY's -FOLLOWERS- PREFABS:")]

    public GameObject basicFollower;
    public GameObject unityFollower;
    public GameObject spawnFollower;

    [Header("ENEMY's -SHOOTERS- PREFABS:")]

    public GameObject inverterSpecial;
    public GameObject squidSpecial;
    public GameObject motherSpecial;

    [Header("ENEMY's -OBSTACLES- PREFABS:")]

    public GameObject wallObstacle;
    public GameObject spikeObstacle;

    [Header("ENEMY's -TYPE ON ROOM- PREFABS:")]
    
    public GameObject shooterRoom;
    public GameObject followerRoom;
    public GameObject superRoom;


    [Header("ENEMY's -PICABLE OBJECT's- PREFABS:")]

    public float spawnObjectPct;
    public GameObject coin;
    public GameObject life;

    [Header("ENEMY's -TRAIL- PREFABS:")]
    
    public float timeToSpawnTrail;
    public GameObject f_BasicTrail;
    public GameObject f_UnityTrail;
    public GameObject f_SpawnerTrail;

    [Header("ENEMY's INDICATOR VARIABLES:")]

    public bool activeEnemysEveryWhere;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemysEveryWhere();
    }

    void EnemysEveryWhere()
    {
        if(!activeEnemysEveryWhere)
        {
            enemyRoomPct = 50;
            closeDoorsPct = 50;
            spawnEnemyPct = 50;
        }
        else
        {
            enemyRoomPct = 85;
            closeDoorsPct = 85;
            spawnEnemyPct = 100;
        }
    }
}
