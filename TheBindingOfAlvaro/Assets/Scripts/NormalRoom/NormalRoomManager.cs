using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRoomManager : MonoBehaviour
{
    [Header("DIFERENT TYPES OF NORMAL ROOMS ROOMS:")]
    public GameObject normalRoom1;
    public GameObject normalRoom2;
    public GameObject normalRoom3;
    public GameObject normalRoom4;
    public GameObject normalRoom5;
    
    [Header("SPAWN THINGS:")]

    public int normalRoomRndVar;
    public bool emptyRoom;

    bool oneTime;

    void Start()
    {
        normalRoomRndVar = Random.Range(0,6);
    }

    // Update is called once per frame
    void Update()
    {
        //CHOOOSE RANDOM ROOM
        ChooseRandomRoom();
        //------------------
    }

    //Choose Rooom
    void ChooseRandomRoom()
    {
        switch(normalRoomRndVar)
        {
            case 0: emptyRoom = true; break;
            case 1:
                if(!oneTime)
                {
                    Instantiate(normalRoom1, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            break;
            case 2:
                if(!oneTime)
                {
                    Instantiate(normalRoom2, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            break;
            case 3:
                if(!oneTime)
                {
                    Instantiate(normalRoom3, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            break;
            case 4:
                if(!oneTime)
                {
                    Instantiate(normalRoom4, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            break;
            case 5:
                if(!oneTime)
                {
                    Instantiate(normalRoom5, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            break;
            
            case 6: emptyRoom = true; break;

        }
    }
}
