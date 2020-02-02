using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventoryCounter : MonoBehaviour
{
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Text count = GetComponentInChildren(typeof(Text)) as Text;

        if (count.name.ToUpper().Contains("COUNTER"))
        {
            count.text = counter.ToString();
        }
        
        Text totalCount = transform.parent.GetComponentInChildren(typeof(Text)) as Text;

        if (totalCount.name.ToUpper().Contains("TOTALCOUNTER"))
        {
            totalCount.text = Inventory.getInventoryAllQuantity().ToString() + "/" + Inventory.maxInventory ;
        }
    }
}

