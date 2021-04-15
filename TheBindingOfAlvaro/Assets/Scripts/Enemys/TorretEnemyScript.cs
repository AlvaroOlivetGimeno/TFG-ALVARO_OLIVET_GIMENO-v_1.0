using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TorretEnemyScript : MonoBehaviour
{
    
    [Header("VARIABLES OF THE ENEMY")]
    public float life;
    public float timeToShoot;
    public int parryPct;
    public float timeFreezed;

    [Header("BULLETS:")]
    public GameObject normalBullet;
    public GameObject parryBullet;

    float timer; //timer for shooting
    int rndVar;//random variable for bullets
    bool IAmFreeze; //For Know if I'm Freeze
    float freezeCnt; //for know how many shoots I recived
    float freezeTimer; //timer for freeze state

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
    
        Shoot();//----------------------------SHOOT-----------------------------

        LifeController(); //------------------LIFE LOGIC------------------------

        Freeze(); //--------------------------FREEZE----------------------------




    }

    //SHOOTING
    void Shoot()
    {
        if(!IAmFreeze)
        { 
        timer = timer + 1 * Time.deltaTime;

        if (timer >= timeToShoot)
        {

            rndVar = Random.Range(0, 100);

            if (rndVar <= parryPct)
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

    //LIFE LOGIC
    void LifeController()
    {
        if(life == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //FREEZE
    void Freeze()
    {
        if(freezeCnt >= 5)
        {
            Debug.Log("CONGELADO");
            IAmFreeze = true;
            freezeTimer = freezeTimer + 1 * Time.deltaTime;

            if(freezeTimer >= timeFreezed)
            {
                Debug.Log("KNOOOOOOOOOOO");
                IAmFreeze = false;
                freezeCnt = 0;
            }
        }
    }

  

    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            life = life - collision.gameObject.GetComponent<BasicBulletScript>().damage;
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
        }
        if(collision.gameObject.tag =="FreezeBullet")
        {
            life = life - collision.gameObject.GetComponent<BasicBulletScript>().damage;
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
            freezeCnt++;
        }
        if (collision.gameObject.tag == "ParryBullet")
        {
            life = life - (2* collision.gameObject.GetComponent<TorretBullet>().damage);
            //collision.gameObject.GetComponent<TorretBullet>().DestroyMe();
        }
    }
}
