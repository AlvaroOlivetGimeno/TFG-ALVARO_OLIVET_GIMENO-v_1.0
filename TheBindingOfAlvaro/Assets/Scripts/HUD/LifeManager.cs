using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;


     ProtoBLACKBOARD_Player BlackBoardPlayer;

    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeController();
    }

    void lifeController()
    {
        switch(BlackBoardPlayer.characterLife)
        {
            case 0: l1.gameObject.SetActive(false); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 1: l1.gameObject.SetActive(true); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 2: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 3: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 4: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(false); break;
            case 5: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(true); break;
        }
    }

    
}
