using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movment;
    public float speed;

    public int direction;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {
        //-------------------------MOVE------------------------------------
        Move();
        //-----------


    }

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
        //-----------------------------------------------------------------------------------




    }
}
