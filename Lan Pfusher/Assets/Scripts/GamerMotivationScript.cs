using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerMotivationScript : MonoBehaviour
{
    public float maxMotivation;
    public float motivation;
    private int coeffDecreaseMotivation;
    private int coeffIncreaseMotivation;
    private TypeOfGamer typeOfGamer;
    public TypeOfGamer TypeOfGamer
    {
        get { return typeOfGamer; }   // get method
        set {
            typeOfGamer = value;
            GetCoefByTypeOfGamer();
        }  // set method
    }

    // Start is called before the first frame update
    void Start()
    {
        maxMotivation = 100;
        motivation = maxMotivation;
        //GetCoefByTypeOfGamer();
        StartCoroutine(DecreaseGamerMotivation());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HandleRepairFinished()
    {
        this.coeffIncreaseMotivation = GetIncreaseMotivation(IncreaseMotivationType.REPAIR);
        IncreaseGamerMotivation();
    }

    private int GetIncreaseMotivation(IncreaseMotivationType increaseMotivationType)
    {
        int coeffIncreaseMotivation = 0;

        switch (increaseMotivationType)
        {
            case IncreaseMotivationType.COFFEE:
                coeffIncreaseMotivation = 30;
                break;
            case IncreaseMotivationType.BEER:
                coeffIncreaseMotivation = 30;
                break;
            case IncreaseMotivationType.COOKIE:
                coeffIncreaseMotivation = 15;
                break;
            case IncreaseMotivationType.STEAK:
                coeffIncreaseMotivation = 10;
                break;
            case IncreaseMotivationType.REPAIR:
            default:
                coeffIncreaseMotivation = 50;
                break;
        }

        return coeffIncreaseMotivation;
    }

    void IncreaseGamerMotivation()
    {
        if (motivation > maxMotivation)
        {
            motivation = maxMotivation;
        }
        else
        {
            motivation += coeffIncreaseMotivation;
        }    
    }

    IEnumerator DecreaseGamerMotivation(){
        while(true){
            yield return new WaitForSeconds(1);
            if (motivation > 0)
            {
                motivation -= coeffDecreaseMotivation;
            }
            else
            {
                motivation = 0;
                SceneManager.LoadScene("GameOver");
            }
        }       
    }

    void GetCoefByTypeOfGamer() {
        switch(this.TypeOfGamer){
            case TypeOfGamer.CHILL:
                coeffDecreaseMotivation = 1;
            break;
            case TypeOfGamer.DECK:
                coeffDecreaseMotivation = 3;
            break;
            case TypeOfGamer.NORMAL:
            default:
                coeffDecreaseMotivation = 2;
            break;
        }
    }
}

public enum IncreaseMotivationType
{
    REPAIR,
    BEER,
    COFFEE,
    COOKIE,
    BROWNIE,
    STEAK
}