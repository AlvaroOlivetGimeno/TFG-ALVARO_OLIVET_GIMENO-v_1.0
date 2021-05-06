using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public float enemyType = 0; //1.Inverter

    [Header("AUTOMATIC VARIABLES:")]
    public float life;
    public float speed;
    public float timeFreezed;
    public GameObject specialCol;
    
    public GameObject BlackBoardEnemy;
    Rigidbody2D rb2d;

    bool oneTime; //for do something one time

    GameObject particleSystemEnemy;
    float spawnTimer;

    GameObject player;
    bool sumOneKill;

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        StartMetod();
    }

    // Update is called once per frame
    void Update()
    {
        //------------------------------SPECIAL CONTROLLER--------------------------------
        SpecialController();

        //-----------------

        //------------------------------LIFE CONTROLLER--------------------------------
        LifeController();

        //---------------
    }

    //START METOD
    void StartMetod()
    {
        switch(enemyType)
        {
            case 1: life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_InverterLife;
                particleSystemEnemy = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_ParticlesInverter;
                break;
            case 2:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_SquidLife;
                particleSystemEnemy = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_ParticlesSquid;
                break;
            case 3:
                life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherLife;
                particleSystemEnemy = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_ParticlesMother;
                spawnTimer = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherTimeSpawn -0.2f;
                break;
        }
    }

    //WAITING DEATH
    void WaitingDead()
    {
        if(specialCol != null)//PER EVITAR GILIPOLLADAS
        {
            if(specialCol.GetComponent<SpecialColliderScript>().contact)
            {
                if(!oneTime)
                {
                    Instantiate(particleSystemEnemy, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
                else
                {
                    //Destroy(this.gameObject);
                    life = 0;
                }
            
            }
        }
        
    }
     
    //SPAWN CHILDRENS
    void SpawnChildren()
    {
        spawnTimer += 1 * Time.deltaTime;


        if(spawnTimer >= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_MotherTimeSpawn)
        {
            Instantiate(BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sp_LittleMother, this.transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }

    //MOTHER LOGIC
    void MotherState()
    {
        WaitingDead();
        SpawnChildren();
    }

    //ENEMY TYPES
    void SpecialController()
    {
        switch(enemyType)
        {
            case 1: WaitingDead(); break;
            case 2: WaitingDead(); break;
            case 3: MotherState(); break;
        }
  
    }

    //LIFE CONTROLLER
    void LifeController()
    {
        if(life <= 0)
        {
            if(!sumOneKill)
            {
                if(enemyType == 1)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().inverterKilled += 1;
                }
                else if( enemyType == 2)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().squidKilled += 1;
                }
                else if(enemyType == 3)
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().mothersKilled += 1;
                }
                
                if(player.GetComponent<ProtoBLACKBOARD_Player>().killEnemysMissionActive)  
                {
                    player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemysKilledForMission+=1;
                }
                
                sumOneKill = true;
            }
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

        if (collision.gameObject.tag == "SpecialCollider")
        {
            specialCol = collision.gameObject;
        }
        //---------------------------------------------------------------------------------------------------------------




    }
    


}
