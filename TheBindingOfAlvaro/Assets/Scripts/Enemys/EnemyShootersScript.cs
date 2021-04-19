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

    public GameObject BlackBoardEnemy;
    GameObject _enemyBlackBoard;

    float timer; //timer for shooting
    int rndVar;//random variable for bullets
    float rndVarDelay; //first delay for shooting
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state

    public List<GameObject> childs = new List<GameObject>();
    

    public GameObject chechUp;
    public GameObject chechDown;
    public GameObject chechRight;
    public GameObject chechLeft;

    void Start()
    {
        BlackBoardEnemy = GameObject.FindGameObjectWithTag("EnemyBrain");

        //START VARIABLES
        life = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_Life;
        timeToShoot = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeToShoot;
        timeFreezed = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_TimeFreezed;
        parryPct = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct;
        normalBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_BasicBullet;
        parryBullet = BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryBullet;
        //--------------

        //RANDOM
        rndVarDelay =  Random.Range(0.0f, 2.0f);

        //FOR SHOOTING FAST THE FIRST SHOOT
        timer = 5;

        //FOR CHILDS
        CheckChildsCheck();
    }

    // Update is called once per frame
    void Update()
    {

        SottingController(); //----------------------------SHOOT-----------------------------

        LifeController(); //------------------LIFE LOGIC------------------------

        Freeze(); //--------------------------FREEZE----------------------------

        Debug.Log(this.transform.GetChild(2).gameObject);
        
    }

    //SHOOTING
    void InteligentShoot()
    {
        if (!IAmFreeze)
        {
            timer = timer + 1 * Time.deltaTime;

            if (timer >= timeToShoot)
            {

                rndVar = Random.Range(0, 100);

                if (rndVar <= BlackBoardEnemy.GetComponent<BLACKBOARD_ENEMYS>().sh_ParryPct)
                {
                    Instantiate(parryBullet, this.transform.position, Quaternion.identity);
                    timer = 0;
                }
                else
                {
                    Instantiate(normalBullet, this.transform.position, Quaternion.identity);
                    timer = 0;
                }

            }
        }
    }


    //TYPE SELECTOR
    void SottingController()
    {
        switch(enemyType)
        {
            case 0: Debug.LogError("L'ENEMIC HA DE TENIR UN TIPUS! ( 1.Static Torret   2.Shy Torret   3.Intelligent Torret )"); break;
            case 1: break;
            case 2: break;
            case 3: Invoke("InteligentShoot", rndVarDelay); break;
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

    void CheckChildsCheck()
    {
        for(int i = 1; i >= this.transform.childCount; i++)
        {
            childs.Add(this.transform.GetChild(i).gameObject);
        }
    }

    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
    }
}
