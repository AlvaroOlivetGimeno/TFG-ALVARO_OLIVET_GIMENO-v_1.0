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
        else
        {
            if(spawnStairs == false)
            {
                waiteTime -= Time.deltaTime;
            }
            
        }
    }


}
