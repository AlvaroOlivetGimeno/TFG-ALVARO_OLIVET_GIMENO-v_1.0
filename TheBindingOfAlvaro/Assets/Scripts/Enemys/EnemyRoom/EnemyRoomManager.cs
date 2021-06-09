using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : MonoBehaviour
{
    [Header("LIST OF CHILD's:")]
    public List<GameObject> childs = new List<GameObject>();

    [Header("LIST OF ENEMY's:")]
    public List<GameObject> enemys = new List<GameObject>();

    [Header("HARD ENEMY LIST VARIABLES:")]
    public float closeDoorsRndVar;

    public bool closeDoors;

    public float timerForClose;

    [Header("HARD ENEMY LIST VARIABLES:")]

    public float enemyRoomTypeRndVar;

    public bool oneTime;

    [Header("IS PLAYER HERE??")]
    
    public bool playerIsHere;
    
    GameObject enemyBrain;

    GameObject camaraPoint;

    GameObject player;
    GameObject otherSoundManager;

    //INDICATORS VARIABLES

    bool sumEnemyRoomOneTime;
    bool sumEnemyRoomCompletedOneTime; 

    float indicatorTimer;

    bool soundPlayed = false;
 


    void Start()
    {
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");
        player = GameObject.FindGameObjectWithTag("Player");
        otherSoundManager = GameObject.FindGameObjectWithTag("OtherSoundManager");

        closeDoorsRndVar = Random.Range(0,100);

        enemyRoomTypeRndVar = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------CIERRE TOTAL-----------------------
        CheckIfWeHaveToClose();
        DoorsController();

        //----------------

        //-------------------TIPO DE SALA-----------------------
        TypeOfEnemyRoom();

        //----------------


        //----------------FOR INDICATORS-------------------------
        SumEnemyRoomToIndicators();

        //--------------
    
    }


    //CLOSE DOORS??
    void CheckIfWeHaveToClose()
    {
        if(closeDoorsRndVar >= enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().closeDoorsPct)
        {
            closeDoors = false;
        }
        else 
        {
            
            closeDoors = true;
        }
    }

    //DOORS CONTROLLER
    void DoorsController()
    {
        
        if(closeDoors && playerIsHere && enemys.Count > 0)
        {
           
           timerForClose += 1 * Time.deltaTime;
           
           if(timerForClose>= 0.2f)
           {
               if(soundPlayed)
               {
                   SetActiveTrue();
               }
               else
               {
                   otherSoundManager.GetComponent<OtherSoundsManager>().closeRoomSound.GetComponent<SoundScript>().PlaySound();
                   soundPlayed = true;
               }
               
           }
           else
           {
                SetActiveFalse();
           }
        }
        else
        {
            SetActiveFalse();
        }
    }

    //F0R CLOSING DOORS
    public void SetActiveTrue()
    {
        
        foreach(GameObject child in childs)
        {
            if(child.GetComponent<EnemyRoomChildScript>().childType == 2)
            {
                child.gameObject.SetActive(true);
            }
        }
        closeDoors = true;
    }

    //FOR OPEN DOORS
    public void SetActiveFalse()
    {
        foreach(GameObject child in childs)
        {
            if(child.GetComponent<EnemyRoomChildScript>().childType == 2)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    //DECIDE TYPE OF ENEMY ROOM
    void TypeOfEnemyRoom()
    {
        switch(enemyRoomTypeRndVar)
        {
            case 1:  
                if(!oneTime)
                {
                    Instantiate(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().shooterRoom, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }    
            break;
            case 2:  
                if(!oneTime)
                {
                    Instantiate(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().followerRoom, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }    
            break;
             case 3:  
                if(!oneTime)
                {
                    Instantiate(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().superRoom, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }    
            break;
        }
    }

    //SUM ENEMY ROOM ONE TIME
    void SumEnemyRoomToIndicators()
    {
        indicatorTimer += 1*Time.deltaTime;

        if(!sumEnemyRoomOneTime)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().enemyRoomsOnMap += 1;
            sumEnemyRoomOneTime = true;
        }

        if(enemys.Count == 0 && !sumEnemyRoomCompletedOneTime && indicatorTimer>=5)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().enemyRoomsCompleted += 1;
            sumEnemyRoomCompletedOneTime = true;
        }
    }

    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Shop")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "SpecialRoom")
        {
            
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Stairs")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "CamaraPoint")
        {
           camaraPoint = other.gameObject;
        }
        if(other.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
        if(other.gameObject.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
        
        if(other.gameObject.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
       
    }
}
