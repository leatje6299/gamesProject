using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    public static bool openJournal = false;
    public GameObject journalUI;
    public GameObject inventory;
    public GameObject stats;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(openJournal)
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
        journalUI.SetActive(false);
        Time.timeScale = 1f;
        openJournal = false;
        inventory.SetActive(true);
        stats.SetActive(true);
    }

    void Open()
    {
        journalUI.SetActive(true);
        Time.timeScale = 1f;
        openJournal = true;
        inventory.SetActive(false);
        stats.SetActive(false);
    }
}
