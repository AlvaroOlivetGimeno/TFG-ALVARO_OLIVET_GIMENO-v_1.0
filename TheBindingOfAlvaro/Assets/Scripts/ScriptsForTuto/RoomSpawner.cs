using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 == UP    2 == DOWN     3 == LEFT     4 == RIGHT
    GameObject rBrain;
    private int rand;

    private GameObject room;

    private bool spawned = false;
    
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        Invoke("roomSpawner", 3f);
    }

    
    void Update()
    {
        //roomSpawner();
    }



    public void roomSpawner()
    {
        if(spawned== false)
        {
            if(openingDirection == 1)
            {
                rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().downRooms.Length);
                //Debug.Log("IT IS SPAWNED?" + spawned + "  WHATS THE INDEX YO DECIDE:"+rand);
                Instantiate(rBrain.GetComponent<RoomTemplates>().downRooms[rand], this.gameObject.transform.position, Quaternion.identity);
                room = rBrain.GetComponent<RoomTemplates>().downRooms[rand];
                Debug.Log(room);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().upRooms.Length);
                Instantiate(rBrain.GetComponent<RoomTemplates>().upRooms[rand], transform.position, Quaternion.identity);
                room = rBrain.GetComponent<RoomTemplates>().upRooms[rand];
            }
             
            else if (openingDirection == 3)
            {
                rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().rightRooms.Length);
                Instantiate(rBrain.GetComponent<RoomTemplates>().rightRooms[rand], transform.position, Quaternion.identity);
                room = rBrain.GetComponent<RoomTemplates>().rightRooms[rand];
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0,rBrain.GetComponent<RoomTemplates>().leftRooms.Length);
                Instantiate(rBrain.GetComponent<RoomTemplates>().leftRooms[rand], transform.position, Quaternion.identity);
                room = rBrain.GetComponent<RoomTemplates>().leftRooms[rand];
            } 
            
            spawned = true;  
        }

    }
    void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
            {
               
            }
        }
}
