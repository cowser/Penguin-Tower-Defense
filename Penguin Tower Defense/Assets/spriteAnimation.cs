using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class spriteAnimation : MonoBehaviour
{

    [SerializeField] int animationDelay;
    int animationTimer = 0;
    GameObject[] activeSprite = new GameObject[4];
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
           activeSprite[i] = gameObject.transform.GetChild(i).gameObject;
            
        }
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationTimer == animationDelay)
        {
            Animate();
        }
        else
        {
            animationTimer++;
        }
        Debug.Log(animationTimer);
    }


    void Animate()
    {
        if (activeSprite[0].active)
        {
            activeSprite[0].active = false;
            activeSprite[1].active = true;
        }
        else if (activeSprite[1].active)
        {
            activeSprite[1].active = false;
            activeSprite[2].active = true;
        }
        else if (activeSprite[2].active)
        {
            activeSprite[2].active = false;
            activeSprite[3].active = true;
        }
        else if (activeSprite[3].active)
        {
            activeSprite[3].active = false;
            activeSprite[0].active = true;
            this.enabled = false;
        }
        animationTimer = 0;
        
    }

}
