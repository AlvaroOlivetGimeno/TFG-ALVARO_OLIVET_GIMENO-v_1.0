using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("I HAVE CONTACT WITH A WALL??")]
    public bool wallContact;

    [Header("I HAVE CONTACT WITH A WALL??")]
    public bool playerContact;

    [Header("WHAT POS. I AM??")]
    public float relativePos; //1.Up  2.Down  3.Right  4.Left

    [Header("IM ON TE LIST?")]
    public bool addedToFathersList;

    [Header("EXPULSED?")]

    public bool expulsed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyMe();
    }

    public void DestroyMe()
    {
        if(addedToFathersList && expulsed)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wallContact = true;
        }
        if (other.gameObject.tag == "Player")
        {
            playerContact = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            wallContact = true;
        }
    }
}
