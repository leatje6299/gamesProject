using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    protected Rigidbody rigidbody;
    public float speed = 2f;
    public PlayerStatManagement stats;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        Vector3 temp = (((transform.right * mH) * speed) + ((transform.forward * mV) * speed));
        rigidbody.velocity = new Vector3(temp.x, rigidbody.velocity.y, temp.z);
    }
  
}
