using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TorretEnemyScript : MonoBehaviour
{
    
    
    float timer;

    [Header("DELAY FOR SHOOTING:")]
    public float timeToShoot;

    [Header("BULLETS:")]
    public GameObject normalBullet;
    public GameObject parryBullet;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer +1 * Time.deltaTime;

        if(timer >= timeToShoot)
        {
            Instantiate(normalBullet, this.transform.position, Quaternion.identity);
            timer = 0; 
        }

    }
}
