using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomEventHandler : MonoBehaviour
{

    private List<GameObject> gamers;
    public int TimeRampupDifficultyIncreaseInSecond = 3; //time between problems appear
    public int TimeBetweenIncreasedOfSimultaneousProblems = 15; //default 15sec
    public int RealTimerBetweenAction;
    public int NumberOfSimultaneousProblem = 1;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            RealTimerBetweenAction = TimeRampupDifficultyIncreaseInSecond;
            gamers = new List<GameObject>();
            gamers.AddRange(GameObject.FindGameObjectsWithTag("GamerPNJ"));
            once = true;
            StartCoroutine(RandomlyCallProblemsEvent());
            StartCoroutine(IncreaseNumberOfSimultaneousProblem());
        }
        catch (System.Exception e)
        {
            
        }
    }
        int i = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    //Randomly select one error and activate it on selected player in parameter
    void CallProblemsEvent(GamerScript gamerScript)
    {
        int eventTypeNumber = Random.Range(0, 4); //we coded 5 differents type of event
        if (gamerScript.errorType == -1)
        {
            gamerScript.Event(eventTypeNumber); //others things like animation and inventory are handled with animation....
        }
    }

    //increase individually the number of problem which could happen simultaneously
    IEnumerator IncreaseNumberOfSimultaneousProblem()
    {
        
        if (NumberOfSimultaneousProblem < gamers.Count)
        {
            yield return new WaitForSeconds(TimeBetweenIncreasedOfSimultaneousProblems);    
            NumberOfSimultaneousProblem++; //also increase number of simultaneous problems
        }
    }

    //increase speed of error appearing
    //callErrors and handling them
    IEnumerator RandomlyCallProblemsEvent()
    {
        while (true)
        {
            //each TimeRampupDifficultyIncrease (for example 15sec), difficulty increase
            yield return new WaitForSeconds(RealTimerBetweenAction);

            //increase difficulty
            
            RealTimerBetweenAction -= TimeRampupDifficultyIncreaseInSecond; //here we will decrease time between events (so difficulty increase)               
        

            //only get gamers whom have not any error yet
            List<GamerScript> listOfGamersWithoutErrors = GetAvailableGamersWithoutErrors(gamers);

            //randomly select player without error in this list
            for(int i = 0; i < NumberOfSimultaneousProblem; i++)
            {
                if(listOfGamersWithoutErrors.Any()) //if we have free players without errors
                {
                    //choose one of them
                    int randomIndexForGamer = Random.Range(0, (listOfGamersWithoutErrors.Count-1));

                    CallProblemsEvent(listOfGamersWithoutErrors[randomIndexForGamer]);
                    //remove it from our watcher list 
                    listOfGamersWithoutErrors.RemoveAt(randomIndexForGamer);
                    
                }
                
            }
                    
        }
    }

    //only get gamers whom have not any error yet
    private List<GamerScript> GetAvailableGamersWithoutErrors(List<GameObject> gamersSourceObjectsList)
    {
        List<GamerScript> availableGamersWithoutErrors = new List<GamerScript>();

        foreach(GameObject currentGamerGameObject in gamersSourceObjectsList)
        {
            var currentGamerScript = currentGamerGameObject.GetComponent(typeof(GamerScript)) as GamerScript;
            if(currentGamerScript.errorType == -1)
            {
                availableGamersWithoutErrors.Add(currentGamerScript);
            }
        }
        return availableGamersWithoutErrors;
    }
}
