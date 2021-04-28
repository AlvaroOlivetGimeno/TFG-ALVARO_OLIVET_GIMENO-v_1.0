using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : MonoBehaviour
{
    [Header("LIST OF CHILD's:")]
    public List<GameObject> childs = new List<GameObject>();

    [Header("HARD ENEMY LIST VARIABLES:")]
    public float closeDoorsRndVar;

    public bool closeDoors;

    
    GameObject enemyBrain;

    void Start()
    {
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");


        closeDoorsRndVar = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------CIERRE TOTAL-----------------------
        CloseDoors();

        //----------------
        //Debug.Log( this.transform.childCount-1);

    }


    //CLOSE DOORS??
    void CloseDoors()
    {
        if(closeDoorsRndVar >= enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().closeDoorsPct)
        {
            foreach(GameObject child in childs)
            {
                if(child.GetComponent<EnemyRoomChildScript>().childType == 2)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            closeDoors = true;
        }
    }

    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Shop")
        {
            Destroy(this.gameObject);
        }
    }
}
