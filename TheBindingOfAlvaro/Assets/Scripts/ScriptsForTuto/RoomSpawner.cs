﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 == UP    2 == DOWN     3 == LEFT     4 == RIGHT
    GameObject rBrain;
    private int rand;

    private GameObject room;

    public bool dontSpawn = false;

    private bool spawned = false;

    double timeRuning;

    bool stopSpawning;

    
    
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        Invoke("roomSpawner", 0.1f);
    }

    
    void Update()
    {
        timeRuning = 0.1 + Time.deltaTime;
        Debug.Log("TIME:" + timeRuning);
        if(rBrain.GetComponent<RoomTemplates>().timeActive>= timeRuning)
        {
            stopSpawning = true;
        }
        //roomSpawner();
    }



    public void roomSpawner()
    {
        if(stopSpawning)
        {
        if(spawned== false)
        {
            if(openingDirection == 1)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().downRooms.Length);
                    //Debug.Log("IT IS SPAWNED?" + spawned + "  WHATS THE INDEX YO DECIDE:"+rand);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().downRooms[rand], this.gameObject.transform.position, Quaternion.identity);
                    room = rBrain.GetComponent<RoomTemplates>().downRooms[rand];
                    
                }
                else
                {
                    //Debug.Log("TA OCUPAO BRO:(");
                    Destroy(this.gameObject);
                }
               
            }
            
            else if (openingDirection == 2)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().upRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().upRooms[rand], transform.position, Quaternion.identity);
                    room = rBrain.GetComponent<RoomTemplates>().upRooms[rand];    
                }
                else
                {
                    //Debug.Log("TA OCUPAO BRO:(");
                    Destroy(this.gameObject);
                }  
            }  
            
            
            else if (openingDirection == 3)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().rightRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().rightRooms[rand], transform.position, Quaternion.identity);
                    room = rBrain.GetComponent<RoomTemplates>().rightRooms[rand];   
                }
                else
                {
                    //Debug.Log("TA OCUPAO BRO:(");
                    Destroy(this.gameObject);
                }  
            }
            
            else if (openingDirection == 4)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().leftRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().leftRooms[rand], transform.position, Quaternion.identity);
                    room = rBrain.GetComponent<RoomTemplates>().leftRooms[rand];
                    
                }
                else
                {
                    //Debug.Log("TA OCUPAO BRO:(");
                    Destroy(this.gameObject);
                }  
            } 
            spawned = true;  
        }
        }

    }
    void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Room") /*&& other.GetComponent<RoomSpawner>().spawned == true*/)
            {
                Debug.Log("CON LA IGLESIA NOS HEMOS TOPADO");
                dontSpawn = true;
            }
            if(other.CompareTag("SpawnPoint") )
            {
                if(other.gameObject.GetComponent<RoomSpawner>().openingDirection> openingDirection)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                } 
            }   
        }
}
