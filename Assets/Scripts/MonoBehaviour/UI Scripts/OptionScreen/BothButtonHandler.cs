using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script by Lea
public class BothButtonHandler : MonoBehaviour
{
    public LeftButtonHandler leftImage;
    public RightButtonHandler rightImage;

    [Header("Text Fields")]
    [SerializeField] private Text textBoxL;
    [SerializeField] private Text textBoxR;

    [Header("Sprite Fields")]
    [SerializeField] private Sprite leftIm01;
    [SerializeField] private Sprite rightIm01;

    [SerializeField] public Sprite leftIm02;
    [SerializeField] public Sprite rightIm02;

    [Header("Script Fields")]
    [SerializeField] ChoiceState choice;

    public void ButtonPressed()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        choice.curState+=1;

        if (choice.curState > 1)
        {
            leftImage.SetLeftImage(leftIm02);
            rightImage.SetRightImage(rightIm02);

            textBoxL.text = "Gain 10 snacks!";
            textBoxR.text = "Your stamina will decrease less overtime";
        }
    }

    public void Start()
    {
        if (choice.curState == 0.5f)
        {
            leftImage.SetLeftImage(leftIm01);
            rightImage.SetRightImage(rightIm01);

            textBoxL.text = "Your body temperature will decrease slower";
            textBoxR.text = "Your stamina decreases half as less \r\n when you activate your boost";
        }
    }
}

