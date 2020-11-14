using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    
    public GameObject[] rightRooms;
    public GameObject superRooms;
    public float waiteTime;

    public List<GameObject> rooms;

    public GameObject stairs;

    private bool spawnStairs = false;

    float numOfObjectsInList;

    public float NumMaxOfRooms;

    public bool deleteYourself;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantateStairs();
        MapIsReady();
       
    }

    public void AddToList(GameObject x)
    {
        rooms.Add(x);
    }
    public void InstantateStairs()
    {
        if(waiteTime <= 0 && spawnStairs == false && MapIsReady() == true)
        {
            Debug.Log("INSTANCIANDO ESCALERAS");
            Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnStairs = true;
        }
        else if(waiteTime <= 0 && spawnStairs == false && MapIsReady() == false)
        {
            deleteYourself = true;
            rooms.RemoveRange(0, rooms.Count);
            waiteTime = 15;
        }
        else
        {
            if(spawnStairs == false)
            {
                waiteTime -= Time.deltaTime;
            }
            
        }
    }

    public bool MapIsReady()
    {
       if(waiteTime <= 0 && rooms.Count  <= NumMaxOfRooms)
       {
           return true;
       }
       else
       {
           return false;
       }
    }



}
