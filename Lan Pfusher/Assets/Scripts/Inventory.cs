using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class Inventory
{

    private static Dictionary<Sprite, int> inventory = new Dictionary<Sprite, int>();//Sprite-quantity
    private static Dictionary<string, Sprite> inventoryName = new Dictionary<string, Sprite>();//Name-Sprite
    private static Sprite lastElement;
    private static Sprite currentElement;

    public static void addObjectInInventory(Sprite sprite)
    {
        if(getInventoryAllQuantity() == 0)
        {
            currentElement = sprite;
        }

        if (inventory.ContainsKey(sprite) == false)
        {
            inventory.Add(sprite, 1);
            if (inventoryName.ContainsValue(sprite) == false)
            {
                inventoryName.Add(sprite.name, sprite);
            }
        }
        else
        {
            inventory[sprite]++;
        }
    }

    public static void removeObjectInInventory(Sprite sprite)
    {
        if (inventory.ContainsKey(sprite) == true && inventory[sprite] == 1)
        {
            inventory.Remove(sprite);
            inventoryName.Remove(getNameBySprite(sprite));
            if(sprite == currentElement)
            {
                switchObject();
            }
        }
        else
        {
            inventory[sprite]--;
        }
    }

    public static void removeObjectInInventory(string name)
    {
        removeObjectInInventory(inventoryName[name]);
    }

    public static string displayInfoInventory()
    {
        string text = "";
        foreach(var sprite in inventory)
        {
            text += sprite.Key.name + ":" + sprite.Value.ToString() + "\n";
        }
        return text;
    }

    public static int getInventoryQuantity(string name)
    {
        if(inventoryName.ContainsKey(name) == true && inventory.Count != 0)
        {
            var test = inventoryName[name];
            return inventory[test];
        }
        else
        {
            return 0;
        }
    }

    public static string KeyByValue(Dictionary<string,Sprite > dict, Sprite val)
    {
        string key = null;
        foreach (KeyValuePair<string, Sprite> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    private static string getNameBySprite(Sprite sprite)
    {
        var value = KeyByValue(inventoryName, sprite);
        return value;
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

    public static void switchObject()
    {
        int index = 0;
        int nextIndex = 0;
        foreach (var sprite in inventory)
        {
            if(sprite.Key == currentElement)
            {
                nextIndex = index + 1;
                if(nextIndex > inventory.Count-1)
                {
                    nextIndex = 0;
                }
                break;
            }
            index++;
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

    public static Sprite lastSprite()
    {
        return currentElement;
    }
}
