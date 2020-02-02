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

    // Start is called before the first frame update
    void Start()
    {
        errorType = -1;
        repairLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Event(int errorID)
    {
        errorType = errorID;
        animator.SetInteger("ErrorID", errorID);
    }

    public void RepairFinished()
    {
        repairLevel = 0;
        isrepairing = false;
        Inventory.removeObjectInInventory(Inventory.getName(errorType));
        errorType = -1;
        animator.SetInteger("ErrorID", -1);
        animator.SetBool("Repairing", false);
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
