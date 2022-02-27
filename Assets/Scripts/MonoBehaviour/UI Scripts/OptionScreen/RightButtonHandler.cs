using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonHandler : MonoBehaviour
{
    [SerializeField] private Image rightImage;
    public BothButtonHandler state;
    private int curState;

    public void SetRightImage(Sprite newRightImage)
    {
        rightImage.sprite = newRightImage;
    }

    public void RightButtonClicked()
    {
        
        if(curState == 0)
        {
            print("increase skate speed");
        }
        //print("increase skate speed");
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
