using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomChildScript : MonoBehaviour
{
    [Header("TYPE OF A CHILD:")]
    public float childType; //1.FONDO  2.PUERTAS  3.ENEMY POINTS

    [Header("I'VE BEEN ADDED TO A LIST?")]
    public bool added;

    

    void Start()
    {
        //ADD ME TO A PARENTS LIST
        AddMeToPartentList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //AD ME TO MY PARENT LIST
    void AddMeToPartentList()
    {
        if(!added)
        {
            this.transform.parent.GetComponent<EnemyRoomManager>().childs.Add(this.gameObject);
            added = true;
        }
    }
}
