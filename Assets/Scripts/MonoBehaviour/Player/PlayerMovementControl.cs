using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip walkOnSnow;
    public AudioClip walkOnIce;
    public AudioClip iceSkate;

    protected CharacterController _characterController;
    public PlayerStatManagement stats;
    private Transform _camera;

    public bool skating = false;
    private Vector3 SkatingVector = new Vector2(0, 0);
    private float skatingSpeed = 0f;
    private float speed = 5f;

    public float mouseSensitivity = 1000f;
    private float xRotation = 0f;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _characterController = gameObject.GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool shifted = Input.GetButton("Fire3");

        //transform.rotation = _camera.transform.localRotation.y;
        transform.rotation = Quaternion.Euler(0,_camera.transform.localRotation.eulerAngles.y, 0);

        if (skating) { skatingCalculator(horizontal, vertical, shifted); }
        else {
            Vector3 moveVect = ((transform.right * horizontal) + (transform.forward * vertical));
            _characterController.Move(new Vector3(moveVect.x, -9.81f, moveVect.z) * Time.deltaTime * speed);
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
        SkatingVector = SkatingVector + new Vector3(0, -0.5f, 0);
        _characterController.Move(SkatingVector.normalized * skatingSpeed * Time.deltaTime);
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ice")
        {
            skating = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerAudio.PlayOneShot(iceSkate);
            }
            return;
        }
        if (hit.gameObject.tag == "Snow")
        {
            skating = false;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                playerAudio.PlayOneShot(walkOnSnow);
            }
            return;
        }
        
    }
}
