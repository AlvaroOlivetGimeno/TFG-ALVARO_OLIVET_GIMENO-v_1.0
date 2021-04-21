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
    

    float rndVarDelay; //first delay for shooting
    float rndVarStop; //for stopping enemy
    float stopTimer; //for stop the player
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");
        rb2d = GetComponent<Rigidbody2D>();
        
        target = GameObject.FindObjectOfType<ProtoPlayerScript>();
       
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
            enemyType = 1;
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
            Debug.Log("ENEMY COLL");
            rndVarStop = Random.Range(0.2f, 0.3f);
            enemyType = 0;
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall COLL");
            rndVarStop = Random.Range(0.2f, 0.3f);
            enemyType = 0;
        }

    }
   void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall COLL");
            rndVarStop = Random.Range(0.2f, 0.3f);
            enemyType = 0;
        }

    }
}
