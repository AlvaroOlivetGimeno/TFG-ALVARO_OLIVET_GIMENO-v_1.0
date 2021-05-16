using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDrawScript : MonoBehaviour
{
    [Header("AUTOMATIC OBJECTS:")]
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
