using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    Image itemIcon;
    [SerializeField]
    Text stackAmount;

    int itemIndex;

    public void SetIndex(int index)
    {
        itemIndex = index;
    }

    public void SetItem(ItemSlot slot)
    {
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = slot.item.sprite;
        if(slot.item.stackable == true)
        {
            //change message displayed by text
            stackAmount.text = slot.amount.ToString();
            stackAmount.gameObject.SetActive(true);
        }
        else
        {
            //if not stackable no text
            stackAmount.gameObject.SetActive(false);
        }
    }

    //remove the item text & image with this function
    public void Remove()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
        stackAmount.gameObject.SetActive(false);
    }
}
