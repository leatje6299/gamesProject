using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//Script by Lea

public class HelpScreen : MonoBehaviour
{
    private PlayerControls playerControls;

    public SphereCast sphereCast;
    [SerializeField]
    private Text keyBindHelp1;
    [SerializeField]
    private Text keyBindHelp2;
    [SerializeField]
    private Text keyBindHelpMiddle;
    private GameObject currentHit;

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

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if (sphereCast.currentHitObj.tag == "Chest")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Open";
            return;
        }
        if(sphereCast.currentHitObj.tag == "ResearchNote")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Pick up";
            return;
        }
        if(sphereCast.currentHitObj.tag == "Snack")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Pick up \r\n [" + InputControlPath.ToHumanReadableString(playerControls.Game.Use.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Eat";
        }
        else
        {
            keyBindHelp1.text = "[" + InputControlPath.ToHumanReadableString(playerControls.Game.Slow.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Slow down";
            keyBindHelp2.text = "[" + InputControlPath.ToHumanReadableString(playerControls.Game.Boost.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Boost";
            keyBindHelpMiddle.text = "";
            return;
        }
    }
}
