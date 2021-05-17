using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
     

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();
        }
        if (collision.gameObject.tag == "FreezeBullet")
        {
            collision.gameObject.GetComponent<BasicBulletScript>().DestroyMe();    
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        
    }
}
