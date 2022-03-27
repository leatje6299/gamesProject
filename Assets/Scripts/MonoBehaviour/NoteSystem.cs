using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSystem : MonoBehaviour
{
    public GameObject notesText;
    public static int notes;
    // Update is called once per frame
    void Update()
    {
        notesText.GetComponent<Text>().text = "Notes Collected: " + notes;
    }
}
