using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventoryCounter : MonoBehaviour
{
    public Item[] counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = new Item[5];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Text count = GetComponentInChildren(typeof(Text)) as Text;

        if (count.name.ToUpper().Contains("COUNTER"))
        {
            count.text = counter.ToString();
        }
    }
}

public class Item
{
    public int counter;
    public string name;
}
