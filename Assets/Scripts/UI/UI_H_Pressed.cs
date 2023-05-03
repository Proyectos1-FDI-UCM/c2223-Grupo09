using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_H_Pressed : MonoBehaviour
{
    private int position = 1675;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if (position <= 35) position = 35;
            else 
            {
                position -=5;
                GetComponent<Transform>().Translate(new Vector2(-5, 0));
            }            
        }
        else
        {

            if (position >= 1675) position = 1675;
            else
            {
                position +=5;
                GetComponent<Transform>().Translate(new Vector2(5, 0));
            }
        }        
    }
}