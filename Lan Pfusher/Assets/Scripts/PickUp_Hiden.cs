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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get space key
        bool down = Input.GetKeyDown(KeyCode.Joystick1Button1);//A button from snes

        #region PickUp
        //Action for PickUp event
        if (statutPickUp == StatutPickUp.PickUpIsPossible && down == true)
        {
            //PickUp enabled
            statutPickUp = StatutPickUp.IsPickUp;
            //objects = GameObject.Find("PickUp");
            //currentObject.enabled = !objects.GetComponent<Renderer>().enabled;
            Destroy(currentObject);
            spriteR = currentObject.GetComponent<SpriteRenderer>();//myFirstImage;
            //imageCurrentObjectPickUp.sprite = spriteR.sprite;// Resources.LoadAll<Sprite>(spriteNames);
            //imageCurrentObjectPickUp.enabled = true;
            statutPickUp = StatutPickUp.PickUpNotPossible;
            Inventory.addObjectInInventory(spriteR.sprite);
            
            //Change image of bommy
            //boomy.GetComponent<SpriteRenderer>().sprite = myFirstImage;
        }
        else if (statutPickUp == StatutPickUp.IsPickUp&& down == true)
        {
            //PickUp disabled
            statutPickUp = StatutPickUp.PickUpIsPossible;
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
            debugInfo.text =  statutPickUp.ToString() + "\n" + Inventory.getInventoryQuantity("Vase1").ToString();
        }
        catch { }
    }
}
