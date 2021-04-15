using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoBLACKBOARD_Player : MonoBehaviour
{
    [Header("CHARACTER VARIABLES:")]

    public float characterSpeed;
    public float delayTimeToShoot;
    public float timeOfParry;

    [Header("CHARACTER BASIC BULLET:")]

    public GameObject Bullet;

    [Header("POINTS OF BULLETS FOR SHOOTING:")]

    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;

    [Header("PARRY COLLIDER:")]

    public GameObject p_Collider;

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
