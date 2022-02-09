using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    public static bool OpenJournal = false;
    public GameObject JournalUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(OpenJournal)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Close()
    {
        JournalUI.SetActive(false);
        Time.timeScale = 1f;
        OpenJournal = false;
    }

    void Open()
    {
        JournalUI.SetActive(true);
        Time.timeScale = 1f;
        OpenJournal = true;
    }
}
