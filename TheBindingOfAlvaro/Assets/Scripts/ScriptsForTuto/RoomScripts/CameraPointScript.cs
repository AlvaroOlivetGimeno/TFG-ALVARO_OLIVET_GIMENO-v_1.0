using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("IS PLAYER ON THIS ROOM??")]
    public bool isPlayerHere;
    [Header("LISTA ENEMIGOS:")]
    public List<GameObject> enemysOnRoom = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHasGone();

        
    }

    void PlayerHasGone()
    {
        if(!isPlayerHere)
        {
            foreach(GameObject enemy in enemysOnRoom)
            {
                enemy.gameObject.GetComponent<PlayerIsOnRoom>().DesactiveEnemy();
            }
        }
        else
        {
            foreach (GameObject enemy in enemysOnRoom)
            {
                enemy.gameObject.GetComponent<PlayerIsOnRoom>().ActiveEnemy();
            }
        }
    }

    
    
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            isPlayerHere = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.GetComponent<PlayerIsOnRoom>().enemyType == 2 || collision.GetComponent<PlayerIsOnRoom>().enemyType == 4)
            {
                enemysOnRoom.Add(collision.gameObject);
            }
           
            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            isPlayerHere = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemysOnRoom.Remove(collision.gameObject);

        }
    }

    
}
