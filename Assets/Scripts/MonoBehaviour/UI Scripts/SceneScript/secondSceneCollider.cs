using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondSceneCollider : MonoBehaviour
{
    [SerializeField] private RespawnManageer respawnMan;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            respawnMan.level2Ugrade();
            respawnMan.respawn();
        }
    }
}
