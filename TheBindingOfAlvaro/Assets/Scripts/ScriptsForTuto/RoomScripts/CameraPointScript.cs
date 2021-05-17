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

    [Header("NORMAL ROOM MANAGER:")]

    public GameObject normalRoomManager;

    [Header("ENTRY ROOM RUG:")]
    public GameObject entryRoomRug;

    [Header("LIGHT ROOM:")]

    public GameObject lightRoom;

    public bool oneTimeLightRoom;

    [Header("MAP OBJECT -AUTOMATIC-:")]
    public GameObject myCameraMapObj;


    //OTHER VARIABLES

    bool OneTime;

    GameObject enemyBrain;
    GameObject cam;
    GameObject player;

    void Start()
    {
       enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");
       cam = GameObject.FindGameObjectWithTag("MainCamera");
       player = GameObject.FindGameObjectWithTag("Player");


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

        //------------------MAP OBJ LOGIC------------------------
        MapObjectLogic();

        //----------------
       
        
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
            else
            {
                if(!OneTime)
                {
                    Instantiate(normalRoomManager, this.transform.position, Quaternion.identity);
                    OneTime = true;
                }
            }
        }
        else
        {
            if(!OneTime)
            {
                Instantiate(entryRoomRug,new Vector3(cam.transform.position.x, cam.transform.position.y, 0)  , Quaternion.identity);
                OneTime = true;
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

    //MAP OBJECT LOGIC
    void MapObjectLogic()
    {
        if(myCameraMapObj != null)
        {
            if(player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic )
            {
                if(player.GetComponent<ProtoBLACKBOARD_Player>().cameraMapIsActive)
                {
                    if(firstTime)
                    {
                        myCameraMapObj.SetActive(false);
                    }
                    else
                    {
                        myCameraMapObj.SetActive(true);
                    }
                }
                else
                {
                    myCameraMapObj.SetActive(false);
                }
            }
            else
            {
                myCameraMapObj.SetActive(false);
            }
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
        if(collision.gameObject.tag == "MapObject")
        {
            myCameraMapObj = collision.gameObject;
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
