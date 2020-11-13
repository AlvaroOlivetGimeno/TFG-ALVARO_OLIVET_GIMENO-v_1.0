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


    public float NumMaxOfRooms;



    private GameObject headSpawner;

    void Start()
    {
        headSpawner = GameObject.FindGameObjectWithTag("HeadSpawner");
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
        if(waiteTime <= 0 && spawnStairs == false)
        {
            Debug.Log("INSTANCIANDO ESCALERAS");
            Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnStairs = true;
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
       if(rooms.Count >= NumMaxOfRooms)
       {
           waiteTime = 0;
           return true;
       }
       else
       {
           return false;
       }
    }



}
