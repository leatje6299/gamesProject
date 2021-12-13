using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public const int numItemSlots = 4; //const to have array of images and items identic
    public bool invFull = false;

    public void AddItem(Item itemToAdd)
    {
        for(int i = 0; i < items.Length; i++) //loop through our inventory 
        {
            if(items[i] == null) //if empty we populate it
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true; //since we turned it off in the inspector
                return; //we are done so we go out of the function
            }
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void InvFull() //change this i got lost
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                invFull = false;
                return;
            }
            else if(items[i] != null)
            {
                i++;
            }
        }
    }

    public Item getCurrentItem(Item current)
    {
        return current;
    }
}
