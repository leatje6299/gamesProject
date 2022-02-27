using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
