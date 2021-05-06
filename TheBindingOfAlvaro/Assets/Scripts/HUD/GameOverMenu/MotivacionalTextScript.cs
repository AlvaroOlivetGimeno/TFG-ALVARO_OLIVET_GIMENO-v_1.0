using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotivacionalTextScript : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]

    public Text text;

    public GameObject player;

    [Header("MOTIVACIONAL TEXT's:")]
    public string textlvl1;
    public string textlvl2;
    public string textlvl3;
    public string textlvl4;
    public string textlvl5;
    public string textlvl6;
    public string textlvl7;
    public string textlvl8;
    public string textlvl9;
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        ChooseText();
    }

    //CHOOSE TEXT
    void ChooseText()
    {
        switch(player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel)
        {
            case 1: text.text = textlvl1; break;
            case 2: text.text = textlvl2; break;
            case 3: text.text = textlvl3; break;
            case 4: text.text = textlvl4; break;
            case 5: text.text = textlvl5; break;
            case 6: text.text = textlvl6; break;
            case 7: text.text = textlvl7; break;
            case 8: text.text = textlvl8; break;
            case 9: text.text = textlvl9; break;

            
        }
    }
}
