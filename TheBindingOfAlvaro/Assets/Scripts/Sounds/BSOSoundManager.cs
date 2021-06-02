using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSOSoundManager : MonoBehaviour
{
    [Header("SONG'S")] 
    public GameObject song1;
    public GameObject song2;
    public GameObject song3;
    public GameObject song4;
    public GameObject song5;
    public GameObject song6;
    public GameObject song7;
    public GameObject song8;
    public GameObject song9;

    [Header("VOLUMEN:")]

      public float volumen;  

    [Header("RND VAR")] 
    public float rndVar;

    GameObject player;

    bool song1OneTime;
    bool song2OneTime;
    bool song3OneTime;
    bool song4OneTime;
    bool song5OneTime;
    bool song6OneTime;
    bool song7OneTime;
    bool song8OneTime;
    bool song9OneTime;
    bool song10OneTime;

    
    
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        ChooseTheBSOMusic();
     
    }

    public void ChooseTheBSOMusic()
    {
        
       
        switch(player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel)
        {
            case 1:
            if(!song1OneTime)
            {
                
                song1.GetComponent<SoundScript>().PlaySound();  
                song1OneTime = true;   
            }
                   
                    
                
            break;
             case 2:
                if(!song2OneTime)
                {
                        
                        song1.GetComponent<SoundScript>().StopSound();  
                        song2.GetComponent<SoundScript>().PlaySound();  
                        song2OneTime = true;   
                }
                
            break;
             case 3:
                if(!song3OneTime)
                {
                        
                        song2.GetComponent<SoundScript>().StopSound();  
                        song3.GetComponent<SoundScript>().PlaySound();  
                        song3OneTime = true;   
                }
               
            break;
             case 4:
               
                if(!song4OneTime)
                {
                       
                        song3.GetComponent<SoundScript>().StopSound();  
                        song4.GetComponent<SoundScript>().PlaySound();  
                        song4OneTime = true; 
                }
            break;
             case 5:
                
                if(!song5OneTime)
                {
                      
                        song4.GetComponent<SoundScript>().StopSound();  
                        song5.GetComponent<SoundScript>().PlaySound();  
                        song5OneTime = true; 
                }  
                
            break;
             case 6:
                
                if(!song6OneTime)
                {
                       
                        song5.GetComponent<SoundScript>().StopSound();  
                        song6.GetComponent<SoundScript>().PlaySound();  
                        song6OneTime = true;    
                }
            break;
              case 7:
                if(!song7OneTime)
                {
                      
                        song6.GetComponent<SoundScript>().StopSound();  
                        song7.GetComponent<SoundScript>().PlaySound();  
                        song7OneTime = true;  
                }
            break;
             case 8:
               
                if(!song8OneTime)
                {
                       
                        song7.GetComponent<SoundScript>().StopSound();  
                        song8.GetComponent<SoundScript>().PlaySound();  
                        song8OneTime = true; 
                } 
               
            break;
             case 9:
                
                if(!song9OneTime)
                {
                        
                        song8.GetComponent<SoundScript>().StopSound();  
                        song9.GetComponent<SoundScript>().PlaySound();  
                        song9OneTime = true;  
                }
            break;
            case 10:
                
                if(!song10OneTime)
                {
                       
                        song9.GetComponent<SoundScript>().StopSound();  
                       
                        song10OneTime = true;  
                }
            break;
        }
    }

    public void NullVolumen()
    {
        Debug.Log("0 VOLUMEN");
        song1.GetComponent<SoundScript>().NullVolumen();
        song2.GetComponent<SoundScript>().NullVolumen();
        song3.GetComponent<SoundScript>().NullVolumen();
        song5.GetComponent<SoundScript>().NullVolumen();
        song4.GetComponent<SoundScript>().NullVolumen();
        song6.GetComponent<SoundScript>().NullVolumen();
        song7.GetComponent<SoundScript>().NullVolumen();
        song8.GetComponent<SoundScript>().NullVolumen();
        song9.GetComponent<SoundScript>().NullVolumen();
    }

    public void NormalVolumen()
    {
        Debug.Log("0.02 VOLUMEN");
        song1.GetComponent<SoundScript>().normalVolumen(volumen);
        song2.GetComponent<SoundScript>().normalVolumen(volumen);
        song3.GetComponent<SoundScript>().normalVolumen(volumen);
        song4.GetComponent<SoundScript>().normalVolumen(volumen);
        song5.GetComponent<SoundScript>().normalVolumen(volumen);
        song6.GetComponent<SoundScript>().normalVolumen(volumen);
        song7.GetComponent<SoundScript>().normalVolumen(volumen);
        song8.GetComponent<SoundScript>().normalVolumen(volumen);
        song9.GetComponent<SoundScript>().normalVolumen(volumen);
    }
}