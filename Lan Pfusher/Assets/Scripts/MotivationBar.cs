using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MotivationBar : MonoBehaviour
{
    public Image motivationBar;

    private float maxMotivation;
    private float motivation;

    // Start is called before the first frame update
    void Start()
    {
        maxMotivation = 100;
        motivation = maxMotivation;

        motivationBar.type = Image.Type.Filled;

    }

    // Update is called once per frame
    void Update()
    {
        motivation--;

        motivationBar.fillAmount = motivation / maxMotivation;
        if (motivation <= 0)
        {
            //Perdu
        }
    }
}
