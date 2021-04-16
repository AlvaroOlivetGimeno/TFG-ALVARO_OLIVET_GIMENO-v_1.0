using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    //COMPONENTES QUE NECESITA PLAYER
    ProtoBLACKBOARD_Player BlackBoardPlayer;
    Rigidbody2D rb2d;

   
    //VARIABLE PEL MOVIMENT
    Vector2 movment;
    float speed;
    float delayShoot;

    //VARIABLE PER LA POSICIÓ DE LA CAMARA
    Vector3 vPos;

    //TIMERS
    float s_timer = 100;
    float p_timer = 0;
    
    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        rb2d = GetComponent<Rigidbody2D>();

        //Desactivar el Parry
        BlackBoardPlayer.p_Collider.gameObject.SetActive(false);

        //Valor a la speed
        speed = BlackBoardPlayer.characterSpeed;

        //valor al delay
        delayShoot = BlackBoardPlayer.delayTimeToShoot;
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

        //-----------------------------------------------
       
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
        if (Input.GetKey(KeyCode.UpArrow) )
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
        else if (Input.GetKey(KeyCode.DownArrow) )
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
        else if (Input.GetKey(KeyCode.RightArrow) )
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
        else if (Input.GetKey(KeyCode.LeftArrow) )
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
                    //...
            }
        }
    }
    
    //DEFAULT STATE
    void DefaultState()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        speed = BlackBoardPlayer.characterSpeed;
        delayShoot = BlackBoardPlayer.delayTimeToShoot;
    }

    //MMINIMUM STATE
    void MinimumState()
    {
        this.transform.localScale = BlackBoardPlayer.minimumScale;
        //speed = BlackBoardPlayer.minimumSpeed;
        //delayShoot = BlackBoardPlayer.minimumDelayTimeToShoot;

        if(speed >= BlackBoardPlayer.characterSpeed || speed == BlackBoardPlayer.maximumSpeed)
        {
            speed = BlackBoardPlayer.minimumSpeed;
        }
        
        if (delayShoot == BlackBoardPlayer.delayTimeToShoot || delayShoot == BlackBoardPlayer.maximumSpeed)
        {
            delayShoot = BlackBoardPlayer.minimumDelayTimeToShoot;
        }
        
    }

    //MAXIMUM STATE
    void MaximumState()
    {
        this.transform.localScale = BlackBoardPlayer.maximumScale;
        delayShoot = BlackBoardPlayer.maximumDelayTimeToShoot;
        //speed = BlackBoardPlayer.maximumSpeed;
       
        if(speed == BlackBoardPlayer.characterSpeed || speed == BlackBoardPlayer.minimumSpeed)
        {
            speed = BlackBoardPlayer.maximumSpeed;
        }
       
       if (delayShoot == BlackBoardPlayer.delayTimeToShoot || delayShoot == BlackBoardPlayer.minimumDelayTimeToShoot)
       {
           delayShoot = BlackBoardPlayer.maximumDelayTimeToShoot;
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
    }


    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CamaraPoint")
        {
            //Debug.Log("CONTACTO CON UNA ROOM");
            vPos = new Vector3(other.transform.position.x, other.transform.position.y, -10);
            BlackBoardPlayer.mCamera.transform.position = vPos;

        }
    }
}
