using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //Public entry
    public Text debugInfo;

    // Start is called before the first frame update
    void Start()
    {

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
        for (int i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i).gameObject;
            string name = go.name;
            InventoryCounter itemCounter = go.GetComponentInChildren(typeof(InventoryCounter)) as InventoryCounter;
            itemCounter.counter = Inventory.getInventoryQuantity(name);
            string selectedItem = Inventory.currentItem();

            var image = go.GetComponentInChildren(typeof(Image)) as Image;
            var selected = image.transform.GetChild(0).GetComponent(typeof(Image)) as Image;
            if (selectedItem.ToUpper().Contains(name.ToUpper()))
            {
                selected.enabled = true;
            }
            else
            {
                selected.enabled = false;
            }
        }
    }
}
