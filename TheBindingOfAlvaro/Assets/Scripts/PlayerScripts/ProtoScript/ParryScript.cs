using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ParryBullet")
        {
            Debug.Log("EPEPEPE");
            collision.gameObject.GetComponent<TorretBullet>().Revote();
        }
    }
}
