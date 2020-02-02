using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void End()
    {
        Application.Quit();
    }

    public void resume()
    {
        this.GetComponentInParent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
}
