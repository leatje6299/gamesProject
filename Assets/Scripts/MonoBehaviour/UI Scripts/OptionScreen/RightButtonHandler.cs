using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script by Lea
public class RightButtonHandler : MonoBehaviour
{
    [SerializeField] private Image rightImage;

    [Header("Inventory Fields")]
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private Item skate;
    [SerializeField] private Item snack;
    [SerializeField] private Item staminaBoost;

    [Header("Scripts Fields")]
    [SerializeField] private PlayerStatManagement stats;
    [SerializeField] private PlayerMovementControl stamina;
    [SerializeField] ChoiceState choice;

    [Header("UI Fields")]
    [SerializeField] private Text text;
    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private GameObject swapCanvas;

    public void SetRightImage(Sprite newRightImage)
    {
        rightImage.sprite = newRightImage;
    }

    public void RightButtonClicked()
    {
        if (choice.curState <= 1f)
        {
            print("put skate into inventory");
            inventory.Add(skate);
            stamina.setStaminaBoost(2f);
            choiceCanvas.SetActive(false);
        }
        if(choice.curState >= 1f)
        {
            if(inventory.CheckIfSnack(snack))
            {
                print("there is snacks");
                text.text = "You can either have snacks or \r\n the stamina boost in your inventory \r\n Do you want to switch?";
                swapCanvas.SetActive(true);
            }
            else if(!inventory.CheckIfSnack(snack) && !inventory.isFull)
            {
                stats.setStaminaTick(5f);
                inventory.Add(staminaBoost);
                choiceCanvas.SetActive(false);
            }
        }
    }

    public void SwapButton()
    {
        inventory.Swap(snack, staminaBoost);
        choiceCanvas.SetActive(false);
        swapCanvas.SetActive(false);
    }
}
