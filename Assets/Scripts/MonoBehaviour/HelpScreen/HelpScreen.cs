using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    public SphereCast sphereCast;
    [SerializeField]
    private Text keyBindHelp;
    private GameObject currentHit;

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if(sphereCast.currentHitObj.tag == "Water")
        {
            keyBindHelp.text = "Press F to fish";
            return;
        }
        if (sphereCast.currentHitObj.tag == "Chest")
        {
            keyBindHelp.text = "Press F to open";
            return;
        }
        else
        {
            keyBindHelp.text = "Press shift to ";
            return;
        }
    }
}
