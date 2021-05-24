using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumBulletIndicator : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public bool sumBulletOneTime;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!sumBulletOneTime)
        {
            player.GetComponent<ProtoBLACKBOARD_Player>().totalBulletsShooted += 1;
            sumBulletOneTime = true;
        }
    }
}
