using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score;

    float StartTime;

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        StartTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Score = (int)(Time.time - StartTime);
        ScoreText.text = Score.ToString();
    }
}
