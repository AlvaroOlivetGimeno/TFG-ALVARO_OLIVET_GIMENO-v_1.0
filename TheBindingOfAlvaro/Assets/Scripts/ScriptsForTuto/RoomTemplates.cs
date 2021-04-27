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
    public GameObject startRoom;
    
    [Header("LIST OF ROOMS IN SCENE:")]
    public List<GameObject> rooms;

    public float sizeOfList;

    [Header("STAIRS PREFAB:")]
    public GameObject stairs;
    private bool spawnStairs = false;
    
    [Header("SIZE OF MAP:")]

    public float MaxNumOfRooms;

    public float MinNumOfRooms;

    public bool MapIsFinished = false;

    [Header("DECREASING TIMER:")]
    public float waiteTime;

    float waitTimeReserva;

    //ACCESO A OTROS SCRIPTS o OBJETOS

    GameObject entryRoom;

    GameObject camara;

    Transform initialPos;

    //RESTART THINGS
    public bool restartIsDone;


    void Start()
    {
        entryRoom = GameObject.FindGameObjectWithTag("EntryRooms");
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        initialPos = camara.transform;
        waitTimeReserva = waiteTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        //----------------PER SABER QUANS ELEMENTS TINC A LA LLISTA SENSE OBRIR LA LLISTA--------------------------------
        sizeOfList = rooms.Count;
        
        //------------------------------------------INSTANCIAR ESCALERAS--------------------------------------------------
        InstantateStairs();

        //------------------------------------------------RESTART MAP------------------------------------------------------
        if(MapIsFinished && rooms.Count < MinNumOfRooms && restartIsDone == false)
        {
            RestartMap();
        }

        //-------------------------------------RESETEAR VARIABLE restartIsDone--------------------------------------------
        if(waiteTime> 0)
        {
            restartIsDone = false;
        }
        if(entryRoom == null && restartIsDone == false)
        {
            entryRoom = GameObject.FindGameObjectWithTag("EntryRooms");     
        }
    }

    public void AddToList(GameObject x)
    {
        rooms.Add(x);
    }
    public void InstantateStairs()
    {
        if(waiteTime <= 0 && spawnStairs == false)
        {
            //Debug.Log("INSTANCIANDO ESCALERAS");
            MapIsFinished = true;
            spawnStairs = true;
            if(rooms.Count >= MinNumOfRooms)
            {
                Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            }
            
        }
        else if(spawnStairs == false && MapIsReady())
        {
            //Debug.Log("INSTANCIANDO ESCALERAS");
            Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            MapIsFinished = true;
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
    public void RestartMap()
    {
        if(entryRoom != null )
        {
            if(rooms.Count>= 0)
            {
                foreach(GameObject x in rooms)
                {
                    rooms.Remove(x);
                    Destroy(x);
                }
            }
            Destroy(entryRoom.gameObject);
        }
        else
        {
            Debug.Log("TIME TO RESTART");
            Instantiate(startRoom, initialPos.position, Quaternion.identity);
            waiteTime = waitTimeReserva;
            MapIsFinished = false;
            spawnStairs = false;
            restartIsDone = true;

        }
        

    }
     
    
    

}
