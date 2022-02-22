using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    public SphereCast sphereCast;
    [SerializeField]
    private Text KeyBindHelp;

    private void Update()
    {
        if(sphereCast.currentHitObj.tag == "Water")
        {
            KeyBindHelp.text = "Press F to fish";
        }
        else
        {
            KeyBindHelp.text = "Press shift to ";
        }
    }
}
