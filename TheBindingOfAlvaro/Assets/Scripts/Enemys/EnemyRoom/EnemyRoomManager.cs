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

    [Header("IS PLAYER HERE??")]
    
    public bool playerIsHere;
    
    GameObject enemyBrain;

    GameObject camaraPoint;

 


    void Start()
    {
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");
        

        closeDoorsRndVar = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------CIERRE TOTAL-----------------------
        CheckIfWeHaveToClose();
        DoorsController();

        //----------------
    
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
           
           if(timerForClose>= 1)
           {
               SetActiveTrue();
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

    //FOR OPEN DOOS
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
        if(other.gameObject.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }
}
