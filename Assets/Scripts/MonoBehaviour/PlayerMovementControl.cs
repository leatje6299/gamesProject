using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    protected CharacterController characterController;
    private float speed = 1f;
    public PlayerStatManagement stats;

    private bool skating = true;
    private Vector3 SkatingVector = new Vector2(0, 0);
    private float skatingSpeed = 0f;

    private void Start()
    {
        characterController= gameObject.GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal"); //side to side
        float mV = Input.GetAxis("Vertical"); //forwards and backwards
        bool shifted = Input.GetButton("Fire3");
        //Vector3 temp = ((transform.right * mH) + (transform.forward * mV));
        //characterController.Move(new Vector3(temp.x,-9.81f,temp.z)*Time.deltaTime*speed);
        if (skating == true)
        {
            Vector3 temp = (transform.forward * mV);
            SkatingVector.Normalize();
            SkatingVector *= 10;
            SkatingVector += temp;
            if(skatingSpeed<5 && mV>0 && !shifted)
            {
                skatingSpeed += 0.01f;
            } else if (skatingSpeed > 0 && shifted)
            {
                skatingSpeed -= 0.05f;
            } else if (skatingSpeed > 0)
            {
                skatingSpeed -= 0.01f;
            }
            characterController.Move(SkatingVector.normalized * skatingSpeed * Time.deltaTime);
            if(skatingSpeed <= 0 && SkatingVector.sqrMagnitude != 0) { SkatingVector = Vector3.zero;}
        }
    }

  
}
