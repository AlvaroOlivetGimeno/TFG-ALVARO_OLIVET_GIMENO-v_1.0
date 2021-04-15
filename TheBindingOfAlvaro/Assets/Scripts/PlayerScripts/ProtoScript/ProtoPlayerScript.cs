using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    //COMPONENTES QUE NECESITA PLAYER
    ProtoBLACKBOARD_Player BlackBoardPlayer;
    Rigidbody2D rb2d;

   

    Vector2 movment;

    Vector3 vPos;
    public int timer = 0;
    public  bool shootting;
    void Start()
    {
        BlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        rb2d = GetComponent<Rigidbody2D>();
        
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
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.tag == "CamaraPoint")
       {
            //Debug.Log("CONTACTO CON UNA ROOM");
            vPos = new Vector3 (other.transform.position.x, other.transform.position.y, -10);
            BlackBoardPlayer.mCamera.transform.position = vPos;

        } 
    }
    void Shoot(bool shootInXAxe, bool isVelocityPositive)
    {
        timer++;

        if(timer >= BlackBoardPlayer.delayTimeToShoot)
        {
            if (shootInXAxe)
            {
                if (isVelocityPositive)
                {
                    //
                    
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Up.transform.position, Quaternion.identity);
                }
                else
                {
                    //BlackBoardPlayer.b_Bullet.direction = 2;
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Down.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isVelocityPositive)
                {
                    //BlackBoardPlayer.b_Bullet.direction = 3;
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Right.transform.position, Quaternion.identity);
                }
                else
                {
                    //BlackBoardPlayer.b_Bullet.direction = 4;
                    Instantiate(BlackBoardPlayer.Bullet, BlackBoardPlayer.Left.transform.position, Quaternion.identity);
                }
            }
            timer = 0;
        }

    }



    void ShootController()
    {

        if (Input.GetKey(KeyCode.UpArrow) )
        {
            //Debug.Log("UP");
            Shoot(true, true);
            

        }
        else if (Input.GetKey(KeyCode.DownArrow) )
        {
            //Debug.Log("DOWN");
            Shoot(true, false);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow) )
        {
            //Debug.Log("Right");
            Shoot(false, true);
            shootting = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) )
        {
            //Debug.Log("LEft");
            Shoot(false, false);
            shootting = true;
        }

       
       
    }

}
