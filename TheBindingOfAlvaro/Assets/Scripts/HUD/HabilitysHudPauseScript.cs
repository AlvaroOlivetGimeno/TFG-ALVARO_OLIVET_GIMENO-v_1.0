using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitysHudPauseScript : MonoBehaviour
{
    [Header("TYPE OF HABILITY")]
    public float habilityType; //1.Active 2.Special

    [Header("ACTIVE HABILITY's PREFABS")]
    public GameObject dobleTir;
    public GameObject tirMultiple;
    public GameObject superTir;
    public GameObject tirCongelant;
    public GameObject minimum;
    public GameObject maximum;

    [Header("SPECIAL HABILITY's PREFABS")]
    public GameObject invulnerabilitat;
    public GameObject totalParry;
    public GameObject tirQuadruple;
    public GameObject depredador;
    public GameObject superKill;
    

    //othervariables
    GameObject blackBoardPlayer;

    void Start()
    {
        blackBoardPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HabilityHUDController();
    }

    //Hability Controller
    void HabilityHUDController()
    {
        switch(habilityType)
        {
            case 1: 
            switch( blackBoardPlayer.GetComponent<ProtoBLACKBOARD_Player>().habilityType)
            {
                case 0: Case0AH(); break;
                case 1: Case1AH(); break;
                case 2: Case2AH(); break;
                case 3: Case3AH(); break;
                case 4: Case4AH(); break;
                case 5: Case5AH(); break;
                case 6: Case6AH(); break;
            }
            break;

            case 2: 
            switch( blackBoardPlayer.GetComponent<ProtoBLACKBOARD_Player>().specialHabilityCatcth)
            {
                case 0: Case0SH(); break;
                case 1: Case1SH(); break;
                case 2: Case2SH(); break;
                case 3: Case3SH(); break;
                case 4: Case4SH(); break;
                case 5: Case5SH(); break;
            }
            break;

        }

        //ACTIVE CASES
        void Case0AH()
        {
            dobleTir.SetActive(false);
            tirMultiple.SetActive(false);
            superTir.SetActive(false);
            tirCongelant.SetActive(false);
            minimum.SetActive(false);
            maximum.SetActive(false);
        }
        void Case1AH()
        {
            dobleTir.SetActive(true);
            tirMultiple.SetActive(false);
            superTir.SetActive(false);
            tirCongelant.SetActive(false);
            minimum.SetActive(false);
            maximum.SetActive(false);
        }
        void Case2AH()
            {
                dobleTir.SetActive(false);
                tirMultiple.SetActive(true);
                superTir.SetActive(false);
                tirCongelant.SetActive(false);
                minimum.SetActive(false);
                maximum.SetActive(false);
            }
        void Case3AH()
        {
            dobleTir.SetActive(false);
            tirMultiple.SetActive(false);
            superTir.SetActive(true);
            tirCongelant.SetActive(false);
            minimum.SetActive(false);
            maximum.SetActive(false);
        }
        void Case4AH()
        {
            dobleTir.SetActive(false);
            tirMultiple.SetActive(false);
            superTir.SetActive(false);
            tirCongelant.SetActive(true);
            minimum.SetActive(false);
            maximum.SetActive(false);
        }
        void Case5AH()
        {
            dobleTir.SetActive(false);
            tirMultiple.SetActive(false);
            superTir.SetActive(false);
            tirCongelant.SetActive(false);
            minimum.SetActive(true);
            maximum.SetActive(false);
        }
        void Case6AH()
        {
            dobleTir.SetActive(false);
            tirMultiple.SetActive(false);
            superTir.SetActive(false);
            tirCongelant.SetActive(false);
            minimum.SetActive(false);
            maximum.SetActive(true);
        }

        //SPECIAL CASES
        void Case0SH()
        {
            invulnerabilitat.SetActive(false);
            totalParry.SetActive(false);
            tirQuadruple.SetActive(false);
            depredador.SetActive(false);
            superKill.SetActive(false);
        }
        void Case1SH()
        {
            invulnerabilitat.SetActive(true);
            totalParry.SetActive(false);
            tirQuadruple.SetActive(false);
            depredador.SetActive(false);
            superKill.SetActive(false);
        }
        void Case2SH()
        {
            invulnerabilitat.SetActive(false);
            totalParry.SetActive(true);
            tirQuadruple.SetActive(false);
            depredador.SetActive(false);
            superKill.SetActive(false);
        }
        void Case3SH()
        {
            invulnerabilitat.SetActive(false);
            totalParry.SetActive(false);
            tirQuadruple.SetActive(true);
            depredador.SetActive(false);
            superKill.SetActive(false);
        }
        void Case4SH()
        {
            invulnerabilitat.SetActive(false);
            totalParry.SetActive(false);
            tirQuadruple.SetActive(false);
            depredador.SetActive(true);
            superKill.SetActive(false);
        }
        void Case5SH()
        {
            invulnerabilitat.SetActive(false);
            totalParry.SetActive(false);
            tirQuadruple.SetActive(false);
            depredador.SetActive(false);
            superKill.SetActive(true);
        }
    
    
    
    
    
    }
}
