using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CircleCollider2D))]
public class ShopPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("POINT TYPE:")]
    public float pointType; //1. Special Hability  2. Passive Hability 3.Life
    
    [Header("PREFAB's OF SPECIAL HABILITYS:")]
    public GameObject invulnerabilitat;
    public GameObject totalParry;
    public GameObject tirQuadruple;
    public GameObject depredador;
    public GameObject superKill;

    [Header("PREFAB's OF PASSIVE HABILITYS:")]
    public GameObject lifePlus;
    public GameObject speedPlus;
    public GameObject delayShootPlus;

    [Header("PREFAB's OF HEART:")]
    public GameObject heart;

    [Header("RANDOM NUM:")]
    public int rndVar;

    [Header("AUTOMATIC VARIABLES:")]
    
    public float prize;
    public GameObject player;

    public Collider2D m_ObjectCollider;

    public GameObject cameraPoint;

    bool oneTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_ObjectCollider = GetComponent<Collider2D>();
        //START METOD
        StartMetod();

    }

    // Update is called once per frame
    void Update()
    {
        //--------------CHECK COLLIDER-------------
        CanIBuyIt();

        //---------

        //--------------SPAWNER--------------------
        SpawnProduct();
        
        //-------------

        //--------------CANVAS THINGS----------------
        CanvasController();

        //--------------

        //Debug.Log(this.transform.GetChild(0).name);

    }

    //START METOD
    void StartMetod()
    {
        switch(pointType)
        {
            case 1: rndVar = Random.Range(1,5);  
                    prize = 30;
            break;
            case 2: rndVar = Random.Range(1,3); 
                    prize = 15;
            break; 
            case 3: prize = 5;
                    
            break;
              
        }
    }

    //CAN I BUY IT?
    public void CanIBuyIt()
    {
        if(player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney>= prize)
        {
            m_ObjectCollider.isTrigger = true;
        }
        else
        {
            m_ObjectCollider.isTrigger = false;
        }
    }

    //SPAWNER
    public void SpawnProduct()
    {
        switch(pointType)
        {
            case 1: 
                switch(rndVar)
                {
                    case 1: if(!oneTime)
                            {
                                Instantiate(invulnerabilitat, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 2: if(!oneTime)
                            {
                                Instantiate(totalParry, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 3: if(!oneTime)
                            {
                                Instantiate(tirQuadruple, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 4: if(!oneTime)
                            {
                                Instantiate(depredador, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 5: if(!oneTime)
                            {
                                Instantiate(superKill, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                }
            break;

            case 2: 
                switch(rndVar)
                {
                    case 1: if(!oneTime)
                            {
                                Instantiate(lifePlus, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 2: if(!oneTime)
                            {
                                Instantiate(speedPlus, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                    case 3: if(!oneTime)
                            {
                                Instantiate(delayShootPlus, this.transform.position, Quaternion.identity);
                                oneTime = true;
                            }
                    break;
                }
            break;

            case 3: if(!oneTime)
                    {
                        Instantiate(heart, this.transform.position, heart.transform.rotation);
                        oneTime = true;
                    }
            break;
        }
    }

    //CANVAS CONTROLER
    void CanvasController()
    {
        if(cameraPoint != null)
        {
            if(cameraPoint.GetComponent<CameraPointScript>().isPlayerHere)
            {
                if(player.GetComponent<ProtoBLACKBOARD_Player>().activePause)
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        
    }
    

    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other) 
    {

        //--------------------------------------PLAYER CONTACT------------------------------

        if(other.gameObject.tag == "Player")
        {
            if(pointType == 3)
            {
                if(player.GetComponent<ProtoBLACKBOARD_Player>().characterLife < player.GetComponent<ProtoBLACKBOARD_Player>().characterSpaceLife)
                {
                   player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney -= prize;
                   Destroy(this.gameObject); 
                }
                else
                {
                   
                }
            }
            else
            {
                player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney -= prize;
                Destroy(this.gameObject);
            }
        }

        //----------------------------------------------------------------------------------------

        //---------------------------------CAMERA POINT CONTACT----------------------------------

        if(other.gameObject.tag == "CamaraPoint")
        {

            cameraPoint = other.gameObject;
        }

        //----------------------------------------------------------------------------------------

    }

}
