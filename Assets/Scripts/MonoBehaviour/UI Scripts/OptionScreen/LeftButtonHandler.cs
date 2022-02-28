using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonHandler : MonoBehaviour
{
    [SerializeField] private Image leftImage;
    [SerializeField] private ItemHolder item;
    [SerializeField] private Item jacket;
    [SerializeField] private PlayerStatManagement temp;

    public BothButtonHandler state;
    private int curState;

    public void SetLeftImage(Sprite newLeftImage)
    {
        leftImage.sprite = newLeftImage;
    }

    public void LeftButtonClicked()
    {
        curState = state.GetCurState();
        if (curState == 1)
        {
            print("put jacket into inventory");
            item.Add(jacket);
            temp.setTempTick(1f);
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
