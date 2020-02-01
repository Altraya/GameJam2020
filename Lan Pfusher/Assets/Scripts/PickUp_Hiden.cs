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
    StatutHiden statutHiden = StatutHiden.HidenNotPossible;
    StatutPickUp statutPickUp = StatutPickUp.PickUpNotPossible;
    //Public entry
    public Text debugInfo;


    enum StatutHiden
    {
        HidenNotPossible,
        HidenIsPossible,
        IsHiden
    };

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
        //disable Image on the top right on the script
        //imageCurrentObjectPickUp.enabled = false;
        //Set boomy as default image
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get space key
        bool down = Input.GetKeyDown(KeyCode.Joystick1Button1);//A button from snes
        //Action for Hiden event
        #region Hiden
        if (statutHiden == StatutHiden.HidenIsPossible && down == true)
        {
            //Hiden enabled
            statutHiden = StatutHiden.IsHiden;
            GetComponent<Rigidbody2D>().velocity = new Vector2();
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            blinkScriptEnabled();
        }
        else if (statutHiden == StatutHiden.IsHiden && down == true)
        {
            //Hiden disabled
            statutHiden = StatutHiden.HidenIsPossible;
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            blinkScriptEnabled();
        }
        #endregion
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

    private void blinkScriptEnabled()
    {
        GetComponent<PlayerPlatformerController>().enabled = !GetComponent<PlayerPlatformerController>().enabled;
        try
        {
            //GetComponent<PlayerBoomyThrow>().enabled = !GetComponent<PlayerBoomyThrow>().enabled;
        }
        catch { }
        try
        {
            //GetComponent<PlayerThrow>().enabled = !GetComponent<PlayerThrow>().enabled;
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hiden"))
        {
            statutHiden = StatutHiden.HidenIsPossible;
        }
        if (collision.gameObject.tag.Equals("PickUp"))
        {
            statutPickUp = StatutPickUp.PickUpIsPossible;
            currentObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hiden"))
        {
            statutHiden = StatutHiden.HidenNotPossible;
        }
        if (collision.gameObject.tag.Equals("PickUp"))
        {
            statutPickUp = StatutPickUp.PickUpNotPossible;
        }
    }

    private void displayInfoDebug()
    {
        try
        {
            debugInfo.text = statutHiden.ToString() + "\n" + statutPickUp.ToString() + "\n" + Inventory.getInventoryQuantity("Vase1").ToString();
        }
        catch { }
    }
}
