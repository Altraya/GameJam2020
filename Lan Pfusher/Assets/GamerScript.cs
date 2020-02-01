using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerScript : MonoBehaviour
{
    public Animator animator;

    public int errorType;

    private int repairLevel;

    public bool isrepairing;

    // Start is called before the first frame update
    void Start()
    {
        errorType = -1;
        repairLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isrepairing)
        {
            repairLevel++;

        }
        if (repairLevel >= 1000)
        {
            repairLevel = 0;
            isrepairing = false;
            animator.SetInteger("ErrorType", -1);
            animator.SetBool("Repairing", false);
        }
    }

    public void RandomEvent()
    {
        int random = 0;
        switch(random)
        {
            case 0:
                errorType = 0;
                animator.SetInteger("ErrorType", 0);
                break;
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
