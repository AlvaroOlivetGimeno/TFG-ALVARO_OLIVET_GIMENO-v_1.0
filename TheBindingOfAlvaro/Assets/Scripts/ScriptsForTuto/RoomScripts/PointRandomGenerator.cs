using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRandomGenerator : MonoBehaviour
{
    [Header("PROBABILITY TO APPEAR:")]
    public float probability;

    [Header("OBJECT PREFABS:")]
    public GameObject Obstacle;
    public GameObject Jar;

    [Header("I SPAWN AN OBJECT:")]
    public bool spawn;


    ////OTHER VARABLES

    private float rand;
    private int rand2;
    
    void Start()
    {
        
    }
    void Update()
    {
        if(!spawn)
        {
            CreateTheObject(WichObject(),SpawnObject());
        }
        
    }

    public bool SpawnObject()
    {
        rand = Random.Range(0,100);

        if(probability >= rand)
        {
            return true;
        }
        else
        {
            spawn = true;
            return false;
        }
    }

    public int WichObject()
    {
        rand2 = Random.Range(0,100);
        return rand2;
    }

    public void CreateTheObject(int x, bool y)
    {
        if(y)
        {
            if(rand2 >= 50)
            {
                Instantiate(Obstacle,this.transform.position, Quaternion.identity);
                spawn = true;
            }
            if(rand2 < 50)
            {
                Instantiate(Jar,this.transform.position, Quaternion.identity);
                spawn = true;
            }

        }

    }

}
