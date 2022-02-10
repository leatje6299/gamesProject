using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraTransform;
    public PlayerMovementControl movementScript;



    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        
        float mouseY = Input.GetAxis("Mouse Y") * movementScript.mouseSensitivity * Time.deltaTime;
        print(mouseY);
        transform.LookAt(playerBody);
        print(transform.localPosition);

        transform.position.x = 

    }
}
