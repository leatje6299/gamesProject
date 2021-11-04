using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;

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
        rigidbody.velocity = (((transform.right * mH)*speed) + ((transform.forward * mV) * speed));
        Debug.Log(transform.right * mH);
    }
}
