﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    //COMPONENTES QUE NECESITA PLAYER
    ProtoBLACKBOARD_Player BlackBoardPlayer;
    HUD_MANAGER hudManager;
    Rigidbody2D rb2d;

    SpriteRenderer spriteRenderer;
    
   
   
    //VARIABLE PEL MOVIMENT
    Vector2 movment;

    [Header("AUTOMATIC VARIABLES:")]
    public float speed;
    public float delayShoot;

    //VARIABLE PER LA POSICIÓ DE LA CAMARA
    Vector3 vPos;

    //TIMERS
    float s_timer = 100;
    float p_timer = 0;

    //VARIABLES PER HABILITATS
    float speedSum = 0;
    float delaySum = 0;
    float damageSum = 0;
    bool loadingHability = false;
    float loadingHabilityTimer;
    float specialHabilityTimer;
    bool oneTime;
    bool invencible = false;
    bool superParry = false;
    bool quadShoot = false;
    bool hunterState = false;

    Color actualColor;
    bool saveColorOneTime;
    bool reloadColorOneTime = true;
    

    //VARIABLES PER MOLESTAR (SPECIAL ENEMYS)
    float invertTimer;
    bool oneTimeInvert;
    float screenTimer;

    //PAUSE BOOL
    //public bool activePause = false;

    //VARIABLES PER LA VIDA

    float lifeTimer = 1.5f;
    float coinTimer = 1.5f;
    float cristalTimer = 1.5f;

    //ENEMY TRAIL

    float actualSpeed;
    bool saveSpeedOneTime;

    //FEEDBACK 
  

    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        hudManager = GetComponent<HUD_MANAGER>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Desactivar el Parry
        BlackBoardPlayer.p_Collider.gameObject.SetActive(false);

        //Valor a la speed
        speed = BlackBoardPlayer.characterSpeed;

        //valor al delay
        delayShoot = BlackBoardPlayer.delayTimeToShoot;

        //DesactivatePause
        hudManager.pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------MOVMENT---------------------------------------------------
        Movment();

        //-----------------------------------------------
        
        //------------------------------------------------PARRY------------------------------------------------------
        ParryController();

        //------------------------------------------------

        //------------------------------------------------SHOOT------------------------------------------------------
        ShootController();

        //------------------------------------------------

        //-----------------------------------------------STATES----------------------------------------------------
        StateController();
        SpecialHabilityControls();

        //-----------------------------------------------

        //------------------------------------------------STADISTICS------------------------------------------------
        StadisticsController();

        //-----------------------------------------------

        //-----------------------------------------------LIFE CONTROLLER---------------------------------------------
        LifeController();
        lifeTimer += 1*Time.deltaTime;
        coinTimer += 1*Time.deltaTime; //FOR MONEY
        cristalTimer += 1*Time.deltaTime; //FOR CRISTALS

        //-----------------------------------------------

        //------------------------------------------ANNOYING EFFECTS FROM ENEMYS--------------------------------------
        AnnoyingStatesController();

        //---------------------------------------------

        //-------------------------------------------------PAUSE MENU LOGIC-------------------------------------------
        PauseControlls();

        //---------------------------------------------

        //----------------------------------------------SKIN CONTROLLER------------------------------------------------
        SkinColorController();
        SkinDrawController();

        //------------------------------------------------

        //---------------------------------------------------MAP--------------------------------------------------------
        MapControlls();

        //----------------------------------------------

        //Debug.Log(BlackBoardPlayer.totalEnemysKilled);
    }

    //MOVMENT
    void Movment()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        rb2d.MovePosition(rb2d.position + movment * speed * Time.fixedDeltaTime);
    }

    //PARRY
    void Parry()
    {
        p_timer = p_timer + 1 * Time.deltaTime;

        if (p_timer <= BlackBoardPlayer.timeOfParry)
        {
            BlackBoardPlayer.p_Particles.GetComponent<ParryParticlesSpeed>().play = true;
            BlackBoardPlayer.p_Collider.gameObject.SetActive(true);
        }
        else
        {
            BlackBoardPlayer.p_Collider.gameObject.SetActive(false);
        }

    }

    //CONTROLS OF PARRY
    void ParryController()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Parry();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            BlackBoardPlayer.p_Collider.gameObject.SetActive(false);
            p_timer = 0;
        }
    }

    //SPAWN THE BASIC BULLET
    void BasicShoot(bool shootInXAxe, bool isVelocityPositive, GameObject typeOfBullet)
    {
        s_timer = s_timer +1 * Time.deltaTime;

        if(s_timer >= delayShoot)
        {
            if (shootInXAxe)
            {
                if (isVelocityPositive)
                {
                    Instantiate(typeOfBullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(typeOfBullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isVelocityPositive)
                {
                    Instantiate(typeOfBullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(typeOfBullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);
                }
            }
            s_timer = 0;
        }

    }

    //DOBLE SHOOT
    void DobleShoot(bool shootInXAxe,bool isVelocityPositive)
    {
        s_timer = s_timer + 1 * Time.deltaTime;

        if (s_timer >= delayShoot)
        {
            if (shootInXAxe)
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up1.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up2.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down1.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down2.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right1.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right2.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left1.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left2.transform.position, Quaternion.identity);
                }
            }
            s_timer = 0;
        }
    }

    //SIMULTANEOUS SHOOT
    void SimultaneousShoot(bool shootInXAxe, bool isVelocityPositive)
    {
        s_timer = s_timer + 1 * Time.deltaTime;

        if (s_timer >= delayShoot)
        {
            if (shootInXAxe)
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
                }
            }
            s_timer = 0;
        }
    }

    //CONTROLS OF SHOOTING
    void ShootController()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !quadShoot)
        {
            switch (BlackBoardPlayer.habilityType)
            {
                case 0: BasicShoot(true, true, BlackBoardPlayer.Bullet); break;
                case 1: DobleShoot(true, true); break;
                case 2: SimultaneousShoot(true, true); break;
                case 3: BasicShoot(true, true, BlackBoardPlayer.superiorBullet); break;
                case 4: BasicShoot(true, true, BlackBoardPlayer.freezeBullet); break;
                case 5: BasicShoot(true, true, BlackBoardPlayer.minimumBullet); break;
                case 6: BasicShoot(true, true, BlackBoardPlayer.maximumBullet); break;
                    //...
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !quadShoot)
        {
            switch (BlackBoardPlayer.habilityType)
            {
                case 0: BasicShoot(true, false, BlackBoardPlayer.Bullet); break;
                case 1: DobleShoot(true, false); break;
                case 2: SimultaneousShoot(true, false); break;
                case 3: BasicShoot(true, false, BlackBoardPlayer.superiorBullet); break;
                case 4: BasicShoot(true, false, BlackBoardPlayer.freezeBullet); break;
                case 5: BasicShoot(true, false, BlackBoardPlayer.minimumBullet); break;
                case 6: BasicShoot(true, false, BlackBoardPlayer.maximumBullet); break;
                    //...
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !quadShoot)
        {
            switch (BlackBoardPlayer.habilityType)
            {
                case 0: BasicShoot(false, true, BlackBoardPlayer.Bullet); break;
                case 1: DobleShoot(false, true); break;
                case 2: SimultaneousShoot(false, true); break;
                case 3: BasicShoot(false, true, BlackBoardPlayer.superiorBullet); break;
                case 4: BasicShoot(false, true, BlackBoardPlayer.freezeBullet); break;
                case 5: BasicShoot(false, true, BlackBoardPlayer.minimumBullet); break;
                case 6: BasicShoot(false, true, BlackBoardPlayer.maximumBullet); break;
                    //...
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !quadShoot)
        {
            switch (BlackBoardPlayer.habilityType)
            {
                case 0: BasicShoot(false, false, BlackBoardPlayer.Bullet); break;
                case 1: DobleShoot(false, false); break;
                case 2: SimultaneousShoot(false, false); break;
                case 3: BasicShoot(false, false, BlackBoardPlayer.superiorBullet); break;
                case 4: BasicShoot(false, false, BlackBoardPlayer.freezeBullet); break;
                case 5: BasicShoot(false, false, BlackBoardPlayer.minimumBullet); break;
                case 6: BasicShoot(false, false, BlackBoardPlayer.maximumBullet); break;
                case 7: QuadShoot(); break;
                    //...
            }
        }
    }
    
    //DEFAULT STATE
    void DefaultState()
    {
        this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        speed = BlackBoardPlayer.characterSpeed;
        delayShoot = BlackBoardPlayer.delayTimeToShoot;
    }

    //MMINIMUM STATE
    void MinimumState()
    {
        this.transform.localScale = BlackBoardPlayer.minimumScale;
        speed = BlackBoardPlayer.minimumSpeed;
        delayShoot = BlackBoardPlayer.minimumDelayTimeToShoot;
    }

    //MAXIMUM STATE
    void MaximumState()
    {
        this.transform.localScale = BlackBoardPlayer.maximumScale;
        delayShoot = BlackBoardPlayer.maximumDelayTimeToShoot;
        speed = BlackBoardPlayer.maximumSpeed;

    }

    //DEFAULT FOR SPECIAL
    void WaitingForNextSpecialHability()
    {
        BlackBoardPlayer.SpecialHabilityIsActive = false;
        specialHabilityTimer = 0;
        oneTime = false;
        

        if(BlackBoardPlayer.enemysKillToReloadSpecialHability >= 10)
        {
            BlackBoardPlayer.loadingSpecialHability = true;
        }
    }

    //INVULNERABILITAT SPECIAL STATE
    void InvencibleState()
    {
        BlackBoardPlayer.SpecialHabilityIsActive = true;
        invencible = true;

        

        spriteRenderer.color = BlackBoardPlayer.inbulnerabilityColor;
        specialHabilityTimer += 1 * Time.deltaTime;
        

        if( specialHabilityTimer >= BlackBoardPlayer.timeSpecialHability)
        {
            invencible = false;
            BlackBoardPlayer.specialStateType = 0;
            BlackBoardPlayer.enemysKillToReloadSpecialHability = 0;
            BlackBoardPlayer.loadingSpecialHability = false;
        }
    }

    //SUPER PARRY SPECIAL STATE
    void SuperParry()
    {
        BlackBoardPlayer.SpecialHabilityIsActive = true;
        superParry = true;
        
       
        spriteRenderer.color = BlackBoardPlayer.superParryColor;

        specialHabilityTimer += 1 * Time.deltaTime;
        

        if (specialHabilityTimer >= BlackBoardPlayer.timeSpecialHability)
        {
            superParry = false;
            BlackBoardPlayer.specialStateType = 0;
            BlackBoardPlayer.enemysKillToReloadSpecialHability = 0;
            BlackBoardPlayer.loadingSpecialHability = false;
        }
    }

    //QUADRUPLE TIR
    void QuadShoot()
    {
        BlackBoardPlayer.SpecialHabilityIsActive = true;
    
        specialHabilityTimer += 1 * Time.deltaTime;
        quadShoot = true;

        Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
        Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
        Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
        Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);

        if (specialHabilityTimer >= (BlackBoardPlayer.timeSpecialHability/2))
        {
            quadShoot = false;
            BlackBoardPlayer.specialStateType = 0;
            BlackBoardPlayer.enemysKillToReloadSpecialHability = 0;
            BlackBoardPlayer.loadingSpecialHability = false;
        }

    }

    //DEPREDADOR
    void HunterState()
    {
        if(BlackBoardPlayer.characterLife != 1)
        {
            BlackBoardPlayer.SpecialHabilityIsActive = true;
            hunterState = true;

            
            spriteRenderer.color = BlackBoardPlayer.hunterColor;

            specialHabilityTimer += 1 * Time.deltaTime;
            

            if(!oneTime)
            {
                RestLife();
                oneTime = true;
            }

            if (specialHabilityTimer >= (BlackBoardPlayer.timeSpecialHability))
            {
                hunterState = false;
                BlackBoardPlayer.specialStateType = 0;
                BlackBoardPlayer.enemysKillToReloadSpecialHability = 0;
                BlackBoardPlayer.loadingSpecialHability = false;
            }
        } 
    }

    //SUPER KILL
    void SuperKill()
    {
        if(BlackBoardPlayer.characterLife != 1)
        {
            BlackBoardPlayer.SpecialHabilityIsActive = true;

            specialHabilityTimer += 1 * Time.deltaTime;
           
            BlackBoardPlayer.sK_Collider.transform.position = this.gameObject.transform.position;
            BlackBoardPlayer.sK_Collider.gameObject.SetActive(true);  

            if (!oneTime)
            {
                RestLife();
                Instantiate(BlackBoardPlayer.superKill_Particles, this.transform.position, Quaternion.identity);
                oneTime = true;
            }

            if (specialHabilityTimer >= 0.5)
            {      
                BlackBoardPlayer.sK_Collider.gameObject.SetActive(false);
                BlackBoardPlayer.specialStateType = 0;
                BlackBoardPlayer.enemysKillToReloadSpecialHability = 0;
                BlackBoardPlayer.loadingSpecialHability = false;
            }
        }
         
    }

    //CONTROL OF THE DIFERENT STATES OF  PLAYER
    void StateController()
    {
        switch (BlackBoardPlayer.stateType)
        {
            case 0: DefaultState(); break;
            case 1: MinimumState(); break;
            case 2: MaximumState(); break;
        }

        switch(BlackBoardPlayer.specialStateType)
        {
            case 0: WaitingForNextSpecialHability(); break;
            case 1: InvencibleState(); break;
            case 2: SuperParry(); break;
            case 3: QuadShoot(); break;
            case 4: HunterState(); break;
            case 5: SuperKill(); break;
        }
        
    }

    //STATISTICS CONTROLLER
    void StadisticsController()
    {
        //VELOCIDAD
        speed = speed + speedSum;
        if (speed >= BlackBoardPlayer.MAXSpeed)
        {
            speed = BlackBoardPlayer.MAXSpeed;
        }

        //DELAY
        delayShoot = delayShoot + delaySum;
        if (delayShoot <= BlackBoardPlayer.MINIMDelay)
        {
            delayShoot = BlackBoardPlayer.MINIMDelay;
        }

        //LOADING TIME BETWEEN HABILITIES
        if (loadingHability)
        {
            loadingHabilityTimer += 1 * Time.deltaTime;

            if(loadingHabilityTimer >= 2)
            {
                loadingHability = false;

            }
        }

        //LIFE
        if(BlackBoardPlayer.characterLife >= BlackBoardPlayer.MAXLife)
        {
            BlackBoardPlayer.characterLife = BlackBoardPlayer.MAXLife;
        }

        
        

    }

    //SPECIAL HABILITY CONTROLS
    void SpecialHabilityControls()
    {
        if (Input.GetKey(KeyCode.E) && BlackBoardPlayer.loadingSpecialHability)
        {
            BlackBoardPlayer.specialStateType = BlackBoardPlayer.specialHabilityCatcth;
        }
    }

    //LifeController
    void LifeController()
    {
        if(BlackBoardPlayer.characterLife <= 0)
        {
            
        }
    }

    //Invert Controls
    void InvertControls()
    {
        if(BlackBoardPlayer.invertControls)
        {
            if(!oneTimeInvert)
            {
                BlackBoardPlayer.characterSpeed *= -1;
                oneTimeInvert = true;
            }
            
            invertTimer += 1 * Time.deltaTime;

            if(invertTimer>= BlackBoardPlayer.timeEffectSpecialEnemysInvert)
            {
                BlackBoardPlayer.characterSpeed *= -1;
                invertTimer = 0;
                oneTimeInvert = false;
                BlackBoardPlayer.invertControls = false;
                
            }
        }
    }

    //BLACK SCREEN
    void BlackScreen()
    {
        if (BlackBoardPlayer.blackScreen)
        {
            hudManager.BlackScreen.gameObject.SetActive(true);

            screenTimer += 1 * Time.deltaTime;

            if (screenTimer >= BlackBoardPlayer.timeEffectSpecialEnemysSquid)
            {
                hudManager.BlackScreen.gameObject.SetActive(false);
                screenTimer = 0;
                BlackBoardPlayer.blackScreen = false;

            }
        }
    }

    //ANNOYING STATES
    void AnnoyingStatesController()
    {
        //INVERT CONTROLS-------
        InvertControls();

        //----------------------

        //BLACK SCREEN-------
        BlackScreen();

        //----------------------
    }
    
    //PAUSE
    void Pause()
    {
        if(!BlackBoardPlayer.activePause)
        {
            Time.timeScale = 0f;
            BlackBoardPlayer.activePause = true;
            hudManager.pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            BlackBoardPlayer.activePause = false;
            hudManager.pauseMenu.gameObject.SetActive(false);
        }
    }
    

    //PAUSE LOGIC
    void PauseControlls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!BlackBoardPlayer.activeLoading)
            {
                Pause();
            }
            

        }
    }

    //SUM ROOMS I WATCHED
    public void NewRoomSeen()
    {
        //ESTA A CAMARA POINT!

        BlackBoardPlayer.numOfRoomsSeenInTheLevel += 1;
    }

    //SKIN COLOR CONTROLLER
    public void SkinColorController()
    {
        if(!BlackBoardPlayer.SpecialHabilityIsActive)
        {
            switch(BlackBoardPlayer.skinColorState)
            {
                case 0: spriteRenderer.color = BlackBoardPlayer.green; break;
                case 1: spriteRenderer.color = BlackBoardPlayer.blue; break;
                case 2: spriteRenderer.color = BlackBoardPlayer.yellow; break;
                case 3: spriteRenderer.color = BlackBoardPlayer.white; break;
                case 4: spriteRenderer.color = BlackBoardPlayer.purple; break;
            
            }
        }
        
    }

     //SKIN DRAW CONTROLLER
    public void SkinDrawController()
    {
        switch(BlackBoardPlayer.skinDrawState)
        {
            case 0: this.transform.GetChild(3).GetComponent<SkinDrawScript>().spriteRenderer.sprite = BlackBoardPlayer.ojoChungo; break;
            case 1: this.transform.GetChild(3).GetComponent<SkinDrawScript>().spriteRenderer.sprite = BlackBoardPlayer.tattuEye1; break;
            case 2: this.transform.GetChild(3).GetComponent<SkinDrawScript>().spriteRenderer.sprite = BlackBoardPlayer.tattuEye2; break;
            case 3: this.transform.GetChild(3).GetComponent<SkinDrawScript>().spriteRenderer.sprite = BlackBoardPlayer.tattuEye3; break;
            case 4: this.transform.GetChild(3).GetComponent<SkinDrawScript>().spriteRenderer.sprite = BlackBoardPlayer.tattuEye4; break;
            
        }
    }

    //REST LIFE LOGIC
    public void RestLife()
    {
        if(!BlackBoardPlayer.activeSuperDamage)
        {
            if(lifeTimer>= 2)
            {
                StartCoroutine(BlackBoardPlayer.mCamera.GetComponent<CameraShake>().Shake(BlackBoardPlayer.duration, BlackBoardPlayer.magnitude));
                BlackBoardPlayer.characterLife -= 0.5f;
                lifeTimer = 0;
            }
        }
        else
        {
            if(lifeTimer>= 2)
            {
                if(BlackBoardPlayer.characterLife != 0.5f)
                {
                    StartCoroutine(BlackBoardPlayer.mCamera.GetComponent<CameraShake>().Shake(BlackBoardPlayer.duration, BlackBoardPlayer.magnitude));
                    BlackBoardPlayer.characterLife -= 1f;
                    lifeTimer = 0;
                }
                else
                {
                    StartCoroutine(BlackBoardPlayer.mCamera.GetComponent<CameraShake>().Shake(BlackBoardPlayer.duration, BlackBoardPlayer.magnitude));
                    BlackBoardPlayer.characterLife -= 0.5f;
                    lifeTimer = 0;
                }
                
            }
        }
        
    }

    //SUM LIFE LOGIC
    public void SumLife()
    {
        if(lifeTimer>= 1.5f)
        {
            BlackBoardPlayer.characterLife += 0.5f;
            lifeTimer = 0;
        }
    }
    
    //SUM COIN LOGIC
    public void SumCoin()
    {
        if(coinTimer>= 1.5f)
        {
            BlackBoardPlayer.characterMoney += 1;
            coinTimer = 0;
        }
    }

     //SUM CRISTAL LOGIC
    public void SumCristal()
    {
        if(cristalTimer>= 1.5f)
        {
            BlackBoardPlayer.characterCristals += 1;
            cristalTimer = 0;
        }
    }

    //MAP CONTROLLS
    void MapControlls()
    {
        if (Input.GetKeyDown(KeyCode.M) && BlackBoardPlayer.activeMapMecanic)
        {
            Map();
        }

    }

    //MAP LOGIC
    void Map()
    {
        if(!BlackBoardPlayer.cameraMapIsActive)
        {
            BlackBoardPlayer.cameraMapIsActive = true;
            BlackBoardPlayer.cameraMap.SetActive(true);
        }
        else
        {
            BlackBoardPlayer.cameraMapIsActive = false;
            BlackBoardPlayer.cameraMap.SetActive(false);
        }
    }


    //COLLISIONS TRIGGER
    void OnTriggerEnter2D(Collider2D other)
    {
        //-------------------------------------------PER LA CAMARA-----------------------------------------------------
        if (other.gameObject.tag == "CamaraPoint")
        {
            //Debug.Log("CONTACTO CON UNA ROOM");
            vPos = new Vector3(other.transform.position.x, other.transform.position.y, -10);
            BlackBoardPlayer.mCamera.transform.position = vPos;
        }
        //--------------------------------------------------------------------------------------------------------------
        
        //--------------------------------------------HABILITATS--------------------------------------------------------

        //ACTIVES
        if (other.gameObject.tag == "ActiveHability")
        {
            BlackBoardPlayer.habilityType = other.GetComponent<ActiveHabilityScript>().habilityType;
            BlackBoardPlayer.stateType = other.GetComponent<ActiveHabilityScript>().stateType;


            Destroy(other.gameObject);
        }

        //PASIVES
        //1.Velocitat 2.Delay 3.Armadura 4.Dolor Inflingit
        if (other.gameObject.tag == "PassiveHability")
        {
            if(!loadingHability)
            {
                switch (other.GetComponent<PassiveHabilityScript>().estadisticType)
                {
                    case 1: speedSum = speedSum + 0.5f; loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                    case 2: delaySum = delaySum - 0.05f; loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                    case 3: SumLife();
                            if(BlackBoardPlayer.characterSpaceLife>= 5)
                            {
                                BlackBoardPlayer.characterSpaceLife = BlackBoardPlayer.characterSpaceLife + 1f; 
                            }  
                            loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                    case 4: damageSum = damageSum + 0.3f; loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                }
            } 
        }

        //SPECIAL
        //1.inbulnerabilitat 2.Tir Quadruple 3.TotalParry 4.Depredador 5.SuperKill
        if (other.gameObject.tag == "SpecialHability")
        {
            //BlackBoardPlayer.specialStateType = other.GetComponent<SpecialHabilityScript>().speciaStateType;
            BlackBoardPlayer.specialHabilityCatcth = other.GetComponent<SpecialHabilityScript>().speciaStateType;
            Destroy(other.gameObject);
        }

        //------------------------------------------------------------------------------------------------------------------------------

        //----------------------------------------------ENEMYS-------------------------------------------------------------------------

        //ENEMY BULLETS
        if(!invencible)
        {
            //TORRETA
            if (other.gameObject.tag == "TorretBullet")
            {
                if(!superParry)
                {   
                    RestLife();
                    Destroy(other.gameObject);
                }
                else
                {
                    other.GetComponent<TorretBullet>().Revote();
                }
                
            }

            //PARRY
            if (other.gameObject.tag == "ParryBullet")
            {
                if (!superParry)
                {
                    other.GetComponent<TorretBullet>().impact = true;
                    RestLife();
                    Destroy(other.gameObject);  
                }
                else
                {
                    other.GetComponent<TorretBullet>().Revote();
                   
                }
            }

            //ENEMY TRAIL
            if (other.gameObject.tag == "EnemyTrail")
            {
               
                if(!saveSpeedOneTime)
                {
                    actualSpeed = BlackBoardPlayer.characterSpeed;
                    saveSpeedOneTime = true;
                }
                
                BlackBoardPlayer.characterSpeed = 2;
            }
            
            //--------------------------------------------------------------------------------------------

            //--------------------------------SPIKE--------------------------------------------------------

            if(other.gameObject.tag == "Spike")
            {
                RestLife();
            }
           
        }
         //--------------------------------LIFE--------------------------------------------------------

            if(other.gameObject.tag =="Life")
            {
                if(BlackBoardPlayer.characterLife < BlackBoardPlayer.characterSpaceLife)
                {
                    SumLife();
                    Destroy(other.gameObject);
                }
            }

            //--------------------------------COIN--------------------------------------------------------
        
            if(other.gameObject.tag =="Coin")
            {
                SumCoin();
                Destroy(other.gameObject);
            }

            //--------------------------------CRISTAL--------------------------------------------------------
        
            if(other.gameObject.tag =="Cristal")
            {
                SumCristal();
                BlackBoardPlayer.feedback.GetComponent<FeedbackHUD>().CristalFounfFeedback();
                Destroy(other.gameObject);
            }

            //--------------------------------SKIN COLOR--------------------------------------------------------

            if(other.gameObject.tag == "SkinColor")
            {
                BlackBoardPlayer.skinColorState = other.GetComponent<SkinColorScript>().typeOfColor;
                Destroy(other.gameObject);
            }

            //--------------------------------SKIN DRAW--------------------------------------------------------

            if(other.gameObject.tag == "SkinDraw")
            {
                BlackBoardPlayer.skinDrawState = other.GetComponent<SkinTattooSccript>().typeOfTattoo;
                Destroy(other.gameObject);
            }

            


            //-------------------------------STAIRS MISSION COL-------------------------------------------------------
        
            if(other.gameObject.tag =="StairsMissionCollider")
            {
                BlackBoardPlayer.contactWithStairs = true;
            }
             if(other.gameObject.tag =="StrangeRoomMissionCollider")
            {
                BlackBoardPlayer.contactWithShopOrSpecialRoom = true;
            }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        //ENEMY TRAIL
            if (other.gameObject.tag == "EnemyTrail")
            {
               BlackBoardPlayer.characterSpeed = actualSpeed;
               saveSpeedOneTime = false;
            }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        //--------------------------------------ENEMYS-----------------------------------------------
        if(!invencible)
        {
            if(other.gameObject.tag == "Enemy")
            {
                if (!hunterState) 
                {
                    RestLife();
                }
                else
                {
                    
                    Destroy(other.gameObject);
                }
            }   
        }
    }
}
