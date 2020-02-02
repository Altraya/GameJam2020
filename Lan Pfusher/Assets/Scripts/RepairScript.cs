using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairScript : MonoBehaviour
{

    private bool isRepairPossible;
    GameObject currentGamer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentGamer != null)
        {
            GamerScript gs = (currentGamer.GetComponent(typeof(GamerScript)) as GamerScript);
            int errorType = gs.errorType;
            if (errorType >= 0)
            {
                if (Inventory.getInventoryQuantity(Inventory.getName(errorType)) > 0)
                {
                    if (Input.GetKey(KeyCode.Joystick1Button1))
                    {
                        gs.Repairing(true);
                    }
                    else
                    {
                        gs.Repairing(false);
                    }
                }
                else
                {
                    gs.Repairing(false);
                }
            }
            else
            {
                gs.Repairing(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GamerPNJ"))
        {
            isRepairPossible = true;
            currentGamer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GamerPNJ"))
        {
            isRepairPossible = false;
        }
    }

}
