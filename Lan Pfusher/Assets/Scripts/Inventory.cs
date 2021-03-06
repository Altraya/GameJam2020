﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class Inventory
{
    //Public
    public static int maxInventory = 10;
    //Private
    private static Dictionary<string, int> inventory = new Dictionary<string, int>();//Sprite-quantity
    private static string currentElement;

    public static bool addObjectInInventory(string name)
    {
        if(getInventoryAllQuantity() == 0)
        {
            currentElement = name;
        }

        if (inventory.ContainsKey(name) == false)
        {
            inventory.Add(name, 0);
            return true;
        }
        else
        {
            if (getInventoryAllQuantity() < maxInventory)
            {
                inventory[name]++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static void removeObjectInInventory(string name)
    {
        if (getInventoryQuantity(name) > 0)
        {
            inventory[name]--;
            if(inventory[name] == 0)
            {
                switchObject(true);
            }
        }
    }

    public static void ClearInventory()
    {
        for(int i =0; i < inventory.Count - 1; i ++)
        {
            inventory[inventory.ElementAt(i).Key] = 0;
        }
    }

    public static string displayInfoInventory()
    {
        string text = "";
        foreach(var sprite in inventory)
        {
            text += sprite.Key.ToString() + ":" + sprite.Value.ToString() + "\n";
        }
        return text;
    }

    public static int getInventoryQuantity(string name)
    {
        if (name == "")
        {
            return 0;
        }
        return inventory[name];
    }

    public static int getIndex(string name)
    {
        int index = 0;
        foreach (var item in inventory)
        {
            if (item.Key.ToString() == name)
            {
                return index;
            }
            index++;
        }
        return index;
    }

    public static void setIndex(int index)
    {
        int index2 = 0;
        foreach (var item in inventory)
        {
            if (index2 == index)
            {
                currentElement = item.Key.ToString();
                break;
            }
            index2++;
        }
    }

    public static string getName(int valueToSearch)
    {
        string name = inventory.ElementAt(valueToSearch).Key;
        return name;
    }

    public static int getInventoryAllQuantity()
    {
        int i = 0;
        foreach (var sprite in inventory)
        {
            i += sprite.Value;
        }
        return i;
    }

    public static void switchObject(bool right = true)
    {
        if (getInventoryAllQuantity() == 0)
        {
            currentElement = "";
        }
        if (getInventoryAllQuantity() >= 1)
        {
            int index = getIndex(currentItem());
            if (right == true)
            {
                index++;
                if (index > inventory.Count - 1)
                {
                    index = 0;
                }
            }
            else
            {
                index--;
                if (index < 0)
                {
                    index = inventory.Count - 1;
                }
            }
            setIndex(index);
            if (getInventoryQuantity(currentItem()) == 0)
            {
                switchObject(right);
            }
        }
    }

    public static string currentItem()
    {
        return currentElement;
    }
}
