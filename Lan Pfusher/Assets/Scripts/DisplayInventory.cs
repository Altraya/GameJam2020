using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //Public entry
    public Text debugInfo;
    public Image imageCurrentObjectPickUp;

    // Start is called before the first frame update
    void Start()
    {
        //disable Image on the top right on the script
        imageCurrentObjectPickUp.enabled = false;
        try
        {
            debugInfo.text = "";
        }
        catch { }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i).gameObject;
            string name = go.name;
            InventoryCounter clavierCounter = go.GetComponentInChildren(typeof(InventoryCounter)) as InventoryCounter;
            clavierCounter.counter = Inventory.getInventoryQuantity(name);
        }

        if (Input.GetMouseButtonDown(1) == true && Inventory.getInventoryAllQuantity() > 1)
        {
            Inventory.switchObject();
        }

        Sprite lastSpirte = Inventory.lastSprite();
        if (lastSpirte != null)
        {
            //Display last Image
            //imageCurrentObjectPickUp.sprite = lastSpirte;
            //Display Inventory
            try
            {
                //debugInfo.text = Inventory.displayInfoInventory();
            }
            catch { }
        }

        if(Inventory.getInventoryAllQuantity() == 0)
        {
            imageCurrentObjectPickUp.enabled = false;

        }
        else
        {
            imageCurrentObjectPickUp.enabled = true;
        }
    }
}
