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


    [Header("SHOP THINGS")]

    public GameObject shop;

    public bool shopSpawned;

    public int roomChoosed;

    [Header("SPECIAL ROOM THINGS")]

    public GameObject specialRoom;

    public bool specialRoomSpawned;

    [Header("CRISTAL THINGS")]

    public GameObject cristal;

    public bool cristalSpawned;

    [Header("THINGS FOR DESTROY:")]

    public GameObject entryRoom;
    public GameObject[] shopOnMap;
    public GameObject[] enemysOnMap;

    public GameObject[] enemyRoomsOnMap;

    public GameObject[] passiveHabilitysOnMap;

    public GameObject[] activeHabilitysOnMap;

    public GameObject[] specialHabilitysOnMap;

    public GameObject[] heartsOnMap;
    public GameObject[] specialRoomOnMap;

    public GameObject[] closedRoomsOnMap;

    public GameObject stairsOnMap;

    public GameObject[] shooterRoomOnMap;
    public GameObject[] followerRoomOnMap;
    public GameObject[] superRoomOnMap;
    public GameObject[] obstaclesOnMap;

    public GameObject[] lightRoomsOnMap;
    public GameObject[] lightParticlesOnMap;
    public GameObject[] normalRoomOnMap;

    public GameObject entryRoomRugOnMap;

    public GameObject[] coinsOnMap;
    public GameObject[] cristalOnMap;



    //ACCESO A OTROS SCRIPTS o OBJETOS
    GameObject camara;

    GameObject missionManager;

    Transform initialPos;

    //RESTART THINGS
    [Header("THINGS FOR RESTART:")]
    public bool restartIsDone;

    public bool nextLevel;

    public bool allDeleted;

    public bool entryRoomSpawned;


    void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");

        initialPos = camara.transform;
  
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------Elements en arrays---------------------------------------------------
        entryRoom = GameObject.FindGameObjectWithTag("EntryRooms");
        enemysOnMap = GameObject.FindGameObjectsWithTag("Enemy");
        shopOnMap = GameObject.FindGameObjectsWithTag("Shop");
        enemyRoomsOnMap = GameObject.FindGameObjectsWithTag("EnemyRoom");
        passiveHabilitysOnMap = GameObject.FindGameObjectsWithTag("PassiveHability"); 
        activeHabilitysOnMap = GameObject.FindGameObjectsWithTag("ActiveHability");
        specialHabilitysOnMap = GameObject.FindGameObjectsWithTag("SpecialHability");
        heartsOnMap = GameObject.FindGameObjectsWithTag("Life");
        specialRoomOnMap = GameObject.FindGameObjectsWithTag("SpecialRoom");
        closedRoomsOnMap = GameObject.FindGameObjectsWithTag("ClosetRoom");
        stairsOnMap = GameObject.FindGameObjectWithTag("Stairs");
        shooterRoomOnMap = GameObject.FindGameObjectsWithTag("ShooterRoom");
        followerRoomOnMap = GameObject.FindGameObjectsWithTag("FollowerRoom");
        superRoomOnMap = GameObject.FindGameObjectsWithTag("SuperRoom");
        obstaclesOnMap = GameObject.FindGameObjectsWithTag("Obstacle");
        lightRoomsOnMap = GameObject.FindGameObjectsWithTag("LightRoomObject");
        lightParticlesOnMap = GameObject.FindGameObjectsWithTag("LightParticles");
        normalRoomOnMap = GameObject.FindGameObjectsWithTag("NormalRoom");
        entryRoomRugOnMap = GameObject.FindGameObjectWithTag("EntryRoomRug");
        coinsOnMap = GameObject.FindGameObjectsWithTag("Coin");
        cristalOnMap = GameObject.FindGameObjectsWithTag("Cristal");


        //----------------PER SABER QUANS ELEMENTS TINC A LA LLISTA SENSE OBRIR LA LLISTA--------------------------------
        sizeOfList = rooms.Count;
        
        //------------------------------------------INSTANCIAR ESCALERAS--------------------------------------------------
        InstantateStairs();

        //------------------------------------------INSTANCIAR SHOP--------------------------------------------------
        InstantateShop();

        //---------------------------------------INSTANCIAR SPECIAL ROOM--------------------------------------------------
        InstantateSpecialRoom();

        //---------------------------------------INSTANCIAR CRISTAL--------------------------------------------------
        InstantateCristal();

        //----------------------------------------MAP IS READY??--------------------------------------------------------
        MapIsReady();
        ReadyToSeTheMap();
       
        //---------------------------------------------------------------------------------------------------------------

        //------------------------------------------------RESTART MAP------------------------------------------------------
        
        //---------Funcio Restart en cas de que el mapa es crei malament-------------
        
        if(rooms.Count < MinNumOfRooms && ReadyToSeTheMap()) 
        {
            RestartMap();
        }

        //--------Funcio Restart en cas que el jugador pasi per les escales
        if(nextLevel)
        {
            RestartMap();
        }

        
      
    }

    public void AddToList(GameObject x)
    {
        rooms.Add(x);
    }

    //INSTANTIATE STAIRS
    public void InstantateStairs()
    {
        if(spawnStairs == false && MapIsReady())
        {
            Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            MapIsFinished = true;
            spawnStairs = true;
        }
    }

    //Instantiate SHOP
    public void InstantateShop()
    {
        if(shopSpawned == false && MapIsReady())
        {
            
            roomChoosed = Random.Range(rooms.Count/2,rooms.Count-2);
            Instantiate(shop, rooms[roomChoosed].transform.position, Quaternion.identity);
            shopSpawned = true;
        }
       
    }

    //INTANTIATE SPECIAL ROOM
    public void InstantateSpecialRoom()
    {
        if(specialRoomSpawned == false && MapIsReady())
        {
            roomChoosed = Random.Range(5,rooms.Count/2);
            Instantiate(specialRoom, rooms[roomChoosed].transform.position, Quaternion.identity);
            specialRoomSpawned = true;
        }
       
    }

     public void InstantateCristal()
    {
        if(cristalSpawned == false && MapIsReady())
        {
            roomChoosed = Random.Range(rooms.Count-2,rooms.Count-1);
            Instantiate(cristal, rooms[roomChoosed].transform.position, cristal.transform.rotation);
            cristalSpawned = true;
        }
       
    }

    public bool MapIsReady()
    {
        if(rooms.Count != 0)
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
        else
        {
            return false;
        }
        
    }

    //DESTROY ENEMYS
    void DestroyEnemys()
    {
        if(enemysOnMap.Length > 0)
        {
            foreach(GameObject x in enemysOnMap)
            {
                Destroy(x);
            }
        }
        
    }
     //DESTROY ENEMYROOMS
    void DestroyEnemyRooms()
    {
        if(enemyRoomsOnMap.Length > 0)
        {
            foreach(GameObject x in enemyRoomsOnMap)
            {
                Destroy(x);
            }
        }
    }
     //DESTROY Shop
    void DestroyShop()
    {
        if(shopOnMap.Length > 0)
        {
            foreach(GameObject x in shopOnMap)
            {
                Destroy(x);
            }
        }
    }

     //DESTROY PASSIVE HABILITYS
    void DestroyPassiveHabilitys()
    {
       if(passiveHabilitysOnMap.Length > 0)
        {
            foreach(GameObject x in passiveHabilitysOnMap)
            {
                Destroy(x);
            }
        }
    }

     //DESTROY ACTIVE HABILITYS
    void DestroyActiveHabilitys()
    {
       if(activeHabilitysOnMap.Length > 0)
        {
            foreach(GameObject x in activeHabilitysOnMap)
            {
                Destroy(x);
            }
        }
    }

     //DESTROY SPECIAL HABILITYS
    void DestroySpecialHabilitys()
    {
        if(specialHabilitysOnMap.Length > 0)
        {
            foreach(GameObject x in specialHabilitysOnMap)
            {
                Destroy(x);
            }
        }
    }

     //DESTROY HEARTS
    void DestroyHearts()
    {
        if(heartsOnMap.Length > 0)
        {
            foreach(GameObject x in heartsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY SPECIAL ROOM
    void DestroySpecialRoom()
    {
        if(specialRoomOnMap.Length > 0)
        {
            foreach(GameObject x in specialRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY ROOMS
    void DestroyRooms()
    {
        if(rooms.Count > 0)
        {
            foreach(GameObject x in rooms)
            {
                rooms.Remove(x);
                Destroy(x);
            }
        }
    }

    //DESTROY CLOSET ROOMS
    void DestroyClosetRooms()
    {
        if(closedRoomsOnMap.Length > 0)
        {
            foreach(GameObject x in closedRoomsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY STAIRS
    void DestroyStairs()
    {
        if(stairsOnMap != null)
        {
           
            Destroy(stairsOnMap);
            
        }
    }
    
    //DESTROY SHOOTER ROOMS ON MAP
    void DestroyShooterRooms()
    {
        if(shooterRoomOnMap.Length > 0)
        {
            foreach(GameObject x in shooterRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY FOLLOWER ROOMS ON MAP
    void DestroyFollowerRooms()
    {
        if(followerRoomOnMap.Length > 0)
        {
            foreach(GameObject x in followerRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

     //DESTROY SUPER ROOMS ON MAP
    void DestroySuperRooms()
    {
        if(superRoomOnMap.Length > 0)
        {
            foreach(GameObject x in superRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY OBSTACLES
    void DestroyObstacles()
    {
        if(obstaclesOnMap.Length > 0)
        {
            foreach(GameObject x in obstaclesOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY OBSTACLES
    void DestroyLightRooms()
    {
        if(lightRoomsOnMap.Length > 0)
        {
            foreach(GameObject x in lightRoomsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY OBSTACLES
    void DestroyLightParticles()
    {
        if(lightParticlesOnMap.Length > 0)
        {
            foreach(GameObject x in lightParticlesOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY NORMAL ROOM's
    void DestroyNormalRooms()
    {
        if(normalRoomOnMap.Length > 0)
        {
            foreach(GameObject x in normalRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY ENTRY ROOM RUG
    void DestroyEntryRoomRug()
    {
        if(entryRoomRugOnMap!=null)
        {
            foreach(GameObject x in normalRoomOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY COINS 
    void DestroyCoins()
    {
        if(coinsOnMap.Length > 0)
        {
            foreach(GameObject x in coinsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY CRISTAL 
    void DestroyCristals()
    {
        if(cristalOnMap.Length > 0)
        {
            foreach(GameObject x in cristalOnMap)
            {
                Destroy(x);
            }
        }
    }



    //DESTROY ENTRY ROOM
    void DestroyEntryRoom()
    {
        if(entryRoom != null)
        {
           entryRoomSpawned = false;
           Destroy(entryRoom);
        }
    }
    


    //DELETE MAP
    public void DeleteMap()
    {
        DestroyEnemyRooms();
        DestroyEnemys();
        DestroyShop();
        DestroyActiveHabilitys();
        DestroyPassiveHabilitys();
        DestroySpecialHabilitys();
        DestroyHearts();
        DestroySpecialRoom();
        DestroyRooms();
        DestroyClosetRooms();
        DestroyStairs();
        DestroyShooterRooms();
        DestroySuperRooms();
        DestroyObstacles();
        DestroyLightRooms();
        DestroyLightParticles();
        DestroyNormalRooms();
        DestroyEntryRoomRug();
        DestroyCoins();
        DestroyCristals();

        DestroyEntryRoom();
        allDeleted = true;
    }

    //CREATE MAP
    public void CreateMap()
    {
        if(!entryRoomSpawned)
        {
            waiteTime = 0;
            shopSpawned = false;
            specialRoomSpawned = false;
            MapIsFinished = false;
            spawnStairs = false;
            cristalSpawned=false;
            nextLevel = false;
            allDeleted = false;
            MapIsFinished = false;
            Instantiate(startRoom, new Vector3(initialPos.position.x, initialPos.position.y, 0), Quaternion.identity);
            entryRoomSpawned = true;
        }
         
    }

    //RESTART MISIONS
    void RestartMissions()
    {
        missionManager.GetComponent<MissionManager>().RestartMisions();
    }


    //RESTART MAP
    public void RestartMap()
    {
        if(!allDeleted)
        {
            RestartMissions();
            DeleteMap();
            
        }
        else
        {
            CreateMap();
        }   

    }
     
    
    //READY TO SE THE MAP
    public bool ReadyToSeTheMap()
    {
        waiteTime += 1f * Time.deltaTime;

        if(waiteTime >= 8   )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

}
