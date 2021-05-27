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
            case 1: text.text = masterBrain.GetComponent<MasterBrainScript>().roomPctMon.ToString() + "%"; break;
            case 2: text.text = masterBrain.GetComponent<MasterBrainScript>().cristalPctMon.ToString() + "%"; break;
            case 3: text.text = masterBrain.GetComponent<MasterBrainScript>().moneyPctMon.ToString() + "%"; break;
            case 4: text.text = masterBrain.GetComponent<MasterBrainScript>().wastedMoneyPctMon.ToString() + "%"; break;
            case 5: text.text = masterBrain.GetComponent<MasterBrainScript>().specialHabilityPctMon.ToString() + "%"; break;

            case 6: text.text = masterBrain.GetComponent<MasterBrainScript>().enemysKilledPctAction.ToString() + "%"; break;
            case 7: text.text = masterBrain.GetComponent<MasterBrainScript>().parryPctAction.ToString() + "%"; break;
            case 8: text.text = masterBrain.GetComponent<MasterBrainScript>().livePctAction.ToString() + "%"; break;
            case 9: text.text = masterBrain.GetComponent<MasterBrainScript>().bulletPctAction.ToString() + "%"; break;
            case 10: text.text = masterBrain.GetComponent<MasterBrainScript>().enemyRoomPctAction.ToString() + "%"; break;
        }
    }

    void WriteGlobalPct()
    {
        switch(typeOfGlobalPct)
        {
            case 1: text.text = masterBrain.GetComponent<MasterBrainScript>().pctProfileAction.ToString() + "%"; break;
            case 2: text.text = masterBrain.GetComponent<MasterBrainScript>().pctProfileMaestry.ToString() + "%"; break;
            case 3: text.text = masterBrain.GetComponent<MasterBrainScript>().pctProfileAchievement.ToString() + "%"; break;
            case 4: text.text = masterBrain.GetComponent<MasterBrainScript>().pctProfileCreativity.ToString() + "%"; break;
        }
    }

    void WritePosition()
    {
        switch(typeOfposition)
        {
            case 1: text.text = masterBrain.GetComponent<MasterBrainScript>().xPos.ToString(); break;
            case 2: text.text = masterBrain.GetComponent<MasterBrainScript>().yPos.ToString(); break;
        }
    }
    

}
