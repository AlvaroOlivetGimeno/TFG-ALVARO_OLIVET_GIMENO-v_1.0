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

    public bool isAnEnemyRoom;

    public float enemyRoomPct;

    public GameObject enemyRoom;

    public float rndVar;


    //OTHER VARIABLES

    bool OneTime;

    

    void Start()
    {
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
        
    }

    //CHECK IF PLAYER IS ON ROOM
    void PlayerHasGone()
    {
        if(!isPlayerHere)
        {
            foreach(GameObject enemy in enemysOnRoom)
            {
                enemy.gameObject.GetComponent<PlayerIsOnRoom>().DesactiveEnemy();
            }
        }
        else
        {
            foreach (GameObject enemy in enemysOnRoom)
            {
                enemy.gameObject.GetComponent<PlayerIsOnRoom>().ActiveEnemy();
            }
        }
    }
    
    //ENEMY ROOM
    void EnemyRoomController()
    {
        if(!isTheEntryRoom)
        {
            if(rndVar <= enemyRoomPct)
            {
                if(!OneTime)
                {
                    Instantiate(enemyRoom, this.transform.position, Quaternion.identity);
                    OneTime = true;
                }
                
            }
        }
        
    }
    
    
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
            if(collision.GetComponent<PlayerIsOnRoom>().enemyType == 2 || collision.GetComponent<PlayerIsOnRoom>().enemyType == 4)
            {
                enemysOnRoom.Add(collision.gameObject);
            }
           
            
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
