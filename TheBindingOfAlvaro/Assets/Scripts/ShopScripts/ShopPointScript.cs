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

    public CircleCollider2D circleCollider;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        circleCollider = circleCollider.GetComponent<CircleCollider2D>();

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



    }

    //START METOD
    void StartMetod()
    {
        switch(pointType)
        {
            case 1: rndVar = Random.Range(1,5);  break;
            case 2: rndVar = Random.Range(1,3); break;   
        }
    }

    //CAN I BUY IT?
    public void CanIBuyIt()
    {
        if(player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney>= prize)
        {
            circleCollider.isTrigger = true;
        }
        else
        {
            circleCollider.isTrigger = false;
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
                    case 1: Instantiate(invulnerabilitat, this.transform.position, Quaternion.identity); break;
                    case 2: Instantiate(totalParry, this.transform.position, Quaternion.identity); break;
                    case 3: Instantiate(tirQuadruple, this.transform.position, Quaternion.identity); break;
                    case 4: Instantiate(depredador, this.transform.position, Quaternion.identity); break;
                    case 5: Instantiate(superKill, this.transform.position, Quaternion.identity); break;
                }
            break;

            case 2: 
                switch(rndVar)
                {
                    case 1: Instantiate(lifePlus, this.transform.position, Quaternion.identity); break;
                    case 2: Instantiate(speedPlus, this.transform.position, Quaternion.identity); break;
                    case 3: Instantiate(delayShootPlus, this.transform.position, Quaternion.identity); break;
                }
            break;

            case 3: Instantiate(heart, this.transform.position, Quaternion.identity); break; 
        }
    }



}
