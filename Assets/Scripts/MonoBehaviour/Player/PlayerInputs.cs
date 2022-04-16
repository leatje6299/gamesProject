using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//SCRIPT BY LEA

public class PlayerInputs : MonoBehaviour
{
    private PlayerControls playerControls;

    public SphereCast sphereCast;
    private GameObject currentHit;

    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private ItemHolder item;
    [SerializeField] private Item snack;
    [SerializeField] private Item note;
    [SerializeField] private PlayerStatManagement stamina;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;

        if (sphereCast.currentHitObj.tag == "Chest")
        {
            if(playerControls.Game.Interact.ReadValue<float>()>0)
            {
                //GameObject choiceCanvas = GameObject.FindGameObjectWithTag("ChoiceCanvas");
                Destroy(sphereCast.currentHitObj.gameObject);
                choiceCanvas.SetActive(true);
            }

        }
        if(sphereCast.currentHitObj.tag == "Snack")
        {
            if(playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                item.Add(snack);
                Destroy(sphereCast.currentHitObj);
            }
            if(playerControls.Game.Use.ReadValue<float>() > 0)
            {
                stamina.setStaminaPlayer(-20); //add 20 to stamina of player if eat
                Destroy(sphereCast.currentHitObj);
            }
        }
        if(sphereCast.currentHitObj.tag == "ResearchNote")
        {
            if(playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                item.Add(note);
                Destroy(sphereCast.currentHitObj);
            }
        }
    }
}
