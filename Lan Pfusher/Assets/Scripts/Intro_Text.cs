using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Text : MonoBehaviour
{
    public float letterPause = 0.2f;
    public Text NextText;
    public string NextScene;
    string message;
    Text textComp;
    bool finish;


    // Use this for initialization
    private void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
    }


    public void Start_text()
    {        
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        finish = true;
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && finish == true)
        {
            if(NextText != null)
            {
                NextText.GetComponent<Intro_Text>().Start_text();
                textComp.enabled = false;
                finish = false;
            }
            else
            {
                SceneManager.LoadScene(NextScene);
            }
            
        }
    }
}
