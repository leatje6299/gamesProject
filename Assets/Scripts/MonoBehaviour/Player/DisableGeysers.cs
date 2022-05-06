using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGeysers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Geyser")
        {
            other.gameObject.GetComponent<GeyserSpawner>().enableScript();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Geyser")
        {
            other.gameObject.GetComponent<GeyserSpawner>().disableScript();
        }
    }
}
