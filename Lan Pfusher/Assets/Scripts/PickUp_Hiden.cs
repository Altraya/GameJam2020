﻿using System.Collections;
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

    StatutPickUp statutPickUp = StatutPickUp.PickUpNotPossible;
    //Public entry
    public Text debugInfo;

    enum StatutPickUp
    {
        PickUpNotPossible,
        PickUpIsPossible,
        IsPickUp
    };

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
        Inventory.addObjectInInventory("Switch");

        //Add object
        Inventory.addObjectInInventory("Clavier");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Casque");
        Inventory.addObjectInInventory("Switch");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get space key
        bool buttonA = Input.GetKeyDown(KeyCode.Joystick1Button1);//A button from snes

        #region PickUp
        //Action for PickUp event
        if (statutPickUp == StatutPickUp.PickUpIsPossible && buttonA == true)
        {
            //PickUp enabled
            statutPickUp = StatutPickUp.IsPickUp;
            Destroy(currentObject);
            spriteR = currentObject.GetComponent<SpriteRenderer>();//myFirstImage;
            statutPickUp = StatutPickUp.PickUpNotPossible;
            Inventory.addObjectInInventory(spriteR.sprite.name);
        }

        else if (statutPickUp == StatutPickUp.IsPickUp && buttonA == true)
        {
            //PickUp disabled
            statutPickUp = StatutPickUp.PickUpIsPossible;
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
        if (Input.GetKeyUp(KeyCode.Joystick1Button5))//R button from snes
        {
            Inventory.switchObject(true);
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button4))//L button from snes
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
            statutPickUp = StatutPickUp.PickUpIsPossible;
            currentObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PickUp"))
        {
            statutPickUp = StatutPickUp.PickUpNotPossible;
        }
    }

    private void displayInfoDebug()
    {
        try
        {
            debugInfo.text = statutPickUp.ToString() + "\n" + Inventory.displayInfoInventory() + "\nCurrent Item: " + Inventory.currentItem() + " --> " + Inventory.getInventoryQuantity(Inventory.currentItem());
        }
        catch { }
    }
}
