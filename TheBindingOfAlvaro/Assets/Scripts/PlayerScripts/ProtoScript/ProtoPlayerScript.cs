using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoPlayerScript : MonoBehaviour
{
    //COMPONENTES QUE NECESITA PLAYER
    ProtoBLACKBOARD_Player pBlackBoardPlayer;
    Rigidbody2D rb2d;

    GameObject mCamera;

    Vector2 movment;

    Vector3 vPos;
    void Start()
    {
        pBlackBoardPlayer = GetComponent<ProtoBLACKBOARD_Player>();
        rb2d = GetComponent<Rigidbody2D>();
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------MOVMENT---------------------------------------------------
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        rb2d.MovePosition(rb2d.position + movment * pBlackBoardPlayer.characterSpeed * Time.fixedDeltaTime);

        //-----------------------------------------------
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "CamaraPoint")
        {
            Debug.Log("CONTACTO CON UNA ROOM");
            mCamera.transform.position = other.gameObject.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.tag == "CamaraPoint")
        {
            Debug.Log("CONTACTO CON UNA ROOM");
            vPos = new Vector3 (other.transform.position.x, other.transform.position.y, -10);
            mCamera.transform.position = vPos;
        } 
    }
    
}
