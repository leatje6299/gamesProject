using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject choiceCanvas;

    public void ButtonClicked()
    {
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
