using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollowersScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0; //1.Basic  2.Unity  3.Spawner //4.HIJO DE MADRE
    [Header("CHOOSE SIZE (ONLY IF ITS TYPE 2):")]
    public float sizeType = 0; //1.Big 2.Medium 3.Small

    [Header("AUTOMATIC VARIABLES:")]
    public float life;
    public float speed;
    public float timeFreezed;

    public GameObject myCamaraPoint;
    public GameObject BlackBoardEnemy;

    public GameObject freezeFedback;


    Rigidbody2D rb2d;
    ProtoPlayerScript target;
    Vector2 moveDirection;
    Vector2 initialPos;
 

    float rndVarDelay; //first delay for shooting
    float rndVarStop; //for stopping enemy
    float stopTimer; //for stop the player
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state
    float realState; //for save the real state (remember that i change it when it colides with another enemy) :))

    float timeChill; //rnd Variable 
    float timeSprint; //rnd Variable 
    float timerForSprints; //timer for sprint
    float timerForChillTime; //timer for chill times
    bool chilling; // estado de pitipausa
    GameObject enemyTorret; //donde se guarda el enemigo
    float randomEnemy; //random enemy
    //float timerdelay = 0; //For death in state 3
    //bool oneTime = false;
    bool playerOnRoom; //For check if player is on room

    GameObject player;
    bool sumOneKill; //for sum kills

    //FOR SPAWN

    bool spawnOneTime;
    int spawnPct;
    int wichObj;

    //ENEMY TRAIL VARIABLES
    
    float enemyTrailTimer;

    //SOUND

    bool playSound = false;
    bool playFreezeSound = false;

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindObjectOfType<ProtoPlayerScript>();

        
        realState = enemyType;

        //START METOD FOR VARIABLES
        StartMetod();

        //FOR SPAWN VARIABLES:
        wichObj = Random.Range(1,3);
        spawnPct = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        //------------------CONTROLLER---------------------
        FollowController();

        //------------------LIFE LOGIC------------------------
        LifeController();

        //--------------------------FREEZE----------------------------
        Freeze();

        //------------------ENEMY TRAIL-------------------------------
        EnemyTrail();


        
        
    }

    //Follow basic function
    void Follow(GameObject x)
    {
        moveDirection = (x.transform.position - this.transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }

   //CHOOSE ENEMY
   GameObject ChooseEnemy()
   {
        if(randomEnemy == 0)
        {
            enemyTorret = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_TorretEnemy1;
        }
        else
        {
            enemyTorret = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_TorretEnemy2;
        }
        return enemyTorret;
   }

   //GAME OVER BRO
    void Explosion()
    {
        Instantiate(ChooseEnemy(), this.transform.position, Quaternion.identity);

        if(!playSound)
        {
            BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
            playSound = true;
        }
        {
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_spawnDeathP, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
  

    //Follow controller
    void FollowController()
    {
        switch(enemyType)
        {
            case 0: StopEnemyFewSeconds(); break;
            case 1: Follow(target.gameObject); break;
            case 2: Follow(target.gameObject); break;
            case 3: Follow(target.gameObject); break;
            case 4: Follow(target.gameObject); break;

            case 5: break;

        }
    }

    //Start metod
    void StartMetod()
    {
        switch (enemyType)
        {
            case 1: life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeBasic;
                    speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed;
                initialPos = this.transform.position;
                break;
            case 2:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeUnity;
                switch(sizeType)
                {
                    case 1: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityBigSpeed; break;
                    case 2: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityMedSpeed; break;
                    case 3: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnitySmallSpeed; break;
                }
                initialPos = this.transform.position;
                break;
            case 3:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeSpawner;
                speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_SpeedSpawner;
                randomEnemy = Random.Range(0, 2);
                initialPos = this.transform.position;
                break;
            case 4:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherChildLife;
                speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherChildSpeed;
                break;

        }
        timeFreezed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_TimeFreezed;
    }

    //FREEZE
    void Freeze()
    {
        if (freezeCnt >= 3)
        {
            if(!playFreezeSound)
            {
                BlackBoardEnemy.GetComponent<EnemySoundManager>().freeze.GetComponent<SoundScript>().PlaySound();
                playFreezeSound = true;
            }
            else
            {
                freezeTimer = freezeTimer + 1 * Time.deltaTime;
                speed = 0;

                if(freezeFedback != null)
                {
                    freezeFedback.gameObject.SetActive(true);
                }

                if (freezeTimer >= timeFreezed)
                {
                    BlackBoardEnemy.GetComponent<EnemySoundManager>().freezeBreak.GetComponent<SoundScript>().PlaySound();
                    Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().freezeParticles, this.transform.position, Quaternion.identity);
                    speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed;
                    freezeCnt = 0;
                    playFreezeSound = false;
                }
            }
            
        }
        else
        {
            if(freezeFedback != null)
            {
                freezeFedback.gameObject.SetActive(false);
            }
        }
    }

    //Stop Enemy
    void StopEnemyFewSeconds()
    {  
        rb2d.velocity = new Vector2(-moveDirection.x, -moveDirection.y);
        stopTimer += 1f * Time.deltaTime;

        if(stopTimer>= rndVarStop)
        {
            stopTimer = 0;
            enemyType = realState;
        }
    }
    
    //Enemy Isn't On room
    public void PlayerHasGone()
    {
        playerOnRoom = false;
        rb2d.velocity = new Vector2(0,0);
        this.transform.position = initialPos;
    }

    //Enemy HAs Return
    public void PlayerHasReturn()
    {
        if(!playerOnRoom)
        {
            enemyType = realState;
            playerOnRoom = true;
        }
    }
    
    //Spawn BROTHERS
    void SpawnBrothers()
    {
        if(sizeType == 1)
        {
            BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().mediumUnityEnemy, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().mediumUnityEnemy, new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_unity1DeathP, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (sizeType == 2)
        {
            BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().smallUnityEnemy, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().smallUnityEnemy, new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_unity2DeathP, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            if(!sumOneKill)
            {
                player.GetComponent<ProtoBLACKBOARD_Player>().basicFollowerKilled += 1;    
                sumOneKill = true;
            }
            SpawnObj();
            if(!playSound)
            {
                BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
                playSound = true;
            }
            {
                Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_unity3DeathP, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

    }

    //SPRINTER STATE
    void SprintState()
    {
        if(!chilling)
        {
            timerForSprints += 1 * Time.deltaTime;

            moveDirection = (target.transform.position - this.transform.position).normalized * speed;
            rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);

            if(timerForSprints >= timeSprint)
            {
                timerForChillTime = 0;
                chilling = true;
            }
        }
        else
        {
            timerForChillTime += 1 * Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);

            if (timerForChillTime >= timeChill)
            {
                timerForSprints = 0;
                chilling = false;
            }
        }
    }

    //LIFE LOGIC
    void LifeController()
    {
        if (life <= 0 && enemyType != 2 && enemyType != 3 && enemyType != 4)
        {
            if(!sumOneKill)
            {
                player.GetComponent<ProtoBLACKBOARD_Player>().basicFollowerKilled += 1;
                
                if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                }

                if(player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive)  
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission+=1;
                }

                sumOneKill = true;
            }
            SpawnObj();
            if(!playSound)
            {
                BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
                playSound = true;
            }
            {
                Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_basicDeathP, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            

        }
        else if (life <= 0 && enemyType == 2)
        {
            if(!sumOneKill)
            {
                player.GetComponent<ProtoBLACKBOARD_Player>().unityFollowerKilled += 1;
                
                if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                }

                if(player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive)  
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission+=1;
                }
                    
                sumOneKill = true;
            }
            SpawnBrothers();
        }
        else if (life <= 0 && enemyType == 3)
        {
            if(!sumOneKill)
            {
                player.GetComponent<ProtoBLACKBOARD_Player>().spawnerFollowerKilled += 1;
                
                if(player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive)  
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission+=1;
                }
                
                if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                }
                    
                sumOneKill = true;
            }
            Explosion();
        }
        else if(life <= 0 && enemyType == 4)
        {
            if(!playSound)
            {
                BlackBoardEnemy.GetComponent<EnemySoundManager>().death.GetComponent<SoundScript>().PlaySound();
                playSound = true;
            }
            {
                Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_childDeathP, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
           
        }
    }


    //SPAWN OBJ IF I DIE
    void SpawnObj()
    {
        if(spawnPct<= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().spawnObjectPct)
        {
            switch(wichObj)
            {
                case 1:
                if(!spawnOneTime)
                {
                    Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().coin,this.transform.position, BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().coin.transform.rotation);
                    spawnOneTime = true;
                }
                break;
                case 2:
                if(!spawnOneTime)
                {
                    Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().life,this.transform.position, BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().life.transform.rotation);
                    spawnOneTime = true;
                }
                break;
            }
        }
    }

    //CREATE TRAIL
    void EnemyTrail()
    {
        if(enemyType == 1 || enemyType == 2 || enemyType == 3)
        {
            if(sizeType == 3)
            {
                if(myCamaraPoint != null)
                {
                    if(player.GetComponent<ProtoBLACKBOARD_Player>().activeEnemyTrail && myCamaraPoint.GetComponent<CameraPointScript>().isPlayerHere)
                    {
                        enemyTrailTimer +=1*Time.deltaTime;

                        if(enemyTrailTimer>= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().timeToSpawnTrail)
                        {
                            switch(enemyType)
                            {
                                case 1: Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().f_BasicTrail, this.transform.position, Quaternion.identity); 
                                        enemyTrailTimer = 0; break;
                                case 2: Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().f_UnityTrail, this.transform.position, Quaternion.identity); 
                                        enemyTrailTimer = 0; break;
                                case 3: Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().f_SpawnerTrail, this.transform.position, Quaternion.identity); 
                                        enemyTrailTimer = 0; break;
                            }

                        }
                    }
                }
                
            }
        }
    }
   

    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //-----------------------------COLLISION BETWEEN BULLETS---------------------------------------

        if (collision.gameObject.tag == "PlayerBullet")
        {
            
            life -= collision.gameObject.GetComponent<BasicBulletScript>().damage;
            player.GetComponent<ProtoBLACKBOARD_Player>().totalHittedBullets +=1;
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
        }
        if (collision.gameObject.tag == "FreezeBullet")
        {
            life -= collision.gameObject.GetComponent<BasicBulletScript>().damage;
            player.GetComponent<ProtoBLACKBOARD_Player>().totalHittedBullets +=1;
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
            freezeCnt++;
        }
        if (collision.gameObject.tag == "ParryBullet" && collision.GetComponent<TorretBullet>().rebote)
        {
            life -= (2 * collision.gameObject.GetComponent<TorretBullet>().damage);
            collision.gameObject.GetComponent<TorretBullet>().DestroyMe();
        }
        if (collision.gameObject.tag == "TorretBullet" && collision.GetComponent<TorretBullet>().rebote)
        {
            life -= (collision.gameObject.GetComponent<TorretBullet>().damage);
            
            collision.gameObject.GetComponent<TorretBullet>().DestroyMe();
        }

        //---------------------------------------------------------------------------------------------------------------

        if (collision.gameObject.tag == "FollowerCollider")
        {
            rndVarStop = Random.Range(0.15f, 0.2f);
            enemyType = 0;
        }
        if (collision.gameObject.tag == "Wall")
        {
            rndVarStop = Random.Range(0.15f, 0.2f);
            enemyType = 0;
        }

        //---------------------------------------CAMERA POINT---------------------------------------------------------------

        if(collision.gameObject.tag =="CamaraPoint")
        {
            
            myCamaraPoint = collision.gameObject;
        }

        //-----------------------------------------------FREEZE------------------------------------------------------------
        if(collision.gameObject.tag == "Freeze")
        {
            freezeFedback = collision.gameObject;
        }


    }
   
}
