using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    public SphereCast sphereCast;
    [SerializeField]
    private Text keyBindHelp1;
    [SerializeField]
    private Text keyBindHelp2;
    private GameObject currentHit;

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if(sphereCast.currentHitObj.tag == "Water")
        {
            keyBindHelp1.text = "Press F to fish";
            return;
        }
        if (sphereCast.currentHitObj.tag == "Chest")
        {
            keyBindHelp1.text = "Press F to open";
            return;
        }
        if(sphereCast.currentHitObj.tag == "ResearchNote" || sphereCast.currentHitObj.tag == "ResearchNote2" || sphereCast.currentHitObj.tag == "ResearchNote3" || sphereCast.currentHitObj.tag == "ResearchNote4")
        {
            keyBindHelp1.text = "Press F to pick up";
            return;
        }
        else
        {
            keyBindHelp1.text = "Press CTRL to slow down";
            keyBindHelp2.text = "Press shift for a boost";
            return;
        }
    }
}
