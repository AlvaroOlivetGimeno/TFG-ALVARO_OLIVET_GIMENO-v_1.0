﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject rBrain;

    private GameObject[] listOfChilds;

    void Start()
    {
        rBrain = GameObject.FindGameObjectWithTag("RoomBrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartCreation()
    {
        
    }
}
