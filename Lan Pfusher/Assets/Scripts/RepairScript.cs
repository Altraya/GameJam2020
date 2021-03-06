﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class RepairScript : MonoBehaviour
{

    private bool isRepairPossible;
    GameObject currentGamer;

    public Animator animator;

    public Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsRepairing", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGamer != null)
        {
            GamerScript gs = (currentGamer.GetComponent(typeof(GamerScript)) as GamerScript);
            int errorType = gs.errorType;
            if (errorType >= 0 && isRepairPossible)
            {
                if (Inventory.getIndex(Inventory.currentItem()) == errorType && Inventory.getInventoryQuantity(Inventory.currentItem()) > 0)
                {
                    if (infoText != null)
                    {
                        infoText.gameObject.SetActive(true);
                    }

                    if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey("space"))
                    {
                        gs.Repairing(true);
                        animator.SetBool("IsRepairing", true);
                    }
                    else
                    {
                        gs.Repairing(false);
                        animator.SetBool("IsRepairing", false);
                    }
                }
                else
                {
                    gs.Repairing(false);
                    animator.SetBool("IsRepairing", false);
                    if (infoText != null)
                    {
                        infoText.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                gs.Repairing(false);
                animator.SetBool("IsRepairing", false);
                if (infoText != null)
                {
                    infoText.gameObject.SetActive(false);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GamerPNJ"))
        {
            isRepairPossible = true;
            currentGamer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GamerPNJ"))
        {
            isRepairPossible = false;
            try
            {
                infoText.gameObject.SetActive(false);
            }catch(NullReferenceException e)
            {

            }
            
        }
    }

}
