using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private Text description;
    [SerializeField] private GameObject noteCanvas;

    public void readNote(Note note)
    {
        noteCanvas.SetActive(true);

        description.text = note.description;
        if(note.tutorialNote && note.order == 1)
        {

        }
    }
}
