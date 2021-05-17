using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoxScript : MonoBehaviour
{
    [Header("AUTOMATIC OBJECTS:")]   
    public GameObject player;
    public GameObject child;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        child =  this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        WizardController();
    }

    //ACTIVE THE WIZARD's OR NOT
    void WizardController()
    {
        if(child != null)
        {
            if(player.GetComponent<ProtoBLACKBOARD_Player>().activeSpecialRoomSkins)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        
    }
}
