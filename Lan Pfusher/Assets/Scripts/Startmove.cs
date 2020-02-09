using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Startmove : MonoBehaviour
{
    public int speed;
    private Vector3 finalmove;
    public Vector3 startmove;
    private bool once = false;
    public Intro_Text scriptText;

    // Start is called before the first frame update
    void Start()
    {
        finalmove = transform.position;
        transform.Translate(startmove);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < finalmove.x & startmove.x < 0)
        {
            transform.Translate(new Vector3(1f, 0f, 0f) * Time.deltaTime * speed);
        }else if (transform.position.x > finalmove.x & startmove.x > 0)
        {
            transform.Translate(new Vector3(-1f, 0f, 0f) * Time.deltaTime * speed);
        }
        else if (transform.position.y > finalmove.y & startmove.y > 0)
        {
            transform.Translate(new Vector3(0f, -1f, 0f) * Time.deltaTime * speed);
        }
        else if (transform.position.y < finalmove.y & startmove.y < 0)
        {
            transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime * speed);            
        }
        else
        {
            if (!once)
            {
                try
                {
                    scriptText.Start_text();
                }catch(NullReferenceException e)
                {}                
                once = true;
            }
            
        }
    }
}
