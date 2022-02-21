using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenRay : MonoBehaviour
{
    public GameObject currentHitObj;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            currentHitObj = hit.transform.gameObject;
        }
        else
        {
            currentHitObj = null;
        }
    }
}
