using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getkeystarttopause : MonoBehaviour
{
    //public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            if(GetComponent<Canvas>().enabled == true)
            {
                GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1;
            }
            else
            {
                GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
            
            
        }
    }
}
