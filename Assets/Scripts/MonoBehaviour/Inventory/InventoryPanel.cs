using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    ItemHolder inventory;
    [SerializeField]
    List<InventoryButton> buttons;

    // Start is called before the first frame update
    private void Start()
    {
        Show();
    }

    // Update is called once per frame
    private void Show()
    {
        for(int i = 0; i < inventory.slots.Count;i++)
        {
            if(inventory.slots[i].item == null)
            {
                //if no item we clear button
                buttons[i].ClearItem();
            }
            else
            {
                buttons[i].ShowItem(inventory.slots[i]);
            }
        }
    }

    /*private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count;i++)
        {
            buttons[i].SetIndex(i);
        }
    }*/
}
