using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA
public class ItemSwitch : MonoBehaviour
{
    [SerializeField]
    ItemHolder inventory;

    private ItemSlot currentSlot;
    private int currentSlotIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
        currentSlot = getCurrentSlot();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchItem();
    }
    
    void SelectItem()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            if(i == currentSlotIndex)
            {
                currentSlot = inventory.slots[i];
                currentSlotIndex = i;
            }
        }
    }

    void SwitchItem()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f) //forwards
        {
            if(currentSlotIndex >= inventory.slots.Count - 1)
            {
                currentSlotIndex = 0;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            else
            {
                currentSlotIndex++;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            //Debug.Log("Scroll up");
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f) //backwards
        {
            if(currentSlotIndex <= 0)
            {
                currentSlotIndex = inventory.slots.Count - 1;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            else
            {
                currentSlotIndex--;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            //Debug.Log("Scroll down");
        }
    }

    public ItemSlot getCurrentSlot()
    {
        return currentSlot;
    }
}
