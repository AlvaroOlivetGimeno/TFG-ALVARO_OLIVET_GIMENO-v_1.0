using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonPause : MonoBehaviour
{
   [Header("AUTOMATIC OBJECTS:")]   
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        ActiveButtonPause();
    }

    //ACTIVE OR DESACTIVE
    void ActiveButtonPause()
    {
        if(player.GetComponent<ProtoBLACKBOARD_Player>().activeMapMecanic)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
