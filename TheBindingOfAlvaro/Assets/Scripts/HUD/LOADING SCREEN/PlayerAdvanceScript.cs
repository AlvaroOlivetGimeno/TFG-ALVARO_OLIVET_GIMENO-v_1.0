using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvanceScript : MonoBehaviour
{
    [Header("LEVELS:")]
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;
    public GameObject lvl5; 
    public GameObject lvl6;
    public GameObject lvl7;
    public GameObject lvl8;
    public GameObject lvl9;
    public GameObject lvl10;

    [Header("AUTOMATIC ELEMENTS:")]
    public GameObject player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShowLevels();
    
    }

    void ShowLevels()
    {
        switch(player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel)
        {
            case 1: lvl1.SetActive(true); lvl2.SetActive(false);lvl3.SetActive(false);lvl4.SetActive(false);lvl5.SetActive(false);
                    lvl6.SetActive(false);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 2: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(false);lvl4.SetActive(false);lvl5.SetActive(false);
                    lvl6.SetActive(false);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 3: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(false);lvl5.SetActive(false);
                    lvl6.SetActive(false);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 4: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(false);
                    lvl6.SetActive(false);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 5: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(false);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 6: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(true);lvl7.SetActive(false);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 7: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(true);lvl7.SetActive(true);lvl8.SetActive(false);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 8: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(true);lvl7.SetActive(true);lvl8.SetActive(true);lvl9.SetActive(false);lvl10.SetActive(false);
            break;
             case 9: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(true);lvl7.SetActive(true);lvl8.SetActive(true);lvl9.SetActive(true);lvl10.SetActive(false);
            break;
             case 10: lvl1.SetActive(true); lvl2.SetActive(true);lvl3.SetActive(true);lvl4.SetActive(true);lvl5.SetActive(true);
                    lvl6.SetActive(true);lvl7.SetActive(true);lvl8.SetActive(true);lvl9.SetActive(true);lvl10.SetActive(true);
            break;
        }
    }
}
