using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsOnRoom : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("TIPO DE ENEMIGO (1 = SHOOTER, 2 = FOLLOWERS, 3 = SPECIAL)")]
    public float enemyType; //1. Shooters 2.Followers 3.Specials
    [Header("LISTA ENEMIGOS:")]
    public EnemyFollowersScript enemyFollowScript;

    void Start()
    {
       if(enemyType == 2)
        {
            enemyFollowScript = GetComponent<EnemyFollowersScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ActiveEnemy()
    {
        if (enemyType == 2)
        {
            enemyFollowScript.PlayerHasReturn();
        }


    }

    public void DesactiveEnemy()
    {
        if (enemyType == 2)
        {
            enemyFollowScript.PlayerHasGone();
           
        }

    }
}
