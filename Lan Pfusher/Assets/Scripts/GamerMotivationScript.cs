using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerMotivationScript : MonoBehaviour
{
    public float maxMotivation;
    public float motivation;
    private int coeff;
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

    IEnumerator DecreaseGamerMotivation(){
        while(true){
            yield return new WaitForSeconds(1);
            if (motivation > 0)
            {
                motivation -= coeff;
            }
        }       
    }

    void GetCoefByTypeOfGamer() {
        switch(this.TypeOfGamer){
            case TypeOfGamer.CHILL:
                coeff=1;
            break;
            case TypeOfGamer.DECK:
                coeff=3;
            break;
            case TypeOfGamer.NORMAL:
            default:
                coeff=2;
            break;
        }
    }
}
