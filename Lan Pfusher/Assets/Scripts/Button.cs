using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{

    public void play()
    {
        //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_ValiderTouche);
        SceneManager.LoadScene("Game");
    }

    public void End()
    {
        //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_ValiderTouche);
        Application.Quit();
    }

    public void resume()
    {
        this.GetComponentInParent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
}
