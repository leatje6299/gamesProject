using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    protected CharacterController _characterController;
    public PlayerStatManagement stats;

    public bool skating = false;
    private Vector3 SkatingVector = new Vector2(0, 0);
    private float skatingSpeed = 0f;
    private float speed = 5f;

    public float mouseSensitivity = 1000f;
    private float xRotation = 0f;

    private void Start()
    {
        _characterController= gameObject.GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        

        transform.Rotate(Vector3.up * mouseX);

        float mH = Input.GetAxis("Horizontal"); //side to side
        float mV = Input.GetAxis("Vertical"); //forwards and backwards
        bool shifted = Input.GetButton("Fire3");

        if (skating) skatingCalculator(mH, mV, shifted);
        else {
            Vector3 temp = ((transform.right * mH) + (transform.forward * mV));
            _characterController.Move(new Vector3(temp.x, -9.81f, temp.z) * Time.deltaTime * speed);
        }
    }

    void skatingCalculator(float mH, float mV, bool shifted)
    {
        if (!skating) return; //Guard Statement for Skating

        Vector3 temp = (transform.forward * mV);
        SkatingVector.Normalize();
        SkatingVector *= 5;
        SkatingVector += temp;

        if (skatingSpeed > 20)
        {
            skatingSpeed -= 0.03f;
            skatingMove();
            return;
        } //if speed is at max, slow down
  
        if (mV > 0)
        {
            skatingSpeed += 0.03f;
            skatingMove();
            return;
        } //if pressing forward, move forward

        if (skatingSpeed < 0) return; //Guard Statement for speed being <0

        if (shifted)
        {
            skatingSpeed -= 0.1f;
            skatingMove();
            return;
        } //if Shift pressed, slow down Quickly

        skatingSpeed -= 0.05f;  //default Slow Down
        skatingMove(); 
    }
    void skatingMove()
    {
        _characterController.Move(SkatingVector.normalized * skatingSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ice")
        {
            skating = true;
            return;
        }
        if (hit.gameObject.tag == "Snow")
        {
            skating = false;
            return;
        }
        
    }
}
