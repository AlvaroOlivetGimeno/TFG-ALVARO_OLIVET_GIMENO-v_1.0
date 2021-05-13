using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFeedback : MonoBehaviour
{
    [Header("CHILD:")]
    public GameObject child1;
    public GameObject child2;

    [Header("ACTIVE THINGS:")]

    public float timer;
     public float hardTimer;

    public float timeToAppear;
    void Start()
    {
        //child = GameObject.FindGameObjectWithTag("MissionFeedback");
        child1.SetActive(false);
        child2.SetActive(false);
        timer = 20;
        hardTimer = 20;

    }

    // Update is called once per frame
    void Update()
    {
        timer += 1*Time.deltaTime;
        hardTimer += 1*Time.deltaTime;
        ActiveChild1();
        ActiveChild2();

    }

    //ACTIVE YOUR CHILD
    void ActiveChild1()
    {
        if(timer <= timeToAppear)
        {
            child1.SetActive(true);
        }
        else
        {
            child1.SetActive(false);
        }
    }
    void ActiveChild2()
    {
        if(hardTimer <= timeToAppear)
        {
            child2.SetActive(true);
        }
        else
        {
            child2.SetActive(false);
        }
    }

    public void MissionCompleted()
    {
        timer = 0;
    }
     public void MissionFailed()
    {
        hardTimer = 0;
    }
}
