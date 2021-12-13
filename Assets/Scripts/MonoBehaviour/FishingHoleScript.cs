using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHoleScript : MonoBehaviour
{
    public CanvasUpdate canvas;
    public PlayerStatManagement stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.interactText.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.interactText.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("f");
            if (stats.inventory[0] == 0)
            {
                stats.inventory[0] = 2;
            } else if (stats.inventory[1] == 0)
            {
                stats.inventory[1] = 2;
            }
            else if (stats.inventory[2] == 0)
            {
                stats.inventory[2] = 2;
            }
            else if (stats.inventory[3] == 0)
            {
                stats.inventory[3] = 2;
            }
            else if (stats.inventory[4] == 0)
            {
                stats.inventory[4] = 2;
            }
        }
    }
}
