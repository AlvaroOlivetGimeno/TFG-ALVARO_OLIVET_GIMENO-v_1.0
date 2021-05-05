using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [Header("TYPE OF LIGHT:")]
    public float typeOfLight; //0.Normal  1.EnemyRoom  2.Shop  3.Special  4.Stairs

    [Header("COLOR -NORMAL-:")]
    public Color normalColorOff;
    public Color normalColorOn;
    public GameObject normalParticles;

    [Header("COLOR -ENEMY ROOM-:")]
    public Color enemyColorOff;
    public Color enemyColorOn;
    public GameObject enemyParticles;

    [Header("COLOR -SHOP ROOM-:")]
    public Color shopColorOff;
    public Color shopColorOn;
    public GameObject shopParticles;

    [Header("COLOR -SPECIAL ROOM-:")]
    public Color specialColorOff;
    public Color specialColorOn;
    public GameObject specialParticles;

    [Header("COLOR -STAIRS-:")]
    public Color stairsColorOff;
    public Color stairsColorOn;
    public GameObject stairsParticles;

    [Header("SPRITE RENDERER:")]
    public SpriteRenderer spriteRenderer;


    bool oneTime;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        typeOfLight = this.transform.parent.GetComponent<LightRoomManager>().typeOfLight;

        
        ChooseColorController();
    }

     //CHOOSE THE COLOR
    void ChooseColorController()
    {
        switch(typeOfLight)
        {
            case 0:
            if(this.transform.parent.GetComponent<LightRoomManager>().contact)
            {
                spriteRenderer.color = normalColorOn;
                if(!oneTime)
                {
                    Instantiate(normalParticles, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            }
            else
            {
                spriteRenderer.color = normalColorOff;
            }
            break;

            case 1:
            if(this.transform.parent.GetComponent<LightRoomManager>().contact)
            {
                spriteRenderer.color = enemyColorOn;
                 if(!oneTime)
                {
                    Instantiate(enemyParticles, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            }
            else
            {
                spriteRenderer.color = enemyColorOff;
            }
            break;

            case 2:
            if(this.transform.parent.GetComponent<LightRoomManager>().contact)
            {
                spriteRenderer.color = shopColorOn;
                 if(!oneTime)
                {
                    Instantiate(shopParticles, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            }
            else
            {
                spriteRenderer.color = shopColorOff;
            }
            break;

            case 3:
            if(this.transform.parent.GetComponent<LightRoomManager>().contact)
            {
                spriteRenderer.color = specialColorOn;
                if(!oneTime)
                {
                    Instantiate(specialParticles, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            }
            else
            {
                spriteRenderer.color = specialColorOff;
            }
            break;

            case 4:
            if(this.transform.parent.GetComponent<LightRoomManager>().contact)
            {
                spriteRenderer.color = stairsColorOn;
                if(!oneTime)
                {
                    Instantiate(stairsParticles, this.transform.position, Quaternion.identity);
                    oneTime = true;
                }
            }
            else
            {
                spriteRenderer.color = stairsColorOff;
            }
            break;
        }
    }

}
