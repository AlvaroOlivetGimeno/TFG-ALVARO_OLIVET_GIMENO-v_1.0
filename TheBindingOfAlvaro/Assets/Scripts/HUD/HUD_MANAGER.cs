using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_MANAGER : MonoBehaviour
{
    [Header("FOR DEBUG AND EDIT")]
    public bool desactiveLoadingScreen;

    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;

    [Header("LIFE's SPACE GAME OBJECTS (HUD)")]

    public GameObject ls1;
    public GameObject ls2;
    public GameObject ls3;
    public GameObject ls4;
    public GameObject ls5;

    [Header("SPECIAL HABILITY's GAME OBJECTS (HUD)")]

    public GameObject sh1;
    public GameObject sh2;
    public GameObject sh3;
    public GameObject sh4;
    public GameObject sh5;
    public GameObject sh0;
    
    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject pauseMenu;

    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject BlackScreen;

    [Header("LOADING SCREEN (HUD)")]

    public GameObject loadingScreen;

    [Header("GAME OVER SCREEN (HUD)")]
    public GameObject gameOverScreen;



    //ANTOHER VARIABLES
    ProtoBLACKBOARD_Player BlackBoardPlayer;
    GameObject roomBrain;
   

    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        roomBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        gameOverScreen.SetActive(false);
        //protoPlayerScript = GetComponent<ProtoPlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //------------------------LIFE-------------------------
        lifeController();
        lifeSpaceController();
        
        //------------------

        //-------------------HABILITYS-------------------------
        habilityController();

        //-------------------

        //-------------------LOADING SCREEN--------------------
        if(!desactiveLoadingScreen)
        {
            LoadingScreenController();
        }
        

        //---------------------
    }


    void lifeController()
    {
        switch (BlackBoardPlayer.characterLife)
        {
            case 0: l1.gameObject.SetActive(false); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); 
                    gameOverScreen.SetActive(true);
            break;
            case 1: l1.gameObject.SetActive(true); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 2: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 3: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 4: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(false); break;
            case 5: l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(true); break;
        }
    }

    void lifeSpaceController()
    {
        switch (BlackBoardPlayer.characterSpaceLife)
        {
            case 0: ls1.gameObject.SetActive(false); ls2.gameObject.SetActive(false); ls3.gameObject.SetActive(false); ls4.gameObject.SetActive(false); ls5.gameObject.SetActive(false); break;
            case 1: ls1.gameObject.SetActive(true); ls2.gameObject.SetActive(false); ls3.gameObject.SetActive(false); ls4.gameObject.SetActive(false); ls5.gameObject.SetActive(false); break;
            case 2: ls1.gameObject.SetActive(true); ls2.gameObject.SetActive(true); ls3.gameObject.SetActive(false); ls4.gameObject.SetActive(false); ls5.gameObject.SetActive(false); break;
            case 3: ls1.gameObject.SetActive(true); ls2.gameObject.SetActive(true); ls3.gameObject.SetActive(true); ls4.gameObject.SetActive(false); ls5.gameObject.SetActive(false); break;
            case 4: ls1.gameObject.SetActive(true); ls2.gameObject.SetActive(true); ls3.gameObject.SetActive(true); ls4.gameObject.SetActive(true); ls5.gameObject.SetActive(false); break;
            case 5: ls1.gameObject.SetActive(true); ls2.gameObject.SetActive(true); ls3.gameObject.SetActive(true); ls4.gameObject.SetActive(true); ls5.gameObject.SetActive(true); break;
        }
    }

    void habilityController()
    {
        if(BlackBoardPlayer.loadingSpecialHability)
        {
            switch (BlackBoardPlayer.specialHabilityCatcth)
            {
                case 0: sh0.SetActive(false); sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
                case 1: sh0.SetActive(true); sh0.GetComponent<FillAmountImage>().image.fillAmount = 1;
                        sh1.SetActive(true); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
                case 2: sh0.SetActive(true); sh0.GetComponent<FillAmountImage>().image.fillAmount = 1;
                        sh1.SetActive(false); sh2.SetActive(true); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(false); break;
                case 3: sh0.SetActive(true); sh0.GetComponent<FillAmountImage>().image.fillAmount = 1;
                        sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(true); sh4.SetActive(false); sh5.SetActive(false); break;
                case 4: sh0.SetActive(true); sh0.GetComponent<FillAmountImage>().image.fillAmount = 1;
                        sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(true); sh5.SetActive(false); break;
                case 5: sh0.SetActive(true); sh0.GetComponent<FillAmountImage>().image.fillAmount = 1;
                        sh1.SetActive(false); sh2.SetActive(false); sh3.SetActive(false); sh4.SetActive(false); sh5.SetActive(true); break;
            }
        }
        else
        {
            sh0.GetComponent<FillAmountImage>().image.fillAmount = (BlackBoardPlayer.enemysKillToReloadSpecialHability)/10;
            sh1.SetActive(false); 
            sh2.SetActive(false); 
            sh3.SetActive(false); 
            sh4.SetActive(false); 
            sh5.SetActive(false);
        }
       
    }

    void LoadingScreenController()
    {
        if(roomBrain.GetComponent<RoomTemplates>().ReadyToSeTheMap())
        {
            loadingScreen.SetActive(false);
        }
        else
        {
            loadingScreen.SetActive(true);
        }
    }

}
