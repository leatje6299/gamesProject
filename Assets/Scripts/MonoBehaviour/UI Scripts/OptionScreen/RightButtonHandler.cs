using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonHandler : MonoBehaviour
{
    [SerializeField] private Image rightImage;
    public BothButtonHandler state;
    private float curState;

    public void SetRightImage(Sprite newRightImage)
    {
        rightImage.sprite = newRightImage;
    }

    public void RightButtonClicked()
    {
        if(curState <= 1f)
        {
            print("increase skate speed");
            //ADD CODE FOR INCREASED BOOST SPEED ON SKATE
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
