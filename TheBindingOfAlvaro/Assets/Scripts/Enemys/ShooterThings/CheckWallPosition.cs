using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("I HAVE CONTACT WITH A WALL??")]
    public bool wallContact;

    [Header("WHAT POS. I AM??")]
    public float relativePos; //1.Up  2.Down  3.Right  4.Left

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            wallContact = true;
        }
    }
}