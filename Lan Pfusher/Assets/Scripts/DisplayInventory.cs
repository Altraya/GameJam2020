using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //Public entry
    public Text debugInfo;
    public int maxItem;

    //Private
    private int totalItems;
    private int selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        selectedItem = -1; //No item selected

        //disable Image on the top right on the script
        try
        {
            debugInfo.text = "";
        }
        catch { }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalItems = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i).gameObject;
            string name = go.name;
            InventoryCounter itemCounter = go.GetComponentInChildren(typeof(InventoryCounter)) as InventoryCounter;
            itemCounter.counter = Inventory.getInventoryQuantity(name);
            totalItems += itemCounter.counter;
        }
        
        if(totalItems > 0)
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus))//A button from snes
            {
                SelectNextItem();
            }
        }

        if (Input.GetMouseButtonDown(1) == true && Inventory.getInventoryAllQuantity() > 1)
        {
            Inventory.switchObject();
        }
    }

    private void SelectNextItem()
    {
        if(totalItems > 0)
        {
            InventoryCounter itemCounter;
            do
            {
                selectedItem++;
                var go = transform.GetChild(selectedItem).gameObject;
                string name = go.name;
                itemCounter = go.GetComponentInChildren(typeof(InventoryCounter)) as InventoryCounter;
                itemCounter.counter = Inventory.getInventoryQuantity(name);
            } while (itemCounter.counter <= 0);

            var selected = transform.GetChild(selectedItem).gameObject.GetComponentInChildren(typeof(Image));
            if(selected.name == "Selected")
            {

            }

        }
    }
}
