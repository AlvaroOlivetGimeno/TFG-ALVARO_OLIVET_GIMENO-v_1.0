using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShootersScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0;

    public float enemyTypePuntero;
    [Header("AUTOMATIC VARIABLES:")]
     public float life;
     public float timeToShoot;
     public float parryPct;
     public float timeFreezed;
    GameObject normalBullet;
    GameObject parryBullet;
    GameObject intelligentBullet;
    GameObject intelligentParryBullet;
    GameObject bounceBullet;
    GameObject bounceParryBullet;

    public GameObject BlackBoardEnemy;
    GameObject _enemyBlackBoard;

    bool ready; //for check if have to shoot 
    int rndVarWallChecker; //for check wich i will destroy
    public float timer; //timer for shooting
    int rndVar;//random variable for bullets
    float rndVarDelay; //first delay for shooting
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state

    Rigidbody2D rb2d;
    
    public List<GameObject> wallChekers = new List<GameObject>();

    Vector3 spawnPos; //for instantiate normal bullet
    bool oneTime;

    GameObject player;
    bool sumOneKill;

    //FOR SPAWN

    bool spawnOneTime;
    int spawnPct;
    int wichObj;

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        //START VARIABLES
        StartMetod();
        enemyTypePuntero = enemyType;
        //--------------

        //RANDOM
        rndVarDelay =  Random.Range(0.0f, 2.0f);

        //FOR SPAWN VARIABLES:
        wichObj = Random.Range(1,3);
        spawnPct = Random.Range(0,100);
       
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------SHOOT-----------------------------
        if(enemyType == 1)
        {
            PositionChecker();
        }
        
        SottingController();
       

        //------------------LIFE LOGIC------------------------
        LifeController();

        //--------------------------FREEZE----------------------------
        Freeze(); 

        //------------------------PARRY SHIELD--------------------------
        ParryShieldController();

       // Debug.Log(this.transform.GetChild(2).gameObject);
        
    }

    //SHOOT FUNCTION
    void Shoot(GameObject pBullet, GameObject bullet)
    {
        if (!IAmFreeze && ready)
        {
            timer = timer + 1 * Time.deltaTime;

            if (timer >= timeToShoot)
            {

                rndVar = Random.Range(0, 100);

                if (rndVar <= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct)
                {
                    Instantiate(pBullet, this.transform.position, Quaternion.identity);
                    timer = 0;
                }
                else
                {
                    Instantiate(bullet, this.transform.position, Quaternion.identity);
                    timer = 0;
                }

            }
        }
    }

    //SHOOTING
    void InteligentShoot()
    {
        Shoot(intelligentParryBullet, intelligentBullet);
    }

  
    //GIVE ME A RNDM VARIABLE (int)
    int RndVariable(int min, int max)
    {
        int rndInt;

        rndInt = Random.Range(min, max);

        return rndInt;

    }
    
    
    //CheckPosition
    void PositionChecker()
    {
        
        foreach(GameObject check in wallChekers)
        {
            if(check.gameObject.GetComponent<CheckWallPosition>().wallContact)
            {
                wallChekers.Remove(check.gameObject);
                Destroy(check.gameObject);
            }
        }
        if(wallChekers.Count == 4)
        {
            rndVarWallChecker = Random.Range(0, wallChekers.Count-1);
           wallChekers[rndVarWallChecker].gameObject.GetComponent<CheckWallPosition>().expulsed = true;
            wallChekers.Remove(wallChekers[rndVarWallChecker].gameObject);
            //Destroy(wallChekers[rndVarWallChecker].gameObject);

        }
        if(wallChekers.Count == 3)
        {
            rndVarWallChecker = Random.Range(0, wallChekers.Count-1);
           wallChekers[rndVarWallChecker].gameObject.GetComponent<CheckWallPosition>().expulsed = true;
            wallChekers.Remove(wallChekers[rndVarWallChecker].gameObject);
            //Destroy(wallChekers[rndVarWallChecker].gameObject);

        }
        if(wallChekers.Count == 2)
        {
            rndVarWallChecker = Random.Range(0, wallChekers.Count-1);
           wallChekers[rndVarWallChecker].gameObject.GetComponent<CheckWallPosition>().expulsed = true;
            wallChekers.Remove(wallChekers[rndVarWallChecker].gameObject);
            //Destroy(wallChekers[rndVarWallChecker].gameObject);

        }
        
        if(wallChekers.Count == 1)
        {
            ready = true;
        }
        
        
       
    }


    //Basic SHoot
    void BasicShoot()
    {
        Shoot(parryBullet, normalBullet);
    }
    
    //Bounce SHoot
    void BounceShoot()
    {
        Shoot(bounceParryBullet, bounceBullet);
    }
   

    //TYPE SELECTOR
    void SottingController()
    {
        switch(enemyType)
        {
            case 0:  break;
            case 1: Invoke("BasicShoot", rndVarDelay); break;
            case 2: Invoke("BounceShoot", rndVarDelay);  break;
            case 3: Invoke("InteligentShoot", rndVarDelay); break;
        }
    }


    //START FUNCTION
    void StartMetod()
    {
        switch(enemyType)
        {
            case 1: life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeBasic;
                timeToShoot = Random.Range(0.5f, 0.7f);
                ready = false;
                break;
            case 2:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeBounce;
                timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootBounce;  
                ready = true;
                timer = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootBounce - 0.2f; 
                break;
            case 3:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeIntelligent;
                timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootIntelligent;  
                ready = true;
                timer= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootIntelligent- 0.2f; 
                break;
        }
        timeFreezed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeFreezed;
        parryPct = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct;
        normalBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_BasicBullet;
        parryBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryBullet;
        intelligentBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_IntelligentBullet;
        intelligentParryBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_IntelligentParryBullet;
        bounceBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_BounceBullet;
        bounceParryBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_BounceParryBullet;

        

    }
    
    //LIFE LOGIC
    void LifeController()
    {
        if (life <= 0)
        {
            if(!sumOneKill)
            {
                if(enemyType == 1)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().basicTorretKilled += 1;

                    if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                    {
                        player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                    }
                }
                else if(enemyType == 2)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().bounceTorretKilled += 1;
                     
                    if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                    {
                        player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                    }
                }
                else if(enemyType == 3)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().intelligentTorretKilled += 1;
                     
                    if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                    {
                        player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                    }
                }
                
                if(player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive)  
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission+=1;
                    
                    if(!player.GetComponent<ProtoBLACKBOARD_Player>().loadingSpecialHability)
                    {
                        player.GetComponent<ProtoBLACKBOARD_Player>().enemysKillToReloadSpecialHability+=1;
                    }
                }
                  
                sumOneKill = true;
            }
            SpawnObj();
            Destroy(this.gameObject);
        }
    }

    //FREEZE
    void Freeze()
    {
        if (freezeCnt >= 5)
        {
            IAmFreeze = true;
            freezeTimer = freezeTimer + 1 * Time.deltaTime;

            if (freezeTimer >= timeFreezed)
            {
                IAmFreeze = false;
                freezeCnt = 0;
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

    //PARRY SHIELD
    void ParryShieldController()
    {
        if(enemyType == 2 || enemyType == 3)
        {
            if(player.GetComponent<ProtoBLACKBOARD_Player>().activeParryShield)
            {
                if(!this.transform.GetChild(3).GetComponent<ParryShieldScript>().defeated)
                {
                    this.transform.GetChild(3).gameObject.SetActive(true);
                }
                else
                {
                    this.transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            else
            {
                this.transform.GetChild(3).gameObject.SetActive(false);
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
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
        }
        if (collision.gameObject.tag == "FreezeBullet")
        {
            life -= collision.gameObject.GetComponent<BasicBulletScript>().damage;
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

        //-----------------------------------------WALL CHECKERS---------------------------------------------------------
        if (collision.gameObject.tag == "WallCheck")
        {
            if(!collision.gameObject.GetComponent<CheckWallPosition>().addedToFathersList)
            {
                wallChekers.Add(collision.gameObject);
                collision.gameObject.GetComponent<CheckWallPosition>().addedToFathersList = true;
            }
           
        }
       

    }

   
}
