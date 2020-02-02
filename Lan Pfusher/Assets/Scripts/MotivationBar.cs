using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotivationBar : MonoBehaviour
{
    public Image motivationBar;


    private float totalMaxMotivation;
    private float totalMotivation;
    private List<GameObject> gamers;
    private int nbGamer;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gamers = new List<GameObject>();
            gamers.AddRange(GameObject.FindGameObjectsWithTag("GamerPNJ"));
            once = true;
            nbGamer = gamers.Count;
            totalMaxMotivation = 100;
            totalMotivation = totalMaxMotivation;
            motivationBar.type = Image.Type.Filled;

        }
        catch (System.Exception e)
        {
            
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        totalMotivation = 0;
        totalMaxMotivation = 0;
        //TODO maybe it's to much to call that each frame, but ... you know... sometimes it happens
        //we need to sum all motivation of gamers tohave our motivation bar accurate
        foreach(GameObject gamer in gamers){
            var gamerScript = gamer.GetComponent(typeof(GamerScript)) as GamerScript;
            var gamerMotivationScript = gamer.GetComponent(typeof(GamerMotivationScript)) as GamerMotivationScript;
            gamerMotivationScript.TypeOfGamer = gamerScript.TypeOfGamer;

            float motivation = 100;
            float maxMotivation = 100;
            if(gamerScript != null) {
                //get back info for gamer from scene
                motivation = gamerMotivationScript.motivation;
                maxMotivation = gamerMotivationScript.maxMotivation;
                totalMotivation += motivation;
                totalMaxMotivation += maxMotivation;
            }
            
        }
        motivationBar.fillAmount = totalMotivation / totalMaxMotivation;
        
        
        float quart = totalMaxMotivation/4;
        float threeQuart = quart * 3;

        if (totalMotivation <= threeQuart && totalMotivation > quart) //50%
        {
            motivationBar.color = Color.yellow;
        }
        if (totalMotivation <= quart) //25%
        {
            motivationBar.color = Color.red;
        }
    }
}
