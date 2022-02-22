using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private ItemSlot currentItem;
    PlayerStatManagement stats;

    // Update is called once per frame
    void Update()
    {
        Drink();
    }

    public void Drink()
    {
        if(Input.GetKeyDown("F"))
        {
            if(currentItem.item.title == "water")
            {
                stats.setPlayerThirst(10f);
            }
            else
            {
                return;
            }
        }
    }
}
