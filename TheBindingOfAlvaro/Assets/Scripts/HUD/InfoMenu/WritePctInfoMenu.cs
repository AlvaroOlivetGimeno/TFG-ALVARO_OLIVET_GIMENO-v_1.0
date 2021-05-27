using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritePctInfoMenu : MonoBehaviour
{
    [Header("MARK IF IT's AN INDICATOR, AND CHOOSE THE TYPE")]
    public bool indicator;

    public float typeOfIndicator; //1 al 5 mon i gameplay/ 6 al 10 accio i interacció

    [Header("MARK IF IT's AN GLOBAL Pct, AND CHOOSE THE TYPE")]
    public bool globalPct;
    public float typeOfGlobalPct; //1 action 2. maestry 3. achievement 4.creativity

    [Header("MARK IF IT's A POSITION, AND CHOOSE THE TYPE")]
    public bool position;

    public float typeOfposition; //1 al 5 mon i gameplay/ 6 al 10 accio i interacció

    [Header("AUTOMATIC ELEMENTS:")]
    public Text text;

    public GameObject masterBrain;
    void Start()
    {
        text = GetComponent<Text>();
        masterBrain = GameObject.FindGameObjectWithTag("MasterBrain");
        
    }

    // Update is called once per frame
    void Update()
    {
        WriteController();
    }

    void WriteController()
    {
        if(indicator)
        {
            WriteIndicators();
        }
        else if(globalPct)
        {
            WriteGlobalPct();
        }
        else if(position)
        {
            WritePosition();
        }
    }

    void WriteIndicators()
    {
        switch(typeOfIndicator)
        {
            case 1: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().roomPctMon) + "%"; break;
            case 2: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().cristalPctMon) + "%"; break;
            case 3: text.text =  Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().moneyPctMon) + "%"; break;
            case 4: text.text =  Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().wastedMoneyPctMon) + "%"; break;
            case 5: text.text =  Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().specialHabilityPctMon) + "%"; break;

            case 6: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().enemysKilledPctAction) + "%"; break;
            case 7: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().parryPctAction) + "%"; break;
            case 8: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().livePctAction) + "%"; break;
            case 9: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().bulletPctAction) + "%"; break;
            case 10: text.text = Mathf.Round(masterBrain.GetComponent<MasterBrainScript>().enemyRoomPctAction) + "%"; break;
        }
    }

    void WriteGlobalPct()
    {
        switch(typeOfGlobalPct)
        {
            case 1: text.text = Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().pctProfileAction) + "%"; break;
            case 2: text.text = Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().pctProfileMaestry) + "%"; break;
            case 3: text.text = Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().pctProfileAchievement) + "%"; break;
            case 4: text.text = Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().pctProfileCreativity) + "%"; break;
        }
    }

    void WritePosition()
    {
        switch(typeOfposition)
        {
            case 1: text.text = Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().xPos)+ ""; break;
            case 2: text.text =Mathf.Round( masterBrain.GetComponent<MasterBrainScript>().yPos)+ ""; break;
        }
    }
    

}
