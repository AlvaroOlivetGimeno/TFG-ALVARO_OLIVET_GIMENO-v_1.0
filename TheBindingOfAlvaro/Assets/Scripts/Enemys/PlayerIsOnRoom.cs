using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsOnRoom : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("LISTA ENEMIGOS:")]
    public float enemyType; //1. Shooters 2.Followers 3.Specials

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
