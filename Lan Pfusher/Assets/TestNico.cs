using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNico : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> items = new List<GameObject>();

        for(int i =0; i < transform.childCount; i ++)
        {
            items.Add(transform.GetChild(i).gameObject);
        }

        foreach (GameObject go in items)
        {
            
            if(go.name.ToUpper().Contains("CLAVIER"))
            {
                InventoryCounter clavierCounter = go.GetComponentInChildren(typeof(InventoryCounter)) as InventoryCounter;
                clavierCounter.counter++;
            }
        }
    }
}
