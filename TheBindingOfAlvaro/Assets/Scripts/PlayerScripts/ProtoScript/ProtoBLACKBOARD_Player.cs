using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoBLACKBOARD_Player : MonoBehaviour
{
    [Header("CHARACTER VARIABLES:")]

    public float characterSpeed;
    public float delayTimeToShoot;

    [Header("CHARACTER BASIC BULLET:")]

    public GameObject Bullet;

    [Header("POINTS OF BULLETS FOR SHOOTING:")]

    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;

    [Header("AUTOMATIC OBJECTS:")]
    public GameObject mCamera;

    public BasicBulletScript b_Bullet;

    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        b_Bullet = GetComponent<BasicBulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
