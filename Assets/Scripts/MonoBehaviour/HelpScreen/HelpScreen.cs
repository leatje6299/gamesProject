using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    public SphereCast sphereCast;
    [SerializeField]
    private Text KeyBindHelp;
    private GameObject currentHit;

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if(sphereCast.currentHitObj.tag == "Water")
        {
            KeyBindHelp.text = "Press F to fish";
            return;
        }
        else
        {
            KeyBindHelp.text = "Press shift to ";
            return;
        }
    }
}
