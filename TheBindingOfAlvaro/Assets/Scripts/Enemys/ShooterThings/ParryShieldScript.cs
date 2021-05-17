using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryShieldScript : MonoBehaviour
{
    [Header("CHOOSE TYPE OF ENEMY:")]
    public bool defeated = false;
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
        if(collision.gameObject.tag == "ParryBullet")
        {
            if(collision.GetComponent<TorretBullet>().rebote)
            {
                defeated = true;
            }
        }
    }
}
