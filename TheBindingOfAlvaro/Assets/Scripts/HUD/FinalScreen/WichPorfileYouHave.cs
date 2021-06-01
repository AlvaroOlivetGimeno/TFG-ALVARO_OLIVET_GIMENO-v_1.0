using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WichPorfileYouHave : MonoBehaviour
{
    [Header("FOR DEBUG AND EDIT")]

    public GameObject action;
    public GameObject maestry;

    public GameObject achievement;

    public GameObject creativity;

    [Header("AUTOMATIC ELEMENTS:")]

    public GameObject masterBrain;
    public GameObject player;
    public GameObject otherSoundManager;

    //SOUNDSS
    bool playSound;


    void Start()
    {
        masterBrain = GameObject.FindGameObjectWithTag("MasterBrain");
        player = GameObject.FindGameObjectWithTag("Player");
        otherSoundManager = GameObject.FindGameObjectWithTag("OtherSoundManager");
        action.SetActive(false);
        maestry.SetActive(false);
        achievement.SetActive(false);
        creativity.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActiveProfile();
    }

    void ActiveProfile()
    {
        if (Input.GetKeyDown(KeyCode.K) && masterBrain.GetComponent<MasterBrainScript>().choosenProfile != 0)
        {   
            //if(!playSound)
            //{
                player.GetComponent<PlayerSoundManager>().congrats.GetComponent<SoundScript>().StopSound();
                otherSoundManager.GetComponent<OtherSoundsManager>().badumThiss.GetComponent<SoundScript>().PlaySound();
                //playSound = true;
            //}
            //else
            //{
                switch(masterBrain.GetComponent<MasterBrainScript>().choosenProfile)
                {
                    case 1: action.SetActive(true); break;
                    case 2: maestry.SetActive(true); break;
                    case 3: achievement.SetActive(true); break;
                    case 4: creativity.SetActive(true); break;
                }
            //}
            
            
        }
    }
}
