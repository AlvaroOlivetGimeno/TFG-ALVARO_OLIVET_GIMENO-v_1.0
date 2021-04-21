using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollowersScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0; //1.Basic  2.Unity
    [Header("CHOOSE SIZE (ONLY IF ITS TYPE 2):")]
    public float sizeType = 0; //1.Big 2.Medium 3.Small

    [Header("AUTOMATIC VARIABLES:")]
    public float life;
    public float speed;
    public float timeFreezed;
    public GameObject BlackBoardEnemy;

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

    bool playerOnRoom; //For check if player is on room

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");
        rb2d = GetComponent<Rigidbody2D>();
        
        target = GameObject.FindObjectOfType<ProtoPlayerScript>();

        initialPos = this.transform.position;
        realState = enemyType;

        //START METOD FOR VARIABLES
        StartMetod();
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

        
        
    }

    //Follow basic function
    void Follow(GameObject x)
    {
        moveDirection = (x.transform.position - this.transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }

    //Follow controller
    void FollowController()
    {
        switch(enemyType)
        {
            case 0: StopEnemyFewSeconds(); break;
            case 1: Follow(target.gameObject); break;
            case 2: Follow(target.gameObject); break;
            case 3: SprintState(); break;

        }
    }

    //Start metod
    void StartMetod()
    {
        switch (enemyType)
        {
            case 1: life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeBasic;
                    speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed;
                break;
            case 2:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeUnity;
                switch(sizeType)
                {
                    case 1: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityBigSpeed; break;
                    case 2: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnityMedSpeed; break;
                    case 3: speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_UnitySmallSpeed; break;
                } 
                break;
            case 3:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_LifeSprinter;
                speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_SprinterSpeed;
                timeChill = Random.Range(3f, 5f);
                timeSprint = Random.Range(1f, 2f);
                break;
        }
        timeFreezed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_TimeFreezed;
    }

    //FREEZE
    void Freeze()
    {
        if (freezeCnt >= 5)
        {
           
            freezeTimer = freezeTimer + 1 * Time.deltaTime;
            speed = 0;

            if (freezeTimer >= timeFreezed)
            {
                speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed;
                freezeCnt = 0;
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
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().mediumUnityEnemy, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().mediumUnityEnemy, new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (sizeType == 2)
        {
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().smallUnityEnemy, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().smallUnityEnemy, new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
        if (life <= 0 && enemyType != 2)
        {
            Destroy(this.gameObject);
        }
        else if (life <= 0 && enemyType == 2)
        {
            SpawnBrothers();
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
        
    }
   
}
