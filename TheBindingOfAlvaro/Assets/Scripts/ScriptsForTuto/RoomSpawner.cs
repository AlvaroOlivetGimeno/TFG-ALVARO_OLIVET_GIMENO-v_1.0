using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [Header("TYPE OF SPAWNER (From 1 to 4):")]
    public int openingDirection;
    //1 == UP    2 == DOWN     3 == LEFT     4 == RIGHT
    [Header("DONT SPAWN A ROOM IF THATS TRUE!")]
    public bool dontSpawn = false;

    [Header("HAVE YOU SPAWN A ROOM?")]
    public bool spawned = false;

    //REFERENCIES A ALTRES SRIPTS
    GameObject rBrain;

    //VARIABLE RANDOM
    private int rand;

    //INSTANCIA DE LA ROOM QUE CREA EL SPAWNER:

    private GameObject room;


    
    
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        Invoke("roomSpawner", 0.1f);
    }

    
    void Update()
    {
        
       
        //roomSpawner();
    }



    public void roomSpawner()
    {
        if(spawned == false && rBrain.GetComponent<RoomTemplates>().MapIsReady() == false)
        {
            if(openingDirection == 1)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().downRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().downRooms[rand],new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);
                    //room = rBrain.GetComponent<RoomTemplates>().downRooms[rand];
                    
                }
                else
                {
                   // Destroy(this.gameObject);
                }
               
            }
            
            else if (openingDirection == 2)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().upRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().upRooms[rand], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);
                    //room = rBrain.GetComponent<RoomTemplates>().upRooms[rand];    
                }
                else
                {
                   // Destroy(this.gameObject);
                }  
            }  
            
            
            else if (openingDirection == 3)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().rightRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().rightRooms[rand], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);
                    //room = rBrain.GetComponent<RoomTemplates>().rightRooms[rand];   
                }
                else
                {
                   // Destroy(this.gameObject);
                }  
            }
            
            else if (openingDirection == 4)
            {
                if(!dontSpawn)
                {
                    rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().leftRooms.Length);
                    Instantiate(rBrain.GetComponent<RoomTemplates>().leftRooms[rand], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);
                    //room = rBrain.GetComponent<RoomTemplates>().leftRooms[rand];
                    
                }
                else
                {
                   // Destroy(this.gameObject);
                }  
            } 
            spawned = true;
            //Destroy(this.gameObject);  
        }
        else
        {
            if(!dontSpawn)
            {
                //Debug.Log(rBrain.GetComponent<RoomTemplates>().MapIsReady());
                Instantiate(rBrain.GetComponent<RoomTemplates>().superRooms, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);
                spawned = true; 
            }
        }
        

    }
    void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Room"))
            {
                //Debug.Log("CON LA IGLESIA NOS HEMOS TOPADO");
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
