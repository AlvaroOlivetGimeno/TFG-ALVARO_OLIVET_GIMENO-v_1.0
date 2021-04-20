using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootersScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0;


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

    float timer; //timer for shooting
    int rndVar;//random variable for bullets
    float rndVarDelay; //first delay for shooting
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state

    public List<GameObject> wallChekers = new List<GameObject>();

    Vector3 spawnPos; //for instantiate normal bullet
    bool oneTime;
    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");

        //START VARIABLES
        StartMetod();
       
        

        //--------------

        //RANDOM
        rndVarDelay =  Random.Range(0.0f, 2.0f);

        //FOR SHOOTING FAST THE FIRST SHOOT
        timer = 5;

        //FOR CHILDS
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------SHOOT-----------------------------
        if(!oneTime)
        {
            PositionChecker();
            oneTime = true;
        }
        
        SottingController();
       

        //------------------LIFE LOGIC------------------------
        LifeController();

        //--------------------------FREEZE----------------------------
        Freeze(); 

       // Debug.Log(this.transform.GetChild(2).gameObject);
        
    }

    //SHOOT FUNCTION
    void Shoot(GameObject pBullet, GameObject bullet)
    {
        if (!IAmFreeze)
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
        
        foreach(GameObject c in wallChekers)
        {
            if(wallChekers.Count != 1)
            {
                if(c.gameObject.GetComponent<CheckWallPosition>().relativePos == 4)
                {
                    wallChekers.Remove(c.gameObject);
                    Destroy(c.gameObject);
                }
                else if (c.gameObject.GetComponent<CheckWallPosition>().relativePos == 3)
                {
                    wallChekers.Remove(c.gameObject);
                    Destroy(c.gameObject);
                }
                else if (c.gameObject.GetComponent<CheckWallPosition>().relativePos == 2)
                {
                    wallChekers.Remove(c.gameObject);
                    Destroy(c.gameObject);
                }
            }
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
            case 0: Debug.LogError("L'ENEMIC HA DE TENIR UN TIPUS! ( 1.Static Torret   2.Shy Torret   3.Intelligent Torret )"); break;
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
                timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootBasic; break;
            case 2:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeBounce;
                timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootBounce; break;
            case 3:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_LifeIntelligent;
                timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShootIntelligent; break;
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
