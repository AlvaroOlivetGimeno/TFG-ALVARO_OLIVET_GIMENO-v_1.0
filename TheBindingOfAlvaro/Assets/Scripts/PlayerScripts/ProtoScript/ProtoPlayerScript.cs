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
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.tag == "CamaraPoint")
       {
            Debug.Log("CONTACTO CON UNA ROOM");
            vPos = new Vector3 (other.transform.position.x, other.transform.position.y, -10);
            BlackBoardPlayer.mCamera.transform.position = vPos;

        } 
    }



    void Shoot(float direction)
    {
        
        /*
        
        */
    }

}
