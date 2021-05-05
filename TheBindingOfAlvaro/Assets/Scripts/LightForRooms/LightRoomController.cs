using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoomController : MonoBehaviour
{
    [Header("LIST OF CHILD's")]
    public List<GameObject> lightRoomManagers;

    [Header("TYPE OF LIGHT:")]
    public float typeOfLight; //0.Normal  1.EnemyRoom  2.Shop  3.Special  4.Stairs
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddChilds();
    }

    //ADD CHILDS
    void AddChilds()
    {
        if(this.transform.childCount != lightRoomManagers.Count)
        {
            for(int i = 0;i <= this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).gameObject.GetComponent<LightRoomManager>().added == false)
                {
                    lightRoomManagers.Add(this.transform.GetChild(i).gameObject);
                    this.transform.GetChild(i).gameObject.GetComponent<LightRoomManager>().added = true;
                } 
            }
        }
    }

    //COLLISION
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "EnemyRoom")
        {
            typeOfLight = 1;
        }
        if(other.gameObject.tag == "Shop")
        {
            typeOfLight = 2;
        }
        if(other.gameObject.tag == "SpecialRoom")
        {
            typeOfLight = 3;
        }
        if(other.gameObject.tag == "Stairs")
        {
            typeOfLight = 4;
        }
    }
}
