using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumCoinToIndicators : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public bool sumMoneyOneTime;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!sumMoneyOneTime)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().totalMoneyOnTheGameThatPlayerCanWin += 1;
            sumMoneyOneTime = true;
        }
    }
}
