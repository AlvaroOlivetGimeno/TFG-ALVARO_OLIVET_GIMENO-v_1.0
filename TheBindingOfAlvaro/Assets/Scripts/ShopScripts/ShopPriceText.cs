using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPriceText : MonoBehaviour
{
    [Header("SHOP TEXT TYPE:")]

    public float shopTextType;

    [Header("SHOP TEXT TYPE:")]

    public Color normalText;
    public Color expensiveText;
    
    [Header("AUTOMATIC VARIABLES:")]

    public Text txt;

    public float prize;

    GameObject player;



    void Start()
    {
        txt = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");

        StartMetod();

    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    //StartMetod
    void StartMetod()
    {
        switch(shopTextType)
        {
            case 1:prize = 30; break;
            case 2:prize = 10; break;
            case 3:prize = 5; break;
            case 4:prize = 8; break;
        }
    }

    //CHANGE COLOR
    void ChangeColor()
    {
        if(prize> player.GetComponent<ProtoBLACKBOARD_Player>().characterMoney)
        {
            txt.GetComponent<Text>().color = expensiveText;
        }
        else
        {
            txt.GetComponent<Text>().color = normalText;
        }
    }

    
}
