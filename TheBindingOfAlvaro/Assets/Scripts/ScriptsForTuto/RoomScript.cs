using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject rBrain;
    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
        rBrain.GetComponent<RoomTemplates>().AddToList(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
