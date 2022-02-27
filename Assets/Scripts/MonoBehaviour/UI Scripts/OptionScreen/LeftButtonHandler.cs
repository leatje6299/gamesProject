using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonHandler : MonoBehaviour
{
    [SerializeField] private Image leftImage;
    public BothButtonHandler state;
    private int curState;

    public void Start()
    {
        
    }

    public void SetLeftImage(Sprite newLeftImage)
    {
        leftImage.sprite = newLeftImage;
    }

    public void LeftButtonClicked()
    {
        curState = state.GetCurState();
        if (curState == 0)
        {
            print("put jacket into inventory");
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}
