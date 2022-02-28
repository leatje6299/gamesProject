using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BothButtonHandler : MonoBehaviour
{
    public int curState;
    public LeftButtonHandler leftImage;
    public RightButtonHandler rightImage;

    [SerializeField] private Text textBoxL;
    [SerializeField] private Text textBoxR;

    [SerializeField] private Sprite leftIm01;
    [SerializeField] private Sprite rightIm01;

    //[SerializeField] public Image leftIm02;
    //[SerializeField] public Image rightIm02;

    //[SerializeField] public Image leftIm03;
    //[SerializeField] public Image rightIm03;

    //[SerializeField] public Image leftIm04;
    //[SerializeField] public Image rightIm04;

    [SerializeField] private GameObject choiceCanvas;
    public void ButtonPressed()
    {
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        curState++;

        if (curState == 0)
        {
            //leftImage.SetLeftImage(leftIm02);
            //rightImage.SetRightImage(rightIm02);
        }
        if (curState == 1)
        {
            //leftImage.SetLeftImage(leftIm03);
            //rightImage.SetRightImage(rightIm03);
        }
        if (curState == 2)
        {
            //leftImage.SetLeftImage(leftIm04);
            //rightImage.SetRightImage(rightIm04);
        }
    }

    public void Start()
    {
        curState = 0;
        if (curState == 0)
        {
            leftImage.SetLeftImage(leftIm01);
            rightImage.SetRightImage(rightIm01);

            textBoxL.text = "Your body temperature will decrease slower";
            textBoxR.text = "Your speed boost is increased";
        }
    }

    public int GetCurState()
    {
        return curState;
    }
}

