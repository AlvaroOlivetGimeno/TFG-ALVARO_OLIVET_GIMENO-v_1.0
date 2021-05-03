using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]

    public Text text;

    public GameObject player;
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "(" + player.GetComponent<ProtoBLACKBOARD_Player>().actualLevel.ToString() + "/10)";
    }
}
