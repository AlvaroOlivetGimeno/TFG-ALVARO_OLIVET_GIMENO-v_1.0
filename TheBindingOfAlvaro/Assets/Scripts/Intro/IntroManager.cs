using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("TEXT's")]   
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject txt5;

    [Header("TIMER's:")] 

    public float timeAlive1;
    public float timeAlive2;
    public float timeAlive3;
    public float timeAlive4;
    public float timeAlive5;
    public float timeBetweenTexts;

    public float timerAlive;
    public float timerBetween;

    public float counter = 0;

    public bool oneTime = false;

    void Start()
    {
        txt1.SetActive(false);
        txt2.SetActive(false);
        txt3.SetActive(false);
        txt4.SetActive(false);
        txt5.SetActive(false); 
    }

    

    // Update is called once per frame
    void Update()
    {
        timerBetween += 1*Time.deltaTime;

        ChooseText();

        SkipLogic();
    }

    void ChooseText()
    {
        if(timerBetween >= timeBetweenTexts)
        {
            timerAlive += 1*Time.deltaTime;

            if(counter == 0)
            {
                
                
                    if(timerAlive < timeAlive1)
                    {
                        txt1.SetActive(true);
                    }
                    else
                    {
                        txt1.SetActive(false);
                        oneTime = false;
                        timerAlive = 0;
                        timerBetween = 0;
                        counter +=1;
                    }
                
            }
            else if(counter == 1)
            {
               
                    if(timerAlive < timeAlive2)
                    {
                        txt2.SetActive(true);
                    }
                    else
                    {
                        txt2.SetActive(false);
                        oneTime = false;
                        timerAlive = 0;
                        timerBetween = 0;
                        counter +=1;
                    }
                
            }
             else if(counter == 2)
            {
               
                    if(timerAlive < timeAlive3)
                    {
                        txt3.SetActive(true);
                    }
                    else
                    {
                        txt3.SetActive(false);
                        oneTime = false;
                        timerAlive = 0;
                        timerBetween = 0;
                        counter +=1;
                    }
                
            }
            else if(counter == 3)
            {
                
                    if(timerAlive < timeAlive3)
                    {
                        txt4.SetActive(true);
                    }
                    else
                    {
                        txt4.SetActive(false);
                        oneTime = false;
                        timerAlive = 0;
                        timerBetween = 0;
                        counter +=1;
                    }
                
            }
            else if(counter == 4)
            {
               
                    if(timerAlive < timeAlive4)
                    {
                        txt5.SetActive(true);
                    }
                    else
                    {
                        txt5.SetActive(false);
                        SceneManager.LoadScene("MenuScene");
                    }
                
            }
        }
    }

    void SkipLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }


}
