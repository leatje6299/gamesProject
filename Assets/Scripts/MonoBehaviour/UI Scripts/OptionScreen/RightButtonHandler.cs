using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonHandler : MonoBehaviour
{
    [SerializeField] private Image rightImage;
    [SerializeField] private ItemHolder item;
    [SerializeField] private Item skate;
    [SerializeField] private PlayerStatManagement stats;
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
            item.Add(skate);
            //add code
            stats.setStaminaTick(1f);
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
