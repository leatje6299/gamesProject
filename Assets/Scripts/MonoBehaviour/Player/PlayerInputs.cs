using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//SCRIPT BY LEA

public class PlayerInputs : MonoBehaviour
{
    //input system
    [SerializeField] private PlayerInput playerInput;

    //sphere cast
    public SphereCast sphereCast;
    private GameObject currentHit;

    [SerializeField] private GameObject choiceCanvas;

    [SerializeField] private ItemSwitch currentItem;
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private Item snack;

    [SerializeField] private Note note;
    [SerializeField] private NoteUI noteUI;

    [SerializeField] private PlayerStatManagement stats;

    void Update()
    {
        //print(InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice));
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;

        if (currentHit.tag == "Chest")
        {
            if(playerInput.actions["Interact"].ReadValue<float>()>0)
            {
                Destroy(sphereCast.currentHitObj.gameObject);
                choiceCanvas.SetActive(true);
            }

        }
        if(currentHit.tag == "Snack")
        {
            if (playerInput.actions["Interact"].ReadValue<float>() > 0)
            {
                inventory.Add(snack);
                Destroy(sphereCast.currentHitObj);
            }
            if (playerInput.actions["Use"].ReadValue<float>() > 0)
            {
                stats.setStaminaPlayer(-20); //add 20 to stamina of player if eat
                Destroy(sphereCast.currentHitObj);
            }
        }
        if(currentHit.tag == "ResearchNote")
        {
            if (playerInput.actions["Interact"].ReadValue<float>() > 0)
            {
                inventory.Add(note);
                noteUI.readNote(note);
                Destroy(sphereCast.currentHitObj);
            }
        }

        if (currentItem.getCurrentSlot().item == null) return;

        if(currentItem.getCurrentSlot().item.title == "Snack")
        {
            if (playerInput.actions["Interact"].triggered)
            {
                inventory.Remove(currentItem.getCurrentSlot().item);
                stats.setStaminaPlayer(-20);
            }
        }
    }
}
