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

    [Header("SPECIAL HABILITY's -Color-")]
    public Color specialHabilityActiveColor;
    public Color specialHabilityReadyColor;
    public Color specialHabilityLoadingColor;
    
    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject pauseMenu;

    [Header("LIFE's GAME OBJECTS (HUD)")]

    public GameObject BlackScreen;

    [Header("LOADING SCREEN (HUD)")]

    public GameObject loadingScreen;

    [Header("GAME OVER SCREEN (HUD)")]
    public GameObject gameOverScreen;

    [Header("INFO SCREEN (HUD)")]

    public GameObject infoScreen;

    [Header("FINAL SCREEN (HUD)")]

    public GameObject finalScreen;

    [Header("1.ACTIVE -Feedback Prefab's-")]
    [Header("FEEDBACK HABILITYS (HUD)")]

    public GameObject f_dobleShoot;
    public GameObject f_simultaneousShoot;
    public GameObject f_superShoot;
    public GameObject f_freezeShoot;
    public GameObject f_minimumShoot;
    public GameObject f_maximumShoot;
    float f_activeHabilityTimer1 = 5;
    float f_activeHabilityTimer2 = 5;
    float f_activeHabilityTimer3 = 5;
    float f_activeHabilityTimer4 = 5;
    float f_activeHabilityTimer5 = 5;
    float f_activeHabilityTimer6 = 5;

    [Header("2.PASSIVE -Feedback Prefab's-")]

    public GameObject f_LivePassive;
    public GameObject f_SpeedPassive;
    public GameObject f_DelayPassive;
    float f_passiveHabilityTimer1 = 5;
    float f_passiveHabilityTimer2 = 5;
    float f_passiveHabilityTimer3 = 5;


    [Header("1.SPECIAL -Feedback Prefab's-")]
    
    public GameObject f_SuperParry;
    public GameObject f_Invencible;
    public GameObject f_QuadShoot;
    public GameObject f_Hunter;
    public GameObject f_SuperKill;
    float f_specialHabilityTimer1 = 5;
    float f_specialHabilityTimer2 = 5;
    float f_specialHabilityTimer3 = 5;
    float f_specialHabilityTimer4 = 5;
    float f_specialHabilityTimer5 = 5;


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
        ColorOfHabilityHUD();
        
        //-------------------

        //-------------------LOADING SCREEN--------------------
        if(!desactiveLoadingScreen)
        {
            LoadingScreenController();
        }
        

        //---------------------

        //-------------------------FEEDBACK----------------------
        FeedbackUpdate();

        //-------------

        //----------------------FINAL SCREEN------------------------
        FinalScreenLogic();

        //---------
    }


    void lifeController()
    {
        switch (BlackBoardPlayer.characterLife)
        {
            case 0:     l1.gameObject.SetActive(false); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); 
                        gameOverScreen.SetActive(true);break;    
            case 0.5f:  l1.GetComponent<FillAmountImage>().image.fillAmount = 0.5f;
                        l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false);break;
            case 1:     l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(false); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 1.5f:  l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 0.5f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 2:     l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(false); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 2.5f:  l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 0.5f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 3:     l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(false); l5.gameObject.SetActive(false); break;
            case 3.5f:  l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l4.GetComponent<FillAmountImage>().image.fillAmount = 0.5f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(false); break;
            case 4:     l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l4.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(false); break;
            case 4.5f:  l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l4.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l5.GetComponent<FillAmountImage>().image.fillAmount = 0.5f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(true); break;
            case 5:     l1.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l2.GetComponent<FillAmountImage>().image.fillAmount = 1f; 
                        l3.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l4.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l5.GetComponent<FillAmountImage>().image.fillAmount = 1f;
                        l1.gameObject.SetActive(true); l2.gameObject.SetActive(true); l3.gameObject.SetActive(true); l4.gameObject.SetActive(true); l5.gameObject.SetActive(true); break;
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

    //HABILITY COLOR
    void ColorOfHabilityHUD()
    {
        if(BlackBoardPlayer.SpecialHabilityIsActive)
        {
            sh0.GetComponent<FillAmountImage>().image.color = specialHabilityActiveColor;
        }
        else if(sh0.GetComponent<FillAmountImage>().image.fillAmount == 1 && !BlackBoardPlayer.SpecialHabilityIsActive)
        {
            sh0.GetComponent<FillAmountImage>().image.color = specialHabilityReadyColor;
        }
        else
        {
            sh0.GetComponent<FillAmountImage>().image.color = specialHabilityLoadingColor;
        }
    }

    void LoadingScreenController()
    {
        if(roomBrain.GetComponent<RoomTemplates>().ReadyToSeTheMap() && BlackBoardPlayer.actualLevel < 11)
        {
            loadingScreen.SetActive(false);
            BlackBoardPlayer.activeLoading = false;
        }
        else
        {
            loadingScreen.SetActive(true);
            BlackBoardPlayer.activeLoading = true;
        }
    }

    void FeedbackUpdate()
    {
        //ACTIVE HABILITY:
        ActiveHabilityFeedback();

        //PASSIVE HABILITY:
        PassiveHabilityFeedback();

        //SPECIAL HABILITY:
        SpecialHabilityFeedback();
    }

    void ActiveHabilityFeedback()
    {
        //TIMERS
        f_activeHabilityTimer1 += 1* Time.deltaTime;
        f_activeHabilityTimer2 += 1* Time.deltaTime;
        f_activeHabilityTimer3 += 1* Time.deltaTime;
        f_activeHabilityTimer4 += 1* Time.deltaTime;
        f_activeHabilityTimer5 += 1* Time.deltaTime;
        f_activeHabilityTimer6 += 1* Time.deltaTime;
        //------

        //DOBLE SHOOT
        if(f_activeHabilityTimer1<= 3)
        {
            f_dobleShoot.SetActive(true);
        }
        else
        {
            f_dobleShoot.SetActive(false);
        }

        //SIMULTANEOUS SHOOT
        if(f_activeHabilityTimer2<= 3)
        {
            f_simultaneousShoot.SetActive(true);
        }
        else
        {
            f_simultaneousShoot.SetActive(false);
        }

        //SUPER SHOOT
        if(f_activeHabilityTimer3<= 3)
        {
            f_superShoot.SetActive(true);
        }
        else
        {
            f_superShoot.SetActive(false);
        }

        //FREZZE SHOOT
        if(f_activeHabilityTimer4<= 3)
        {
            f_freezeShoot.SetActive(true);
        }
        else
        {
            f_freezeShoot.SetActive(false);
        }

        //MINIMUM SHOOT
        if(f_activeHabilityTimer5<= 3)
        {
            f_minimumShoot.SetActive(true);
        }
        else
        {
            f_minimumShoot.SetActive(false);
        }

        //MAXIMUM SHOOT
        if(f_activeHabilityTimer6<= 3)
        {
            f_maximumShoot.SetActive(true);
        }
        else
        {
            f_maximumShoot.SetActive(false);
        }

      
    }

    public void ActiveDobleShootFeedback()
    {
        f_activeHabilityTimer1 = 0;
    }
    public void ActiveSimultaneousShootFeedback()
    {
        f_activeHabilityTimer2 = 0;
    }
    public void ActiveSuperShootFeedback()
    {
        f_activeHabilityTimer3 = 0;
    }
    public void ActiveFreezeShootFeedback()
    {
        f_activeHabilityTimer4 = 0;
    }
    public void ActiveMinimumShootFeedback()
    {
        f_activeHabilityTimer5 = 0;
    }
    public void ActiveMaximumShootFeedback()
    {
        f_activeHabilityTimer6 = 0;
    }

    void PassiveHabilityFeedback()
    {
        //TIMERS
        f_passiveHabilityTimer1 += 1 * Time.deltaTime;
        f_passiveHabilityTimer2 += 1 * Time.deltaTime;
        f_passiveHabilityTimer3 += 1 * Time.deltaTime;
        //-----

        if(f_passiveHabilityTimer1 <= 3)
        {
            f_LivePassive.SetActive(true);
        }
        else
        {
            f_LivePassive.SetActive(false);
        }

        if(f_passiveHabilityTimer2 <= 3)
        {
            f_SpeedPassive.SetActive(true);
        }
        else
        {
            f_SpeedPassive.SetActive(false);
        }

        if(f_passiveHabilityTimer3 <= 3)
        {
            f_DelayPassive.SetActive(true);
        }
        else
        {
            f_DelayPassive.SetActive(false);
        }


    }

    public void ActiveLivePLusFeedback()
    {
        f_passiveHabilityTimer1 = 0;
    }
    public void ActiveSpeedPLusFeedback()
    {
        f_passiveHabilityTimer2 = 0;
    }
    public void ActiveDelayPLusFeedback()
    {
        f_passiveHabilityTimer3 = 0;
    }

    void SpecialHabilityFeedback()
    {
        //TIMERS
        f_specialHabilityTimer1 += 1 * Time.deltaTime;
        f_specialHabilityTimer2 += 1 * Time.deltaTime;
        f_specialHabilityTimer3 += 1 * Time.deltaTime;
        f_specialHabilityTimer4 += 1 * Time.deltaTime;
        f_specialHabilityTimer5 += 1 * Time.deltaTime;
        //----

        if(f_specialHabilityTimer1 <= 3)
        {
            f_SuperParry.SetActive(true);
        }
        else
        {
            f_SuperParry.SetActive(false);
        }

        if(f_specialHabilityTimer2 <= 3)
        {
            f_Invencible.SetActive(true);
        }
        else
        {
            f_Invencible.SetActive(false);
        }

        if(f_specialHabilityTimer3 <= 3)
        {
            f_QuadShoot.SetActive(true);
        }
        else
        {
            f_QuadShoot.SetActive(false);
        }

         if(f_specialHabilityTimer4 <= 3)
        {
            f_Hunter.SetActive(true);
        }
        else
        {
            f_Hunter.SetActive(false);
        }

         if(f_specialHabilityTimer5 <= 3)
        {
            f_SuperKill.SetActive(true);
        }
        else
        {
            f_SuperKill.SetActive(false);
        }
    }

    public void ActiveSuperParryFeedback()
    {
        f_specialHabilityTimer1 = 0;
    }
    public void ActiveInvencibleFeedback()
    {
        f_specialHabilityTimer2 = 0;
    }
    public void ActiveQuadShootFeedback()
    {
        f_specialHabilityTimer3 = 0;
    }
    public void ActiveHunterFeedback()
    {
        f_specialHabilityTimer4 = 0;
    }
    public void ActiveSuperKillFeedback()
    {
        f_specialHabilityTimer5 = 0;
    }

    void FinalScreenLogic()
    {
        if(BlackBoardPlayer.actualLevel == 10)
        {
            finalScreen.SetActive(true);
        }
        else
        {
            finalScreen.SetActive(false);
        }
    }

}
