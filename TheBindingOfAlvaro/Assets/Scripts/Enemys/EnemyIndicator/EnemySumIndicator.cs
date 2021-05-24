using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySumIndicator : MonoBehaviour
{
      [Header("AUTOMATIC ELEMENTS:")]
    public bool sumEnemyOneTime;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!sumEnemyOneTime)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().totalEnemys += 1;
            sumEnemyOneTime = true;
        }
    }
}
