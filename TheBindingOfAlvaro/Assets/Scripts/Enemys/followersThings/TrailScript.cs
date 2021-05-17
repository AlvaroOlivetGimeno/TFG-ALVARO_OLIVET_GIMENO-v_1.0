using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
   [Header("TIME ALIVE:")]
    public float timeAlive;

    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FinalCountdown();
    }

    //DESTROY ME
    void FinalCountdown()
    {
        timer += 1*Time.deltaTime;
        if(timer>= timeAlive)
        {
            Destroy(this.gameObject);
        }
    }
}
