using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    
    public void play()
    {
        SceneManager.LoadScene("MichMich");
    }

    public void End()
    {
        Application.Quit();
    }

    public void resume(Canvas canvas)
    {

        canvas.enabled = false;
        Time.timeScale = 1;
    }
}
