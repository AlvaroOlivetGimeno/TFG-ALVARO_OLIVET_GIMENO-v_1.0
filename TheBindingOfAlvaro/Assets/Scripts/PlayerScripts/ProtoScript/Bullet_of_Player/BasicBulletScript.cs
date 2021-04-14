using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movment;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {
        
    }

    public void Direction(float direction)
    {
        if (direction == 1)
        {
            //rb2d.MovePosition(rb2d.position + movment * BlackBoardPlayer.characterSpeed * Time.fixedDeltaTime);
        }
        else if (direction == 2)
        {

        }
        else if (direction == 3)
        {

        }
        else
        {

        }
    }
}
