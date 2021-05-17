using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomPoint : MonoBehaviour
{
    [Header("TIPE OF POINT:")]
    public float pointType; //1.Active Hability  2.Special Hability
    
    [Header("VARIABLE RANDOM:")]
    public float rndVar;
    public float rndVarSpecial;
    public float rndVarSkin;


    [Header("STUPID DESTROYER LIST:")]

    public List<GameObject> activeHability;
    public List<GameObject> passiveHability;

    [Header("ACTIVE + PASSIVE HABILITY:")]
    public GameObject ah1;
    public GameObject ah2;
    public GameObject ah3;
    public GameObject ah4;
    public GameObject ah5;
    public GameObject ah6;
    public GameObject ph1;
    public GameObject ph2;
    public GameObject ph3;

    [Header("SPECIAL HABILITY:")]
    public GameObject sh1;
    public GameObject sh2;
    public GameObject sh3;
    public GameObject sh4;
    public GameObject sh5;

    [Header("SKIN's -COLOR + DRAW-:")]
    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject color4;
    public GameObject draw1;
    public GameObject draw2;
    public GameObject draw3;
    public GameObject draw4;


    //OTHER

    public GameObject objSpawned;

    bool oneTime;
    public bool oneTimeSpecial;
    public bool oneTimeSkin;
    
    void Start()
    {
        rndVar = Random.Range(1,9);
        rndVarSpecial = Random.Range(1,6);
        rndVarSkin = Random.Range(1,8);
    }

    // Update is called once per frame
    void Update()
    {
        //POINT CONTROLLER---------------
        PointController();

        //DESTROY LAST HABILITY----------
        DestroyActiveHability();


    }

    //PointController
    void PointController()
    {
        switch(pointType)
        {
            case 1: ActiveState(); break;
            case 2: SpecialState();  break;
            case 3: ActiveSkinState(); break;
        }
    }

    //ACTIVE STATE
    void ActiveState()
    {
        if(!oneTime)
        {
            switch(rndVar)
            {
                case 1: Instantiate(ah1, this.transform.position, Quaternion.identity);
                        objSpawned = ah1;
                        oneTime = true;
                        break;
                case 2: Instantiate(ah2, this.transform.position, Quaternion.identity);
                        objSpawned = ah2;
                        oneTime = true;
                        break;
                case 3: Instantiate(ah3, this.transform.position, Quaternion.identity);
                        objSpawned = ah3;
                        oneTime = true;
                        break;
                case 4: Instantiate(ah4, this.transform.position, Quaternion.identity);
                        objSpawned = ah4;
                        oneTime = true;
                        break;
                case 5: Instantiate(ah5, this.transform.position, Quaternion.identity);
                        objSpawned = ah5;
                        oneTime = true;
                        break;
                case 6: Instantiate(ah6, this.transform.position, Quaternion.identity);
                        objSpawned = ah6;
                        oneTime = true;
                        break;
                case 7: Instantiate(ph1, this.transform.position, Quaternion.identity);
                        objSpawned = ph1;
                        oneTime = true;
                        break;
                case 8: Instantiate(ph2, this.transform.position, Quaternion.identity);
                        objSpawned = ph2;
                        oneTime = true;
                        break;
                case 9: Instantiate(ph3, this.transform.position, Quaternion.identity);
                        objSpawned = ph3;
                        oneTime = true;
                        break;
            }
        }
    }
   
   //SPECIAL STATE
    void SpecialState()
    {
        if(!oneTimeSpecial)
        {
            switch(rndVarSpecial)
            {
                case 1: Instantiate(sh1, this.transform.position, Quaternion.identity);
                        oneTimeSpecial = true;
                        break;
                case 2:Instantiate(sh2, this.transform.position, Quaternion.identity);
                        oneTimeSpecial = true;
                        break;
                case 3: Instantiate(sh3, this.transform.position, Quaternion.identity);
                        oneTimeSpecial = true;
                        break;
                case 4: Instantiate(sh4, this.transform.position, Quaternion.identity);
                        oneTimeSpecial = true;
                        break;
                case 5: Instantiate(sh5, this.transform.position, Quaternion.identity);
                        oneTimeSpecial = true;
                        break;
                case 6: rndVar = Random.Range(1,5);
                        SpecialState();
                        break;
            }
        }
    }

    //ACTIVE SKIN's
    void ActiveSkinState()
    {
        if(!oneTimeSkin)
        {
            switch(rndVarSkin)
            {
                case 1: Instantiate(color1, this.transform.position, Quaternion.identity);
                        objSpawned = color1;
                        oneTimeSkin = true;
                        break;
                case 2: Instantiate(color2, this.transform.position, Quaternion.identity);
                        objSpawned = color2;
                        oneTimeSkin = true;
                        break;
                case 3: Instantiate(color3, this.transform.position, Quaternion.identity);
                        objSpawned = color3;
                        oneTimeSkin = true;
                        break;
                case 4: Instantiate(color4, this.transform.position, Quaternion.identity);
                        objSpawned = color4;
                        oneTimeSkin = true;
                        break;
                case 5: Instantiate(draw1, this.transform.position, Quaternion.identity);
                        objSpawned = draw1;
                        oneTimeSkin = true;
                        break;
                case 6: Instantiate(draw2, this.transform.position, Quaternion.identity);
                        objSpawned = draw2;
                        oneTimeSkin = true;
                        break;
                case 7: Instantiate(draw3, this.transform.position, Quaternion.identity);
                        objSpawned = draw3;
                        oneTimeSkin = true;
                        break;
                case 8: Instantiate(draw4, this.transform.position, Quaternion.identity);
                        objSpawned = draw4;
                        oneTimeSkin = true;
                        break;
            }
        }
    }

    //DESTROY LAST HABILITY
    void DestroyActiveHability()
    {
        if(pointType != 1)
        {
            if(activeHability.Count != 0)
            {
                foreach(GameObject x in activeHability)
                {
                    
                    Destroy(x.gameObject);
                }
            }
            
            if(passiveHability.Count != 0)
            {
                foreach(GameObject x in passiveHability)
                {
                    
                    Destroy(x.gameObject);
                }
            }
        }
        
    }

    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.gameObject.tag == "ActiveHability")
        {
           activeHability.Add(other.gameObject);
           
            
        }
        if(other.gameObject.tag == "PassiveHability")
        {
           passiveHability.Add(other.gameObject);
           
            
        }

    }
 
}
