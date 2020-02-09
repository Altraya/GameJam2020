using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerScript : MonoBehaviour
{
    public Animator animator;

    public int errorType;

    private int repairLevel;

    public bool isrepairing;

    public bool repaired;

    public TypeOfGamer TypeOfGamer;

    // Start is called before the first frame update
    void Start()
    {

        errorType = -1; //-1 > no error /// 0 to 4 >> errors
        repairLevel = 0;
        //TypeOfGamer = RandomlyChooseGamerType();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Event(int errorID)
    {
        errorType = errorID;
        animator.SetInteger("ErrorID", errorID);
        if(errorID == 0)
            SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PanneClavier);
        else if (errorID == 1)
            SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PanneSouris);
        else if (errorID == 2)
            SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PanneCasque);
        else if (errorID == 3)
            SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PanneTour);
        else if (errorID == 4)
            SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PanneCable);
    }

    public void RepairFinished()
    {
        repairLevel = 0;
        isrepairing = false;
        Inventory.removeObjectInInventory(Inventory.getName(errorType));
        errorType = -1;
        animator.SetInteger("ErrorID", -1);
        animator.SetBool("Repairing", false);

        GamerMotivationScript gs = (this.gameObject.GetComponent(typeof(GamerMotivationScript)) as GamerMotivationScript);
        gs.HandleRepairFinished();
    }

    TypeOfGamer RandomlyChooseGamerType(){
        int random = Random.Range(0, 9);
        if(random <= 6)
        { //60%
            return TypeOfGamer.NORMAL;
        }else if(random > 6 && random < 7)
        { //10%
            return TypeOfGamer.CHILL;
        }else 
        { //30%
            return TypeOfGamer.DECK;
        }
    }

    public void Repairing(bool repair)
    {
        if(repair)
        {
            animator.SetBool("Repairing", true);
            isrepairing = true;
        }
        else
        {
            animator.SetBool("Repairing", false);
            isrepairing = false;
        }

    }
}

public enum TypeOfGamer {
    CHILL,
    NORMAL,
    DECK,
    VALENTIN
    
}