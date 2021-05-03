using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadingScreen : MonoBehaviour
{
    [Header("AUTOMSTIC ELEMENTS:")]

    public GameObject loadingLevels;
    public GameObject player;

    [Header("SPEED:")]

    public float speed;

     Vector2 moveDirection;
    public Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        loadingLevels = GameObject.FindGameObjectWithTag("LoadingLevels");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    //GO TO
    void Follow(GameObject x)
    {
        moveDirection = (x.transform.position - this.transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }
    void MovePlayer()
    {
        switch(player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel)
        {
            case 2: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl2.gameObject); break;
            case 3: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl3.gameObject); break;
            case 4: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl4.gameObject); break;
            case 5: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl5.gameObject); break;
            case 6: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl6.gameObject); break;
            case 7: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl7.gameObject); break;
            case 8: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl8.gameObject); break;
            case 9: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl9.gameObject); break;
            case 20: Follow(loadingLevels.GetComponent<PlayerAdvanceScript>().lvl10.gameObject); break;
        }
    }
}
