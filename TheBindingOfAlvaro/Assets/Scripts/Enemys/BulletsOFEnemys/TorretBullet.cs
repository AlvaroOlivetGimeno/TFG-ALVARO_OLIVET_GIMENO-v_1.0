using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("BULLET SPEED:")]
    public float speed;

    [Header("BULLET SPEED:")]
    public float damage;

   

    Rigidbody2D rb2d;
    ProtoPlayerScript target;
    Vector2 moveDirection;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<ProtoPlayerScript>();
        moveDirection = (target.transform.position - this.transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //REBOTE DE PARRY
    public void Revote()
    {
        target = GameObject.FindObjectOfType<ProtoPlayerScript>();
        moveDirection = (this.transform.position - target.transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
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
            Destroy(this.gameObject);
        }
    }
}
