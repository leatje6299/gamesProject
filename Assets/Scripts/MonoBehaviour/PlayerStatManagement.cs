using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    public double playerTemp;
    public int playerHunger;
    public int playerWater;
    public CanvasUpdate canvas;
   // private enum Utenisls {FishingPole, Food, Water, None};
    public int[] inventory;
    public int selectedSlot;

    public GameObject fish;
    public GameObject pole;
    // Start is called before the first frame update
   
    void Start()
    {
        playerTemp = 37.0f;
        playerHunger = 100;
        playerWater = 100;

        inventory = new int[5];
        inventory[0] = 1;
        inventory[1] = 0;
        inventory[2] = 0;
        inventory[3] = 0;
        inventory[4] = 0;

        selectedSlot = 0;

        StartCoroutine(statTick());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y == 1)
        {
            if(selectedSlot == 4)
            {
                selectedSlot = 0;
            } else
            {
                selectedSlot++;
            }
            equip();
        } else if (Input.mouseScrollDelta.y == -1)
        {
            if (selectedSlot == 0)
            {
                selectedSlot = 4;
            }
            else
            {
                selectedSlot--;
            }
            equip();
        }
    }

    private void equip()
    {
        if (inventory[selectedSlot] == 1)
        {
            pole.SetActive(true);
        } else
        {
            pole.SetActive(false);
        }
        if (inventory[selectedSlot] == 2)
        {
            fish.SetActive(true);
        }
        else
        {
            fish.SetActive(false);
        }
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= 0.2;
        playerHunger -= 1;
        playerWater -= 1;
        canvas.UpdateText();
        yield return new WaitForSeconds(4);
        StartCoroutine(statRestart());
    }
    private IEnumerator statRestart()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(statTick());
    }
}
