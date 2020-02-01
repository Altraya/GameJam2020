using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MotivationBar : MonoBehaviour
{
    public Image motivationBar;
    public int coeff;

    private float maxMotivation;
    private float motivation;

    // Start is called before the first frame update
    void Start()
    {
        maxMotivation = 100;
        motivation = maxMotivation;
        coeff = 1;
        motivationBar.type = Image.Type.Filled;

    }

    // Update is called once per frame
    void Update()
    {
        motivation-=coeff;

        motivationBar.fillAmount = motivation / maxMotivation;
        if (motivation <= 50)
        {
            motivationBar.color = Color.yellow;
        }
        if (motivation <= 25)
        {
            motivationBar.color = Color.red;
        }
    }
}
