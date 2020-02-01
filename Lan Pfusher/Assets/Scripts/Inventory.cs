using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class Inventory
{
    private static int maxInventory = 3;
    private static Dictionary<string, int> inventory = new Dictionary<string, int>();//Sprite-quantity
    //private static Dictionary<string, Sprite> inventoryName = new Dictionary<string, Sprite>();//Name-Sprite
    private static string lastElement;
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
        if(inventory.Count != 0)
        {
            return inventory[name];
        }
        else
        {
            return 0;
        }
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
        int index = 0;
        int nextIndex = 0;
        foreach (var item in inventory)
        {
            if (right == true)
            {
                if (item.Key == currentElement)
                {
                    nextIndex = index + 1;
                    if (nextIndex > inventory.Count - 1)
                    {
                        nextIndex = 0;
                    }
                    break;
                }
                index++;
            }
            else
            {
                if (item.Key == currentElement)
                {
                    nextIndex = index - 1;
                    if (nextIndex < 0)
                    {
                        nextIndex = inventory.Count - 1;
                    }
                    break;
                }
                index++;
            }
        }
        index = 0;
        foreach (var sprite in inventory)
        {
            if (index == nextIndex)
            {
                currentElement = sprite.Key;
                break;
            }
            index++;
        }
    }

    public static void switchObject_old(bool right = true)
    {
        int index = 0;
        int nextIndex = 0;
        foreach (var sprite in inventory)
        {
            if (right == true)
            {
                if (sprite.Key == currentElement)
                {
                    nextIndex = index + 1;
                    if (nextIndex > inventory.Count - 1)
                    {
                        nextIndex = 0;
                    }
                    break;
                }
                index++;
            }
            else
            {
                if (sprite.Key == currentElement)
                {
                    nextIndex = index - 1;
                    if (nextIndex <= 0)
                    {
                        nextIndex = inventory.Count - 1;
                    }
                    break;
                }
                index--;
            }
        }
        index = 0;
        foreach (var sprite in inventory)
        {
            if (index == nextIndex)
            {
                currentElement = sprite.Key;
                break;
            }
            index++;
        }
    }

    public static string currentItem()
    {
        return currentElement;
    }
}
