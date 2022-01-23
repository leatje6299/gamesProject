using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    [SerializeField]
    ItemHolder inventory;

    ItemSlot currentItemSlot;
    int currentItemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchItem();
        Debug.Log(currentItemSlot.item);
    }
    
    void SelectItem()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            if(i == currentItemIndex)
            {
                currentItemSlot = inventory.slots[i];
                currentItemIndex = i;
            }
        }
    }

    void SwitchItem()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (i == currentItemIndex)
            {
                if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f) //forwards
                {
                    //Debug.Log("Scroll up");
                    currentItemSlot = inventory.slots[i + 1];
                    currentItemIndex = i + 1;
                }
                if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f) //backwards
                {
                    //Debug.Log("Scroll down");
                    currentItemSlot = inventory.slots[i - 1];
                    currentItemIndex = i - 1;
                }
            }
        }

    }

    ItemSlot getCurrentItem()
    {
        return currentItemSlot;
    }
}
