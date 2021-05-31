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

    [Header("THE MASTER BRAIN:")]

    public GameObject masterBrain;

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

    public GameObject[] colorSkinsOnMap;

    public GameObject[] colorDrawsOnMap;

    public GameObject[] superHeartOnMap;

    public GameObject[] spawnPointsOnMap;



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

    public bool onlyOneTime;

    public float timerForRestart;

    public float timeToRestart;




    void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        masterBrain = GameObject.FindGameObjectWithTag("MasterBrain");

        initialPos = camara.transform;
  
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------Elements en arrays---------------------------------------------------
        ElementsOnMap();

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

    //ELEMENTS A TENIR EN COMPTE PER BUSCAR
    void ElementsOnMap()
    {
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
        colorSkinsOnMap = GameObject.FindGameObjectsWithTag("SkinColor");
        colorDrawsOnMap = GameObject.FindGameObjectsWithTag("SkinDraw");
        superHeartOnMap = GameObject.FindGameObjectsWithTag("SuperLife");
        spawnPointsOnMap = GameObject.FindGameObjectsWithTag("SpawnPoint");

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
            
            roomChoosed = Random.Range((rooms.Count/2)+1,rooms.Count-4);
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
            roomChoosed = Random.Range(rooms.Count-4,rooms.Count-3);
            Instantiate(cristal, rooms[roomChoosed].transform.position, cristal.transform.rotation);
            cristalSpawned = true;
        }
       
    }

    public bool MapIsReady()
    {
        if(rooms.Count != 0)
        {
            if(rooms.Count > MaxNumOfRooms)
            {
                RestartMap();
                return false;
            }
            else
            {
                if(rooms.Count <= MaxNumOfRooms && rooms.Count >= MinNumOfRooms)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            
            Destroy(entryRoomRugOnMap);
            
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

    //DESTROY SKIN COLORS 
    void DestroySkinColor()
    {
        if(colorSkinsOnMap.Length > 0)
        {
            foreach(GameObject x in colorSkinsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY SKIN DRAW
    void DestroySkinDraw()
    {
        if(colorDrawsOnMap.Length > 0)
        {
            foreach(GameObject x in colorDrawsOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY SUPER LIFE's
    void DestroySuperLife()
    {
        if(superHeartOnMap.Length > 0)
        {
            foreach(GameObject x in superHeartOnMap)
            {
                Destroy(x);
            }
        }
    }

    //DESTROY SPAWN POINTS
    void DestroySpawnPoints()
    {
        if(spawnPointsOnMap.Length > 0)
        {
            foreach(GameObject x in spawnPointsOnMap)
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
        timerForRestart += 1 * Time.deltaTime;
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
        DestroyFollowerRooms();
        DestroySuperRooms();
        DestroyObstacles();
        DestroyLightRooms();
        DestroyLightParticles();
        DestroyNormalRooms();
        DestroyEntryRoomRug();
        DestroyCoins();
        DestroyCristals();
        DestroySkinColor();
        DestroySkinDraw();
        DestroySuperLife();
        DestroySpawnPoints();

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
            onlyOneTime = false;
            Instantiate(startRoom, new Vector3(initialPos.position.x, initialPos.position.y, 0), Quaternion.identity);
            entryRoomSpawned = true;
            timerForRestart = 0;
        }
         
    }

    //RESTART MISIONS
    void RestartMissions()
    {
        if(missionManager != null)
        {
            missionManager.GetComponent<MissionManager>().RestartMisions();
        }
       
    }

    //UPRGADE DIFICULTY
    void DificultyUprage()
    {
        if(masterBrain != null)
        {
            masterBrain.GetComponent<MasterBrainScript>().DifficultyUprage();
        }
        
    }

    //PORFILES CHANGE
    void PorfileUprage()
    {
        if(masterBrain != null)
        {
            masterBrain.GetComponent<MasterBrainScript>().TaxonomyChange();
        }
        
    }


    //RESTART MAP
    public void RestartMap()
    {
        if(!allDeleted )
        {
            RestartMissions();
            if(!onlyOneTime)
            {
                DificultyUprage();
                PorfileUprage();
                onlyOneTime = true;
            }
            
            DeleteMap();
            
        }
        else if(allDeleted && timerForRestart >= timeToRestart)
        {
            CreateMap();
        }   

    }
     
    
    //READY TO SE THE MAP
    public bool ReadyToSeTheMap()
    {
        waiteTime += 1f * Time.deltaTime;

        if(waiteTime >= 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

}
