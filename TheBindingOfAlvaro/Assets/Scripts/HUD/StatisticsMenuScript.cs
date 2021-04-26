using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("AUTOMATIC TEXT ELEMENT:")]
    public Text text;

    [Header("TYPE OF TEXT:")]
    public float textType; //1.Life  2.Speed  3.Shoot Speed  4.Money

    public GameObject blackBoardPlayer;

    void Start()
    {
        text = GetComponent<Text>();
        blackBoardPlayer = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        StatisticsController();

    }

    void StatisticsController()
    {
        switch(textType)
        {
            case 1: text.text = blackBoardPlayer.GetComponent<ProtoBLACKBOARD_Player>().characterLife.ToString(); break;
            case 2: text.text = blackBoardPlayer.GetComponent<ProtoPlayerScript>().speed.ToString(); break;
            case 3: text.text = blackBoardPlayer.GetComponent<ProtoPlayerScript>().delayShoot.ToString(); break;
        }
    }
}