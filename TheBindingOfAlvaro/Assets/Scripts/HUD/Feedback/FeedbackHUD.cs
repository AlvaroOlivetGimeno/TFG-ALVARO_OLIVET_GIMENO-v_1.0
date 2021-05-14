using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackHUD : MonoBehaviour
{
    [Header("CHILD:")]
    public GameObject cristalFeedback;

    [Header("ACTIVE THINGS:")]

    public float cristalTimer;

    [Header("TIME ACTIVE:")]
    public float timeToAppear;
    void Start()
    {
        //DESACTIVATE FEEDBACK
        cristalFeedback.SetActive(false);
        
        cristalTimer = 20;
       

    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        cristalTimer += 1*Time.deltaTime;

        //FUNCTIONS
        ActiveCristalFeedback();
        

    }

    //ACTIVE YOUR CHILD
    void ActiveCristalFeedback()
    {
        if(cristalTimer <= timeToAppear)
        {
            cristalFeedback.SetActive(true);
        }
        else
        {
            cristalFeedback.SetActive(false);
        }
    }
   
    //ACTIVATE CRISTAL FEEDBACK
    public void CristalFounfFeedback()
    {
        cristalTimer = 0;
    }
    
}
