using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA

public class PlayerInputs : MonoBehaviour
{
    public SphereCast sphereCast;
    private GameObject currentHit;
    [SerializeField] private GameObject choiceCanvas;

    // Update is called once per frame
    void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;

        if (sphereCast.currentHitObj.tag == "Chest")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                //GameObject choiceCanvas = GameObject.FindGameObjectWithTag("ChoiceCanvas");
                Destroy(sphereCast.currentHitObj.gameObject);
                choiceCanvas.SetActive(true);
            }

        }
    }
}
