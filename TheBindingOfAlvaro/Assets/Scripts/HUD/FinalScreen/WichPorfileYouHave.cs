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


    void Start()
    {
        masterBrain = GameObject.FindGameObjectWithTag("MasterBrain");
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
            switch(masterBrain.GetComponent<MasterBrainScript>().choosenProfile)
            {
                case 1: action.SetActive(true); break;
                case 2: maestry.SetActive(true); break;
                case 3: achievement.SetActive(true); break;
                case 4: creativity.SetActive(true); break;
            }
        }
    }
}
