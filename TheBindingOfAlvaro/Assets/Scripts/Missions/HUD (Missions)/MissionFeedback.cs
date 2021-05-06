using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFeedback : MonoBehaviour
{
    [Header("CHILD:")]
    public GameObject child;

    [Header("ACTIVE THINGS:")]

    public float timer;

    public float timeToAppear;
    void Start()
    {
        child = GameObject.FindGameObjectWithTag("MissionFeedback");
        child.SetActive(false);
        timer = 20;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1*Time.deltaTime;
        ActiveChild();

    }

    //ACTIVE YOUR CHILD
    void ActiveChild()
    {
        if(timer <= timeToAppear)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }

    public void MissionCompleted()
    {
        timer = 0;
    }
}
