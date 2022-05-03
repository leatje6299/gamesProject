using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonHandler : MonoBehaviour
{
    [SerializeField] private Image rightImage;

    [Header("Inventory Fields")]
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private Item skate;
    [SerializeField] private Item snack;

    [Header("Scripts Fields")]
    [SerializeField] private PlayerStatManagement stats;
    [SerializeField] private PlayerMovementControl stamina;
    public BothButtonHandler state;
    private float curState;

    public void SetRightImage(Sprite newRightImage)
    {
        rightImage.sprite = newRightImage;
    }

    public void RightButtonClicked()
    {
        if (curState <= 1f)
        {
            print("put skate into inventory");
            inventory.Add(skate);
            stamina.setStaminaBoost(2f);
        }
        if(curState >= 1f)
        {
            if(inventory.CheckIfSnack(snack))
            {
                return;
            }
            else if(!inventory.CheckIfSnack(snack))
            {
                stats.setStaminaTick(5f);
            }
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
