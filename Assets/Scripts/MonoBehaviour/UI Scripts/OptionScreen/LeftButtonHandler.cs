using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonHandler : MonoBehaviour
{
    [SerializeField] private Image leftImage;
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private Item jacket;
    [SerializeField] private Item snack;
    [SerializeField] private PlayerStatManagement temp;

    public BothButtonHandler state;
    private float curState;

    public void SetLeftImage(Sprite newLeftImage)
    {
        leftImage.sprite = newLeftImage;
    }

    public void LeftButtonClicked()
    {
        
        if (curState <= 1f)
        {
            print("put jacket into inventory");
            inventory.Add(jacket);
            temp.setTempTick(1f);
        }
        if(curState >= 1f)
        {
            print("5 snacks into your inventory");
            inventory.Add(snack, 5);
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
