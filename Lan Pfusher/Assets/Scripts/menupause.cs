using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupause : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.isActiveAndEnabled == false && Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            //this.GetComponentInParent<Canvas>().enabled = true;
            canvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}
