using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//SCRIPT BY LEA

public class PlayerInputs : MonoBehaviour
{
    public SphereCast sphereCast;
    private GameObject currentHit;

    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private ItemHolder item;
    [SerializeField] private Item snack;
    [SerializeField] private Item note;

    [SerializeField] private ItemSwitch currentItem;
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private PlayerStatManagement stats;
    [SerializeField] private PlayerInput playerInput;

    void Update()
    {
        //print(InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice));
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;

        if (sphereCast.currentHitObj.tag == "Chest")
        {
            if(playerInput.actions["Interact"].ReadValue<float>()>0)
            {
                Destroy(sphereCast.currentHitObj.gameObject);
                choiceCanvas.SetActive(true);
            }

        }
        if(sphereCast.currentHitObj.tag == "Snack")
        {
            if (playerInput.actions["Interact"].ReadValue<float>() > 0)
            {
                item.Add(snack);
                Destroy(sphereCast.currentHitObj);
            }
            if (playerInput.actions["Use"].ReadValue<float>() > 0)
            {
                stats.setStaminaPlayer(-20); //add 20 to stamina of player if eat
                Destroy(sphereCast.currentHitObj);
            }
        }
        if(sphereCast.currentHitObj.tag == "ResearchNote")
        {
            if (playerInput.actions["Interact"].ReadValue<float>() > 0)
            {
                item.Add(note);
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
