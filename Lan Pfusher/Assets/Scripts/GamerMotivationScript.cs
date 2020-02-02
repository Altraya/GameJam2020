using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerMotivationScript : MonoBehaviour
{
    private GamerScript gamerRelatedScript;
    public float maxMotivation;
    public float motivation;
    public int coeff;

    public GamerMotivationScript(GamerScript gamerRelatedScript)
    {
        this.gamerRelatedScript = gamerRelatedScript;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxMotivation = 100;
        motivation = maxMotivation;
        GetCoefByTypeOfGamer();
        StartCoroutine(DecreaseGamerMotivation());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator DecreaseGamerMotivation(){
        while(true){
            yield return new WaitForSeconds(1);
            motivation-=coeff;
        }
        
    }
    void GetCoefByTypeOfGamer() {
        switch(gamerRelatedScript.typeOfGamer){
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
