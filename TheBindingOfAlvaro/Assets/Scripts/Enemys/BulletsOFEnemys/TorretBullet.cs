using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("BULLET TYPE:")]
    public float bulletType = 0;
    float direction;
    float numOfBounces;
    bool oneTime;

    [Header("BULLET SPEED:")]
    public float speed;

    [Header("BULLET SPEED:")]
    public float damage;

    [Header("THIS BULLET FREEZE?")]
    public bool freeze;

    [Header("NO TOCAR:")]

    public bool impact = false;
    public bool rebote = false;

    

    Rigidbody2D rb2d;
    
    ProtoPlayerScript target;
    Vector2 moveDirection;
    bool shooted;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        target = GameObject.FindObjectOfType<ProtoPlayerScript>();
        moveDirection = (target.transform.position - this.transform.position).normalized * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        ShottingController();

    }

    //Basic Shoot
    void BasicShoot()
    {
        if (direction == 1 && !shooted)
        {
            rb2d.velocity = transform.up * speed;
            shooted = true;
        }
        else if (direction == 2 && !shooted)
        {
            rb2d.velocity = transform.up * -speed;
            shooted = true;
        }
        else if (direction == 3 && !shooted)
        {
            rb2d.velocity = transform.right * speed;
            shooted = true;
        }
        else if (direction == 4 && !shooted)
        {
            rb2d.velocity = transform.right * -speed;
            shooted = true;
        }
    }

    //BonuceShoot
    void BounceShoot()
    {
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    //IntelligentShoot
    void IntelligentShoot()
    {
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    //ShottingController
    void ShottingController()
    {
        switch(bulletType)
        {
            case 1: BasicShoot(); break;
            case 2: BounceShoot();  break;
            case 3: IntelligentShoot(); break;
        }
    }

    //REBOTE DE PARRY
    public void Revote()
    {
        if(!impact)
        {
            target = GameObject.FindObjectOfType<ProtoPlayerScript>();
            moveDirection = (this.transform.position - target.transform.position).normalized * speed;
            rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
            rebote = true;
        }
        
    }

    //DESTROY ME
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    //COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if(bulletType == 2 && numOfBounces <= 5 && !rebote)
            {
                
                moveDirection = (target.transform.position - this.transform.position).normalized * speed;
                numOfBounces += 1;
               
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
        if(collision.gameObject.tag == "WallCheck")
        {
            
            direction = collision.gameObject.GetComponent<CheckWallPosition>().relativePos;
        }
        if (collision.gameObject.tag == "DeadPoint")
        {
           direction = collision.gameObject.GetComponent<CheckDirection>().direction;
        }
    }
}
