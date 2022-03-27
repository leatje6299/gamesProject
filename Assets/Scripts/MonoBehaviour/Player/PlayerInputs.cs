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
    }
}
