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

    }

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------MOVMENT---------------------------------------------------
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        rb2d.MovePosition(rb2d.position + movment * BlackBoardPlayer.characterSpeed * Time.fixedDeltaTime);

        //-----------------------------------------------

        //------------------------------------------------SHOOT------------------------------------------------------
        ShootController();

        //------------------------------------------------
        ParryController();

        //------------------------------------------------PARRY------------------------------------------------------

    }

    //SPAWN THE BASIC BULLET
    void Shoot(bool shootInXAxe, bool isVelocityPositive)
    {
        s_timer = s_timer +1 * Time.deltaTime;

        if(s_timer >= BlackBoardPlayer.delayTimeToShoot)
        {
            if (shootInXAxe)
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isVelocityPositive)
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);
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
            Shoot(true, true);
        }
        else if (Input.GetKey(KeyCode.DownArrow) )
        {
            Shoot(true, false);  
        }
        else if (Input.GetKey(KeyCode.RightArrow) )
        {
            Shoot(false, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) )
        {
            Shoot(false, false);
        }

       
       
    }
    
    //CONTROLS OF PARRY
    void ParryController()
    {
      if(Input.GetKey(KeyCode.Space))
      {
            Parry();
      }
      if (Input.GetKeyUp(KeyCode.Space))
      {
            BlackBoardPlayer.p_Collider.gameObject.SetActive(false);
            p_timer = 0;
      }
    }

    //PARRY
    void Parry()
    {
        p_timer = p_timer +1 * Time.deltaTime;

        if(p_timer<= BlackBoardPlayer.timeOfParry)
        {
            BlackBoardPlayer.p_Collider.gameObject.SetActive(true);
        }
        else
        {
            BlackBoardPlayer.p_Collider.gameObject.SetActive(false);
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
