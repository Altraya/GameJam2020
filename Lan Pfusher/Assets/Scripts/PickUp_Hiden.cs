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

    //Public entry
    public Text debugInfo;

    StatutPickUp statutPickUp = StatutPickUp.PickUpNotPossible;

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

        Inventory.ClearInventory();
    }

    // Update is called once per frame
    void Update()
    {
        //Get space key
        bool buttonA = Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space);//A button from snes
        //bool buttonA = Input.GetKeyDown("Submit");

        #region PickUp
        //Action for PickUp event
        if (buttonA == true && statutPickUp == StatutPickUp.PickUpIsPossible )
        {
            //spriteR = currentObject.GetComponent<SpriteRenderer>();//myFirstImage;
            if(Inventory.addObjectInInventory(currentObject.name) == false)
            {
                //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_PrendreObjet);
            }
        }
        #endregion
        #region Drop
        //Action for PickUp event
        if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Backspace))//X button from snes
        {
            if (Inventory.getInventoryQuantity(Inventory.currentItem()) >= 1)
            {
                Inventory.removeObjectInInventory(Inventory.currentItem());
                //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_JeterObjet);
            }
        }
        #endregion
        #region ChangeObject
        //Action for PickUp event
        if (Inventory.getInventoryAllQuantity() > 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button5))//R button from snes
            {
                //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_ChangementObjet);
                Inventory.switchObject(true);
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button4))//L button from snes
            {
                Inventory.switchObject(false);
                //SoundEffectsHelper.Instance.MakeSoundEffect(SoundEffectsHelper.Instance.SoundEffect_ChangementObjet);
            }
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
            statutPickUp = StatutPickUp.PickUpIsPossible;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statutPickUp = StatutPickUp.PickUpNotPossible;

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
