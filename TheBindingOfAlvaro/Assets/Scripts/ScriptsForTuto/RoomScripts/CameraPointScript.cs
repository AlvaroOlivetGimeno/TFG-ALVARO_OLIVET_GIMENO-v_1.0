using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("IS PLAYER ON THIS ROOM??")]
    public bool isPlayerHere;
    public bool firstTime;

    [Header("LISTA ENEMIGOS:")]
    public List<GameObject> enemysOnRoom = new List<GameObject>();

    [Header("ENEMY ROOM:")]

    public bool isTheEntryRoom;
    public float enemyRoomPct;

    public bool isAnEnemyRoom;

    public GameObject enemyRoom;

    public float rndVar;

    [Header("LIGHT ROOM:")]

    public GameObject lightRoom;

    public bool oneTimeLightRoom;


    //OTHER VARIABLES

    bool OneTime;

    GameObject enemyBrain;

    void Start()
    {
       enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");


        rndVar = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------CHECK PLAYER----------------------
        PlayerHasGone();

        //--------------

        //--------------------ENEMY ROOM------------------------
        EnemyRoomController();

        //-----------------

        //-------------------LIGHT ROOM--------------------------
        LightRoomSpawner();

        //-----------------
       
        
    }

    //CHECK IF PLAYER IS ON ROOM
    void PlayerHasGone()
    {
        if(!isPlayerHere)
        {
            foreach(GameObject enemy in enemysOnRoom)
            {
                if(enemy.GetComponent<PlayerIsOnRoom>().enemyType == 2 || enemy.GetComponent<PlayerIsOnRoom>().enemyType == 4)
                {
                    enemy.gameObject.GetComponent<PlayerIsOnRoom>().DesactiveEnemy();
                }
                if(enemy.GetComponent<PlayerIsOnRoom>().enemyType == 1)
                {
                    enemy.gameObject.GetComponent<EnemyShootersScript>().enemyType = 0;
                }
    
            }
        }
        else
        {
            foreach (GameObject enemy in enemysOnRoom)
            {
                if(enemy.GetComponent<PlayerIsOnRoom>().enemyType == 2 || enemy.GetComponent<PlayerIsOnRoom>().enemyType == 4)
                {
                    enemy.gameObject.GetComponent<PlayerIsOnRoom>().ActiveEnemy();
                }
                if(enemy.GetComponent<PlayerIsOnRoom>().enemyType == 1)
                {
                    enemy.gameObject.GetComponent<EnemyShootersScript>().enemyType = enemy.gameObject.GetComponent<EnemyShootersScript>().enemyTypePuntero;
                    
                }
            }
        }
    }
    
    //ENEMY ROOM
    void EnemyRoomController()
    {
        if(!isTheEntryRoom)
        {
            if(rndVar <= enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().enemyRoomPct)
            {
                if(!OneTime)
                {
                    Instantiate(enemyRoom, this.transform.position, Quaternion.identity);
                    OneTime = true;
                }
                
            }
        }
        
    }
    
    //CHECK IF THERES ENEMYS INSIDE ME
    public bool TheresAnyEnemy()
    {
        if(enemysOnRoom.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //LIGHT ROOM SPAWNER
    void LightRoomSpawner()
    {
        if(!oneTimeLightRoom)
        {
            Instantiate(lightRoom, this.transform.position, Quaternion.identity);
            oneTimeLightRoom = true;
        }
    }

    //COLLISIONS
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerHere = true;
           
            if(!firstTime)
            {
                collision.gameObject.GetComponent<ProtoPlayerScript>().NewRoomSeen();
                firstTime = true;
            }
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            
            enemysOnRoom.Add(collision.gameObject);

        }
      
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            isPlayerHere = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemysOnRoom.Remove(collision.gameObject);

        }
    }

    
}
