using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManageer : MonoBehaviour
{
    [SerializeField] private Transform respawn1;
    [SerializeField] private Transform respawn2;
    private CharacterController controller;

    private Transform curRespawn;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        curRespawn = respawn1;
    }
    public void level2Ugrade()
    {
        curRespawn = respawn2;
    }
    // Start is called before the first frame update
    public void respawn()
    {
        controller.enabled = false;
        controller.transform.position = new Vector3(curRespawn.position.x, curRespawn.position.y, curRespawn.position.z);
        controller.enabled = true;    
    }
    
}
