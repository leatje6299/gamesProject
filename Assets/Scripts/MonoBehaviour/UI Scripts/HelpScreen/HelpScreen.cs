using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script by Lea

public class HelpScreen : MonoBehaviour
{
    public SphereCast sphereCast;
    [SerializeField]
    private Text keyBindHelp1;
    [SerializeField]
    private Text keyBindHelp2;
    [SerializeField]
    private Text keyBindHelpMiddle;
    private GameObject currentHit;

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if(sphereCast.currentHitObj.tag == "Water")
        {
            keyBindHelpMiddle.text = "[F] Fish";
            return;
        }
        if (sphereCast.currentHitObj.tag == "Chest")
        {
            keyBindHelpMiddle.text = "[F] Open";
            return;
        }
        if(sphereCast.currentHitObj.tag == "ResearchNote" || sphereCast.currentHitObj.tag == "ResearchNote2" || sphereCast.currentHitObj.tag == "ResearchNote3" || sphereCast.currentHitObj.tag == "ResearchNote4")
        {
            keyBindHelpMiddle.text = "[F] Pick up";
            return;
        }
        if(sphereCast.currentHitObj.tag == "Snack")
        {
            keyBindHelpMiddle.text = "[F] Pick up \r\n [E] Eat";
        }
        else
        {
            keyBindHelp1.text = "[CTRL] Slow down";
            keyBindHelp2.text = "[SHIFT] Boost";
            keyBindHelpMiddle.text = "";
            return;
        }
    }
}
