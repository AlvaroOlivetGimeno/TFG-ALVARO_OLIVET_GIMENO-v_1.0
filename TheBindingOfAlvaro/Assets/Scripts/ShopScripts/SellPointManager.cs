using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPointManager : MonoBehaviour
{
    [Header("AUTOMATIC VARIABLES:")]
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        WichPointsIActive();
    }

    //Wich points I have to Active??
    void WichPointsIActive()
    {
        if(player.GetComponent<ProtoBLACKBOARD_Player>().activeShopColorSkins && player.GetComponent<ProtoBLACKBOARD_Player>().activeShopDrawSkins)
        {
            if( this.transform.GetChild(3).gameObject != null)
            {
                this.transform.GetChild(3).gameObject.SetActive(true);
            }
            if( this.transform.GetChild(4).gameObject != null)
            {
                this.transform.GetChild(4).gameObject.SetActive(true);
            }  
        }
        else
        {
            if( this.transform.GetChild(3).gameObject != null)
            {
                this.transform.GetChild(3).gameObject.SetActive(false);
            }
            if( this.transform.GetChild(4).gameObject != null)
            {
                this.transform.GetChild(4).gameObject.SetActive(false);
            }  
        }
    }
}
