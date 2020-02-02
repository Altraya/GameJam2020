using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairScript : MonoBehaviour
{

    private bool isRepairPossible;
    GameObject currentGamer;

    public Text infoText;

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
            if (errorType >= 0 && isRepairPossible)
            {
                if (Inventory.getIndex(Inventory.currentItem()) == errorType && Inventory.getInventoryQuantity(Inventory.currentItem()) > 0)
                {
                    infoText.gameObject.SetActive(true);

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
                    infoText.gameObject.SetActive(false);
                    gs.Repairing(false);
                }
            }
            else
            {
                gs.Repairing(false);
                infoText.gameObject.SetActive(false);

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
            infoText.gameObject.SetActive(false);
        }
    }

}
