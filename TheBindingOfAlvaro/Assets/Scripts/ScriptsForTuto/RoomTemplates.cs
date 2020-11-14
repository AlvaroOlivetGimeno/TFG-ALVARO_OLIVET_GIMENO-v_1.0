using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [Header("DIFERENT TYPES OF ROOMS:")]
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject superRooms;
    
    [Header("LIST OF ROOMS IN SCENE:")]
    public List<GameObject> rooms;

    [Header("STAIRS PREFAB:")]
    public GameObject stairs;
    private bool spawnStairs = false;
    
    [Header("SIZE OF MAP:")]

    public float MaxNumOfRooms;

    public float MinNumOfRooms;

    [Header("DECREASING TIMER:")]
    public float waiteTime;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantateStairs();
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
        else if(spawnStairs == false && MapIsReady())
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
        if(rooms.Count >= MaxNumOfRooms)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
