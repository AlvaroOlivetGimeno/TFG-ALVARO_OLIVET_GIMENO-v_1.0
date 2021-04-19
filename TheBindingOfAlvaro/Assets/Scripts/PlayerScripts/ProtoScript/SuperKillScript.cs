using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperKillScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("LISTA DE ENEMIGOS:")]
    public List<GameObject> enemysAroundMe = new List<GameObject>();
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillElementsOfList();
    }


    public void AddEnemysToList(GameObject x)
    {
        enemysAroundMe.Add(x);
    }
    public void DeleteEnemysOfList(GameObject x)
    {
        enemysAroundMe.Remove(x);
    }
    public void KillElementsOfList()
    {
        foreach(GameObject enemy in enemysAroundMe)
        {
            enemy.GetComponent<EnemyShootersScript>().life = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("+");
            AddEnemysToList(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("-");
            DeleteEnemysOfList(other.gameObject);
        }
    }
    
}
