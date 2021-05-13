using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    //COMPONENTES QUE NECESITA PLAYER
    ProtoBLACKBOARD_Player BlackBoardPlayer;
    HUD_MANAGER hudManager;
    Rigidbody2D rb2d;
    
   
   
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

    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        hudManager = GetComponent<HUD_MANAGER>();
        rb2d = GetComponent<Rigidbody2D>();

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
        specialHabilityTimer = 0;
        oneTime = false;
    }

    //INVULNERABILITAT SPECIAL STATE
    void InvencibleState()
    {
        specialHabilityTimer += 1 * Time.deltaTime;
        invencible = true;

        if( specialHabilityTimer >= BlackBoardPlayer.timeSpecialHability)
        {
            invencible = false;
            BlackBoardPlayer.specialStateType = 0;
        }
    }

    //SUPER PARRY SPECIAL STATE
    void SuperParry()
    {
        specialHabilityTimer += 1 * Time.deltaTime;
        superParry = true;

        if (specialHabilityTimer >= BlackBoardPlayer.timeSpecialHability)
        {
            superParry = false;
            BlackBoardPlayer.specialStateType = 0;
        }
    }

    //QUADRUPLE TIR
    void QuadShoot()
    {
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
        }

    }

    //DEPREDADOR
    void HunterState()
    {
        if(BlackBoardPlayer.characterLife >= 2)
        {
            specialHabilityTimer += 1 * Time.deltaTime;
            hunterState = true;

            if(!oneTime)
            {
                BlackBoardPlayer.characterLife -= 1;
                oneTime = true;
            }

            if (specialHabilityTimer >= (BlackBoardPlayer.timeSpecialHability))
            {
                hunterState = false;
                BlackBoardPlayer.specialStateType = 0;
            }
        } 
    }

    //SUPER KILL
    void SuperKill()
    {
        
        specialHabilityTimer += 1 * Time.deltaTime;
        if(BlackBoardPlayer.characterLife >= 3)
        {
            
            BlackBoardPlayer.sK_Collider.transform.position = this.gameObject.transform.position;
            BlackBoardPlayer.sK_Collider.gameObject.SetActive(true);  
        }

        if (!oneTime)
        {
            BlackBoardPlayer.characterLife -= 2;
            oneTime = true;
        }

        if (specialHabilityTimer >= 1)
        {      
            BlackBoardPlayer.sK_Collider.gameObject.SetActive(false);
            BlackBoardPlayer.specialStateType = 0;
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
        if (Input.GetKey(KeyCode.E))
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
            Pause();

        }
    }

    //SUM ROOMS I WATCHED
    public void NewRoomSeen()
    {
        //ESTA A CAMARA POINT!

        BlackBoardPlayer.numOfRoomsSeenInTheLevel += 1;
    }


    //REST LIFE LOGIC
    public void RestLife()
    {
        if(lifeTimer>= 2)
        {
            StartCoroutine(BlackBoardPlayer.mCamera.GetComponent<CameraShake>().Shake(BlackBoardPlayer.duration, BlackBoardPlayer.magnitude));
            BlackBoardPlayer.characterLife -= 1;
            lifeTimer = 0;
        }
    }

    //SUM LIFE LOGIC
    public void SumLife()
    {
        if(lifeTimer>= 1.5f)
        {
            BlackBoardPlayer.characterLife += 1;
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
                    case 1: speedSum = speedSum + 0.3f; loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                    case 2: delaySum = delaySum - 0.05f; loadingHability = true; loadingHabilityTimer = 0; Destroy(other.gameObject); break;
                    case 3: BlackBoardPlayer.characterLife = BlackBoardPlayer.characterLife + 1f; 
                            BlackBoardPlayer.characterSpaceLife = BlackBoardPlayer.characterSpaceLife + 1f; 
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

            //SPECIAL ENEMYS
            if (other.gameObject.tag == "SpecialCollider")
            {
                //invertControls = true;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        
        //--------------------------------------ENEMYS-----------------------------------------------
        if(other.gameObject.tag == "Enemy")
        {
            if (!hunterState) 
            {
                RestLife();
            }
            else
            {
                other.gameObject.GetComponent<EnemyShootersScript>().life = 0;
            }
        }
    }
}
