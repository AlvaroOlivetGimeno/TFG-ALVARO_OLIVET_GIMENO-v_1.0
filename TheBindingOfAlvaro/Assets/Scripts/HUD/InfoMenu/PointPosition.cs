using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPosition : MonoBehaviour
{
    [Header("AUTOMATIC ELEMENTS:")]
    public RectTransform rectTransform;

    public GameObject masterBrain;

    float x;

    float y;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        masterBrain = GameObject.FindGameObjectWithTag("MasterBrain");
    }

    // Update is called once per frame
    void Update()
    {
       MovePosition();
    }

    void MovePosition()
    {
       //rectTransform.position = new Vector3(masterBrain.GetComponent<MasterBrainScript>().xPos , masterBrain.GetComponent<MasterBrainScript>().yPos,0);
       this.transform.position = new Vector3(masterBrain.GetComponent<MasterBrainScript>().xPos , masterBrain.GetComponent<MasterBrainScript>().yPos,0);
    }
}
