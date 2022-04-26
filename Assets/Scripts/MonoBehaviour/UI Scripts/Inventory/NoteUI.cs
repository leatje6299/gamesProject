using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NoteUI : MonoBehaviour
{
    [Header("Player Input Field")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Note UI Fields")]
    [SerializeField] private Text description;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private Image indicatorUI;

    [Header("Items Fields")]
    [SerializeField] private Note note;
    public void setNoteCanvasActive(Note note)
    {
        noteCanvas.SetActive(true);
        description.text = note.description;
    }

    public void readNote(Note note)
    {
        if (noteCanvas.activeSelf)
        {
            if (note.order == 1)
            {
                indicatorUI.gameObject.SetActive(true);
            }
            if (playerInput.actions["Escape"].triggered)
            {
                noteCanvas.SetActive(false);
                note.order++;
            }
        }
    }

    private void Update()
    {
        readNote(note);
    }
}
