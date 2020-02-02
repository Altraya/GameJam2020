using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupause : MonoBehaviour
{
    public Canvas pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            pausemenu.enabled = true;
            Time.timeScale = 0;
        }
    }
}
