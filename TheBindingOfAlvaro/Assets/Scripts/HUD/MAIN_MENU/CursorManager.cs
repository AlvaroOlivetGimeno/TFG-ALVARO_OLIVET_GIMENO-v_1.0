using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    [Header("POINTS")]
    public GameObject point1;
    public GameObject point2;

    [Header("WHERE ARE YOU?")]

    public bool up = true;


    

    void Start()
    {
        this.transform.position = point1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROLS---
        ControllTheCursor();

        //----------

        //CHANGE SCENE
        ChangeScene();
        //-----
    }

    //CONTROLS
    void ControllTheCursor()
    {
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if(up)
            {
                this.transform.position = point2.transform.position;
                up = false;
            }
        }
         if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if(!up)
            {
                this.transform.position = point1.transform.position;
                up = true;
            }
        }
    }

    //SCENE MANAGER
    void ChangeScene()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
        {
            if(up)
            {
                SceneManager.LoadScene("Scene1");
            }
            else
            {
                Application.Quit();
            }  
        }

    }
    



}
