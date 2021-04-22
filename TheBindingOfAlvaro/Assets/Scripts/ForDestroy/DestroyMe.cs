using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [Header("TIME TO KILL ME")]
    public float killTime;

    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if(killTime <= timer)
        {
            Destroy(this.gameObject);
        }
    }
}
