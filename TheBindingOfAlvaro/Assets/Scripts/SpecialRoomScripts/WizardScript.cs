using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    [Header("AUTOMATIC OBJECT:")]
    public GameObject habilityPoint;

    [Header("PARTICLES:")]

    public GameObject particles;

    [Header("CHILD LIST:")]
    public List<GameObject> childList;

    [Header("CAMERA POINT LIST:")]
    public List<GameObject> cameraPointList;

    GameObject player;
    void Start()
    {
        habilityPoint = GameObject.FindGameObjectWithTag("HabilityPoint");  
        player = GameObject.FindGameObjectWithTag("Player");
        childList.Add(this.transform.GetChild(0).gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        CanvasController();  
    }

    //CHECK FOR THE CANVAS
    void CanvasController()
    {
        if(cameraPointList[0].GetComponent<CameraPointScript>().isPlayerHere)
        {
            if(player.GetComponent<ProtoBLACKBOARD_Player>().activePause)
            {
                foreach(GameObject x in childList)
                {
                    x.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach(GameObject x in childList)
                {
                    x.gameObject.SetActive(true);
                }
            }   
        }
        else
        {
           foreach(GameObject x in childList)
            {
                x.gameObject.SetActive(false);
            } 
        }
    }


    //COLLISIONS
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<ProtoBLACKBOARD_Player>().characterCristals >= 2)
            {
                Debug.Log("EP");
                other.gameObject.GetComponent<ProtoBLACKBOARD_Player>().characterCristals-=2;
                habilityPoint.GetComponent<SpecialRoomPoint>().pointType = 2;
                Instantiate(particles, this.transform.position, Quaternion.identity);
                Destroy(this.transform.parent.gameObject);
               
            } 
        }

        if(other.gameObject.tag == "CamaraPoint")
        {
            cameraPointList.Add(other.gameObject);
        }
    }
}
