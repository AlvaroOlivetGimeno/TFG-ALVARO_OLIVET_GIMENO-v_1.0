using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoomManager : MonoBehaviour
{
    [Header("ADDED TO PARENT's LIST:")]

    public bool added;
    
    [Header("LIST OF CHILD's")]
    public List<GameObject> lightRoom;
    
    [Header("PLAYER HAS CONTACT WITH US?")]
    public bool contact;

    [Header("TYPE OF LIGHT:")]
    public float typeOfLight; //0.Normal  1.EnemyRoom  2.Shop  3.Special  4.Stairs


    void Start()
    {
        lightRoom.Add(this.transform.GetChild(0).gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {  
        typeOfLight = this.transform.parent.GetComponent<LightRoomController>().typeOfLight;

    }

    

    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
       if(other.gameObject.tag == "Player")
        {
           contact = true;
        }
        
    }
}
