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

    [Header("SHOP THINGS")]

    public GameObject shop;

    public bool shopSpawned;

    public int roomChoosed;

    [Header("THINGS FOR DESTROY:")]

    public GameObject[] shopOnMap;
    public GameObject[] enemysOnMap;

    public GameObject[] enemyRoomsOnMap;

    public GameObject[] passiveHabilitysOnMap;

    public GameObject[] activeHabilitysOnMap;

    public GameObject[] specialHabilitysOnMap;

    public GameObject[] heartsOnMap;


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

        //------------------------------------------INSTANCIAR SHOP--------------------------------------------------
        InstantateShop();


        //------------------------------------------------RESTART MAP------------------------------------------------------

        //----------Elements en arrays--------
        enemysOnMap = GameObject.FindGameObjectsWithTag("Enemy");
        shopOnMap = GameObject.FindGameObjectsWithTag("Shop");
        enemyRoomsOnMap = GameObject.FindGameObjectsWithTag("EnemyRoom");
        passiveHabilitysOnMap = GameObject.FindGameObjectsWithTag("PassiveHability"); 
        activeHabilitysOnMap = GameObject.FindGameObjectsWithTag("ActiveHability");
        specialHabilitysOnMap = GameObject.FindGameObjectsWithTag("SpecialHability");
        heartsOnMap = GameObject.FindGameObjectsWithTag("Life");

        //---------Funcio Restart
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

     public void InstantateShop()
    {
        if(shopSpawned == false && MapIsReady())
        {
            roomChoosed = Random.Range(5,rooms.Count-5);
            Instantiate(shop, rooms[roomChoosed].transform.position, Quaternion.identity);
            shopSpawned = true;
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

    //DESTROY ENEMYS
    void DestroyEnemys()
    {
        foreach(GameObject x in enemysOnMap)
        {
            Destroy(x);
        }
    }
     //DESTROY ENEMYROOMS
    void DestroyEnemyRooms()
    {
        foreach(GameObject x in enemyRoomsOnMap)
        {
            Destroy(x);
        }
    }
     //DESTROY Shop
    void DestroyShop()
    {
        foreach(GameObject x in shopOnMap)
        {
            Destroy(x);
            shopSpawned = false;
        }
    }

     //DESTROY PASSIVE HABILITYS
    void DestroyPassiveHabilitys()
    {
        foreach(GameObject x in passiveHabilitysOnMap)
        {
            Destroy(x);
        }
    }

     //DESTROY ACTIVE HABILITYS
    void DestroyActiveHabilitys()
    {
        foreach(GameObject x in activeHabilitysOnMap)
        {
            Destroy(x);
        }
    }

     //DESTROY SPECIAL HABILITYS
    void DestroySpecialHabilitys()
    {
        foreach(GameObject x in specialHabilitysOnMap)
        {
            Destroy(x);
        }
    }

     //DESTROY HEARTS
    void DestroyHearts()
    {
        foreach(GameObject x in heartsOnMap)
        {
            Destroy(x);
        }
    }

    


    //RESTART MAP
    public void RestartMap()
    {
        if(entryRoom != null )
        {
            if(rooms.Count>= 0)
            {
                DestroyEnemyRooms();
                DestroyEnemys();
                DestroyShop();
                DestroyActiveHabilitys();
                DestroyPassiveHabilitys();
                DestroySpecialHabilitys();
                DestroyHearts();

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
