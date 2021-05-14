using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movment;
    int direction = 0;


    [Header("BULLET SPEED:")]
    public float speed;

    [Header("BULLEY DAMAGE:")]
    public float damage;

    [Header("TIME TO DIE:")]
    public float timeToDie;

    float timer;




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {

        //-------------------------MOVE------------------------------------
        Move();
       
        //-----------

        //--------------------------DIE BY TIME--------------------------
        CountdownToDeath();

        //-----------------

    }

    //MOVE
    public void Move() //1.UP 2.Down 3.Right 4.Left
    {
            if (direction == 1)
            {
                rb2d.velocity = transform.up * speed;
            }
            else if (direction == 2)
            {
                rb2d.velocity = transform.up * -speed;
            }
            else if (direction == 3)
            {
                rb2d.velocity = transform.right * speed;
            }
            else if (direction == 4)
            {
                rb2d.velocity = transform.right * -speed;
            }
    }

    //SUPER BULLET CONTROLER
    
    //TIME TO DIE
    void CountdownToDeath()
    {
        timer+=1*Time.deltaTime;

        if(timer>= timeToDie)
        {
            DestroyMe();
        }
    }

    //DESTROY FUNCTION
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other)
    {
        //-------------------------COLLISION FOR BEING SHOOTED---------------------------------
        if(other.gameObject.tag == "ShootPointUp")
        {
            direction = 1;
        }
        if (other.gameObject.tag == "ShootPointDown")
        {
            direction = 2;
        }
        if (other.gameObject.tag == "ShootPointRight")
        {
            direction = 3;
        }
        if (other.gameObject.tag == "ShootPointLeft")
        {
            direction = 4;
        }
        //-----------------------------------------------------------------------------------

        //-----------------COLLISION FOR BEING DESTROYED BY WALLS----------------------------
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "ObstacleWall")
        {
            Destroy(this.gameObject);
        }
        //-----------------------------------------------------------------------------------




    }
}
