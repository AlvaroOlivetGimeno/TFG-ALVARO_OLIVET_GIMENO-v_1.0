using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPointManager : MonoBehaviour
{
    [Header("AUTOMATIC VARIABLES:")]
    public GameObject player;

    [Header("POINTS FOR ANOTHER ELEMENTS:")]

    public GameObject skinPoint;
    public GameObject drawPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        skinPoint.gameObject.SetActive(false);
        drawPoint.gameObject.SetActive(false);
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
            if(skinPoint != null)
            {
               skinPoint.gameObject.SetActive(true);
            }
            if( drawPoint != null)
            {
               drawPoint.gameObject.SetActive(true);
            }  
        }
        else
        {
            if(skinPoint != null)
            {
               skinPoint.gameObject.SetActive(false);
            }
            if( drawPoint != null)
            {
               drawPoint.gameObject.SetActive(false);
            }  
        }
    }
}
