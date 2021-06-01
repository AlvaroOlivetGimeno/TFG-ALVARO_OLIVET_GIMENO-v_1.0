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

    [Header("RND VAR")] 
    public float rndVar;

    GameObject player;

    
    
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
                
                    song1.GetComponent<SoundScript>().PlaySound();
                    song1.GetComponent<SoundScript>().iHaveApeear = true;  
                    //song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();
                
            break;
             case 2:
               
                    song2.GetComponent<SoundScript>().PlaySound();
                    song2.GetComponent<SoundScript>().iHaveApeear = true; 
                    song1.GetComponent<SoundScript>().StopSound();
                    //song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound(); 
                
            break;
             case 3:
                    song3.GetComponent<SoundScript>().PlaySound();
                    song3.GetComponent<SoundScript>().iHaveApeear = true;  
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    //song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();
               
            break;
             case 4:
               
                    song4.GetComponent<SoundScript>().PlaySound();
                    song4.GetComponent<SoundScript>().iHaveApeear = true;
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    //song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();  
               
            break;
             case 5:
                
                    song5.GetComponent<SoundScript>().PlaySound();
                    song5.GetComponent<SoundScript>().iHaveApeear = true;  
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    //song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();
                
            break;
             case 6:
                
                    song6.GetComponent<SoundScript>().PlaySound();
                    song6.GetComponent<SoundScript>().iHaveApeear = true; 
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    //song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound(); 
               
            break;
              case 7:
                    song7.GetComponent<SoundScript>().PlaySound();
                    song7.GetComponent<SoundScript>().iHaveApeear = true;  
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    //song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();
               
            break;
             case 8:
               
                    song8.GetComponent<SoundScript>().PlaySound();
                    song8.GetComponent<SoundScript>().iHaveApeear = true;
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    //song8.GetComponent<SoundScript>().StopSound();
                    song9.GetComponent<SoundScript>().StopSound();  
               
            break;
             case 9:
                
                    song9.GetComponent<SoundScript>().PlaySound();
                    song9.GetComponent<SoundScript>().iHaveApeear = true; 
                    song1.GetComponent<SoundScript>().StopSound();
                    song2.GetComponent<SoundScript>().StopSound();
                    song3.GetComponent<SoundScript>().StopSound();
                    song4.GetComponent<SoundScript>().StopSound();
                    song5.GetComponent<SoundScript>().StopSound();
                    song6.GetComponent<SoundScript>().StopSound();
                    song7.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    song8.GetComponent<SoundScript>().StopSound();
                    //song9.GetComponent<SoundScript>().StopSound(); 
            break;
        }
    }
}
