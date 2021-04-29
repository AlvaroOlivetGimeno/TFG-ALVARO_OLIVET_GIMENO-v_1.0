using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject enemy;

    public bool oneTime;

    public float timerForSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!oneTime)
        {
            timerForSpawn += 1* Time.deltaTime;
            if(timerForSpawn>= 2)
            {
                Instantiate(enemy, this.transform.position, Quaternion.identity);
                oneTime = true;
            }
            
        }
    }
}
