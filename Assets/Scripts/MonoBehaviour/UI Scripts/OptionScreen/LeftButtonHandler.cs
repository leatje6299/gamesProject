using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script by Lea

public class LeftButtonHandler : MonoBehaviour
{
    [Header("Item Fields")]
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private Item jacket;
    [SerializeField] private Item snack;

    [Header("Scripts Fields")]
    [SerializeField] private PlayerStatManagement temp;
    [SerializeField] ChoiceState choice;

    [Header("UI Fields")]
    [SerializeField] private Image leftImage;
    [SerializeField] private GameObject choiceCanvas;

    public void SetLeftImage(Sprite newLeftImage)
    {
        leftImage.sprite = newLeftImage;
    }

    public void LeftButtonClicked()
    {
        
        if (choice.curState <= 1f)
        {
            print("put jacket into inventory");
            inventory.Add(jacket);
            temp.setTempTick(1f);
            choiceCanvas.SetActive(false);
        }
        if(choice.curState >= 1f)
        {
            print("5 snacks into your inventory");
            inventory.Add(snack, 5);
            choiceCanvas.SetActive(false);
        }
    }
}
