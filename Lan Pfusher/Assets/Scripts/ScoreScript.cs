using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score;

    float StartTime;

    public Text ScoreText;

    public bool Playing;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
        Playing = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Playing)
        {
            Score = (int)(Time.time - StartTime);
            ScoreText.text = Score.ToString();
        }
        else
        {

        }

    }

    public void ResetScore()
    {
        Score = 0;
        StartTime = Time.time;
    }
}
