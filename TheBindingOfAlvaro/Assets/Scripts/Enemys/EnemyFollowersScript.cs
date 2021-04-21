using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollowersScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0;


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
    float realState;

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
           // case 5: PlayerHasGone(); break;
            
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
        //rb2d.velocity = new Vector2 (0,0);
        speed = 20;
        rb2d.velocity = new Vector2(-moveDirection.x, -moveDirection.y);
        stopTimer += 1f * Time.deltaTime;

        if(stopTimer>= rndVarStop)
        {
            speed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().fl_BasicSpeed;
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
    
    //LIFE LOGIC
    void LifeController()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
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
            rndVarStop = Random.Range(0.2f, 0.3f);
            enemyType = 0;
        }
        if (collision.gameObject.tag == "Wall")
        {
            
            rndVarStop = Random.Range(0.2f, 0.3f);
            enemyType = 0;
        }
        if (collision.gameObject.tag == "CamaraPoint")
        {

           
           
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
   {
        

    }
}
