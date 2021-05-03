using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{ 
    [Header("TYPE OF POINT:")]
    public bool shooterPoint;
    public bool followerPoint;
    public bool specialPoint;
    public bool shooterSpecialPoint;
    public bool shooterFollowerPoint;
    public bool followerSpecialPoint;
    public bool obstacle;

    [Header("ONLY IF YOU MARK OBSTACLE, WICH YOU WANT?")]

    public bool wall;
    public bool spikes;

    [Header("ENEMYS LIST:")]

    public List<GameObject> enemysForSpawn;
    public GameObject obstacleForSpawn;

    [Header("AUTOMATIC ELEMENTS:")]

    public GameObject enemyBrain;

    
    public bool oneTime;
    public float timerForSpawn;

    public float spawnEnemyRndVar;
    public int enemyRndVar;

    void Start()
    {
        enemyBrain = GameObject.FindGameObjectWithTag("EnemyBrain");

        //START METOD
        StartMetod();

        //GIVE NUMBER TO RNDVAR
        spawnEnemyRndVar = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRandomEnemy();

        
    }

    //START METOD
    void StartMetod()
    {
        if(shooterPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().basicShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inteligentShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().bounceShooter);
        }
        else if(followerPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().basicFollower);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().unityFollower);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnFollower);
        }
        else if(specialPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inverterSpecial);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().squidSpecial);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().motherSpecial);
        }
        else if(shooterSpecialPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inteligentShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().bounceShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inverterSpecial);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().squidSpecial);
        }
        else if(shooterFollowerPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().basicShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inteligentShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().bounceShooter);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().basicFollower);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().unityFollower);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnFollower);
        }
        else if(followerSpecialPoint)
        {
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().basicFollower);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().inverterSpecial);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().squidSpecial);
            enemysForSpawn.Add(enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().motherSpecial);
        }

        if(obstacle)
        {
            if(wall)
            {
                obstacle = enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().wallObstacle;
            }
            else if(spikes)
            {
                obstacle = enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spikeObstacle;
            }
        }
        
    }


    //SPAWN ENEMY?
    bool SpawnEnemy()
    {
        if(spawnEnemyRndVar <= enemyBrain.GetComponent<BLACKBOARD_ENEMYS>().spawnEnemyPct)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //SPAWN RANDOM ENEMY
    void SpawnRandomEnemy()
    {
        if(SpawnEnemy())
        {
            if(!obstacle)
            {
                if(!oneTime)
                {
                    timerForSpawn += 1* Time.deltaTime;
                    
                    if(timerForSpawn>= 2)
                    {
                        enemyRndVar = Random.Range(0,enemysForSpawn.Count-1);
                        Instantiate(enemysForSpawn[enemyRndVar].gameObject, this.transform.position, Quaternion.identity);
                        oneTime = true;
                    }            
                }
            }
            else
            {
                if(!oneTime)
                {
                    timerForSpawn += 1* Time.deltaTime;
                    
                    if(timerForSpawn>= 2)
                    {
                        
                        Instantiate(enemysForSpawn[enemyRndVar].gameObject, this.transform.position, Quaternion.identity);
                        oneTime = true;
                    }            
                }
            }
            

        }
        
    }







}
