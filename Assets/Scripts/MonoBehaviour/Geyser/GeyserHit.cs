using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserHit : MonoBehaviour
{
    PlayerMovementControl playerMoveScript;
    // Start is called before the first frame update

    private void Awake()
    {
        playerMoveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControl>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject.GetComponent<Collider>());
            playerMoveScript.geyserHit(gameObject);
        }
    }
}
