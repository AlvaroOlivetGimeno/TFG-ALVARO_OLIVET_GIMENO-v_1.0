using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFeedbackMainMenu : MonoBehaviour
{
   [Header("AUTOMATIC ELEMENT")]
   public GameObject cursor;

   [Header("WICH TEXT I AM:")]

   public bool tryText;
   public bool exitText;
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");    
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSize();
    }

    void ChangeSize()
    {
        if(cursor.GetComponent<CursorManager>().up && tryText)
        {
            this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if(!cursor.GetComponent<CursorManager>().up && exitText)
        {
            this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
