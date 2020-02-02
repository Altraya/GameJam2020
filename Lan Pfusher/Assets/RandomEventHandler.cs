using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventHandler : MonoBehaviour
{

    private List<GameObject> gamers;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gamers = new List<GameObject>();
            gamers.AddRange(GameObject.FindGameObjectsWithTag("GamerPNJ"));
            once = true;

        }
        catch (System.Exception e)
        {
            
        }
    }
        int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            foreach (GameObject go in gamers)
            {
                var gamerScript = go.GetComponent(typeof(GamerScript)) as GamerScript;
                if (gamerScript.errorType == -1)
                {
                    gamerScript.Event(i);
                }
            }
            i++;
        }
    }
}
