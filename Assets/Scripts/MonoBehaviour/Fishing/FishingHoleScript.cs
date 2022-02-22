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

    }
}
