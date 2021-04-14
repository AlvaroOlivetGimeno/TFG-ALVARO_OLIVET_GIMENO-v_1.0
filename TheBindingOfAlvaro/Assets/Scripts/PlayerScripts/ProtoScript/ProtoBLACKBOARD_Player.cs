using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoBLACKBOARD_Player : MonoBehaviour
{
    [Header("CHARACTER SPEED:")]

    public float characterSpeed;

    [Header("CHARACTER BASIC BULLET:")]

    public GameObject Bullet;




    [Header("AUTOMATIC OBJECTS:")]
    public GameObject mCamera;

    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
