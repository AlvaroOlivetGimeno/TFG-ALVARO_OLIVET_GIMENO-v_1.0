using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLACKBOARD_ENEMYS : MonoBehaviour
{
    [Header("ENEMY's -SHOOTERS- CONSTANTS:")]
    public float sh_LifeBasic;
    public float sh_LifeIntelligent;
    public float sh_LifeBounce;
    public float sh_TimeToShootIntelligent;
    public float sh_TimeToShootBasic;
    public float sh_TimeToShootBounce;
    public float sh_ParryPct;
    public float sh_TimeFreezed;
    [Header("ENEMY's -SHOOTERS- BULLETS:")]
    public GameObject sh_IntelligentBullet;
    public GameObject sh_IntelligentParryBullet;
    public GameObject sh_BasicBullet;
    public GameObject sh_ParryBullet;
    public GameObject sh_BounceParryBullet;
    public GameObject sh_BounceBullet;







    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
