using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    public HelpScreenRay raycastScript;
    [SerializeField]
    private Text KeyBindHelp;

    private void Update()
    {
        /*if(raycastScript.currentHitObj.tag == "Water")
        {
            KeyBindHelp.text = "Press F to fish";
        }
        else
        {
            KeyBindHelp.text = "Press shift to ";
        }*/
    }
}
