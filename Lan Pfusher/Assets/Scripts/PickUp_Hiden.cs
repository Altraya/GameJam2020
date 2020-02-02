using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PickUp_Hiden : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject currentObject;
    private GameObject objects;
    private SpriteRenderer spriteR;

    //Public entry
    public Text debugInfo;

    // Start is called before the first frame update
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        //Init
        Inventory.addObjectInInventory("Clavier");
        Inventory.addObjectInInventory("Souris");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Tour");
        Inventory.addObjectInInventory("Cable réseau");
        //Inventory.addObjectInInventory("Switch");

        //Add object
        Inventory.addObjectInInventory("Clavier");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Switch");
        Inventory.addObjectInInventory("Clavier");
        Inventory.addObjectInInventory("Souris");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Tour");
        Inventory.addObjectInInventory("Cable réseau");
        //Inventory.addObjectInInventory("Switch");
    }

    // Update is called once per frame
    void Update()
    {
        //Get space key
        bool buttonA = Input.GetKeyDown(KeyCode.Joystick1Button1);//A button from snes
        //bool buttonA = Input.GetKeyDown("Submit");

        #region PickUp
        //Action for PickUp event
        if (buttonA == true)
        {
            //spriteR = currentObject.GetComponent<SpriteRenderer>();//myFirstImage;
            if(Inventory.addObjectInInventory(currentObject.name) == false)
            {
                SoundEffectsHelper.Instance.MakeSoundEffect_Non();
            }
        }
        #endregion
        #region Drop
        //Action for PickUp event
        if (Input.GetKeyUp(KeyCode.Joystick1Button0))//X button from snes
        {
            Inventory.removeObjectInInventory(Inventory.currentItem());
        }
        #endregion
        #region ChangeObject
        //Action for PickUp event
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))//R button from snes
        {
            Inventory.switchObject(true);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4))//L button from snes
        {
            Inventory.switchObject(false);
        }
        #endregion
        //Display debug
        displayInfoDebug();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PickUp"))
        {
            currentObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
    }

    private void displayInfoDebug()
    {
        try
        {
            debugInfo.text = Inventory.displayInfoInventory() + "\nTotal Item: " + Inventory.getInventoryAllQuantity() + "\nCurrent Item: " + Inventory.currentItem() + " --> " + Inventory.getInventoryQuantity(Inventory.currentItem());
        }
        catch { }
    }
}
