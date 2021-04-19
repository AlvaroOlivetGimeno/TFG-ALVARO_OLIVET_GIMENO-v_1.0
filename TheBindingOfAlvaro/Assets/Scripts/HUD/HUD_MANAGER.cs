using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_MANAGER : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;

    [Header("SPECIAL HABILITY's GAME OBJECTS (HUD)")]

    public GameObject sh1;
    public GameObject sh2;
    public GameObject sh3;
    public GameObject sh4;
    public GameObject sh5;
    public GameObject sh0;


    ProtoBLACKBOARD_Player BlackBoardPlayer;
    //ProtoPlayerScript protoPlayerScript;

    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        //protoPlayerScript = GetComponent<ProtoPlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //------------------------LIFE-------------------------
        lifeController();

        //------------------

        //-------------------HABILITYS-------------------------
        habilityController();

        //-------------------
    }


    void lifeController()
    {
        switch (BlackBoardPlayer.characterLife)
        {
            case 0: l1.gameObject.SetActive(false); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 1: l1.gameObject.SetActive(true); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 2: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 3: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 4: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(false); break;
            case 5: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(true); break;
        }
    }

    void habilityController()
    {
        switch (BlackBoardPlayer.specialHabilityCatcth)
        {
            case 0: sh0.SetActive(false); sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
            case 1: sh0.SetActive(true); sh1.SetActive(true); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
            case 2: sh0.SetActive(true); sh1.SetActive(false); sh2.SetActive(true); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
            case 3: sh0.SetActive(true); sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(true); sh4.SetActive(false); sh5.SetActive(false); break;
            case 4: sh0.SetActive(true); sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(true); sh5.SetActive(false); break;
            case 5: sh0.SetActive(true); sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(true); break;
        }
    }

}
