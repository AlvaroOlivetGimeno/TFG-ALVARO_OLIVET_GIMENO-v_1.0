using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialColliderScript : MonoBehaviour
{
    [Header("TYPE OF YOUR FATHER, PLEASE")]
    public float enemyType;
    [Header("IS IN CONTACT WITH THE PLAYER??")]
    public bool contact = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contact = true;

            if(enemyType == 1)
            {
                collision.GetComponent<ProtoBLACKBOARD_Player>().invertControls = true;
            }
            else if(enemyType == 2)
            {
                collision.GetComponent<ProtoBLACKBOARD_Player>().blackScreen = true;
            }
            else if (enemyType == 3)
            {
                collision.gameObject.GetComponent<ProtoBLACKBOARD_Player>().characterLife -= 1;
            }

        }
    }
}
