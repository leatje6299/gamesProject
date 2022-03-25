using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementControl : MonoBehaviour
{
    private PlayerControls playerControls;

    private AudioSource playerAudio;
    public AudioClip walkOnSnow;
    public AudioClip iceSkate;
    public AudioClip boostSound;

    protected CharacterController _characterController;
    [SerializeField] private PlayerStatManagement stats;
    private Transform _camera;

    public bool skating = false;
    private bool ableSkate = true;
    private Vector3 SkatingVector = new Vector2(0, 0);
    private float skatingSpeed = 0f;
    private float speed = 5f;

    public float mouseSensitivity = 1000f;
    private float xRotation = 0f;
    private bool boostCoolDown = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
        skating = true;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _characterController = gameObject.GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //InputSystem.Enable();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable() 
    {
        playerControls.Disable();
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        bool shifted = playerControls.Game.Slow.ReadValue<bool>();
        bool boosting = playerControls.Game.Boost.ReadValue<bool>();
        Vector2 moveDirection = playerControls.Game.Move.ReadValue<Vector2>();
        
        if(boosting && !boostCoolDown)
        {
            stats.setStaminaPlayer(4f);
        }
        

        transform.rotation = Quaternion.Euler(0,_camera.transform.localRotation.eulerAngles.y, 0);
        if (skating) skatingCalculator(moveDirection.x, moveDirection.y, shifted, boosting);
    }

    void skatingCalculator(float mH, float mV, bool shifted, bool boost)
    {
        if (!skating) return; //Guard Statement for Skating

        Vector3 temp = (transform.forward * mV + transform.right * mH * 0.1f);
        SkatingVector.Normalize();
        SkatingVector *= 30;
        SkatingVector += temp;


        if (boostCoolDown == false && boost == true)
        {
            boostCoolDown = true;
            skatingSpeed += 10f;
            playerAudio.PlayOneShot(boostSound);
            startBoostCoolDown();
        }

        if (skatingSpeed > 0 && shifted) //Guard Statement for rapid Slow
        {
            skatingSpeed -= 0.04f;
            skatingMove();
            return;
        } //if Shift pressed, slow down Quickly

        if (skatingSpeed > 20)
        {
            skatingSpeed -= 0.003f;
            skatingMove();
            return;
        } //if speed is at max, slow down
  
        if (mV > 0 || mH > 0)
        {
            skatingSpeed += 0.003f;
            skatingMove();
            return;
        } //if pressing forward, move forward


        if (skatingSpeed < 0)return;

        skatingSpeed -= 0.005f;  //default Slow Down
        skatingMove(); 
    }
    void skatingMove()
    {

        _characterController.Move(new Vector3(SkatingVector.normalized.x * skatingSpeed * Time.deltaTime, -9.8f ,SkatingVector.normalized.z * skatingSpeed * Time.deltaTime));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ice")
        {
            skating = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                print(skatingSpeed);
                if (skatingSpeed >= 1)
                {
                    playerAudio.PlayOneShot(iceSkate);
                    StartCoroutine(playIceSound());
                }
            }
            return;
        }
        if (hit.gameObject.tag == "Snow")
        {
            skating = false;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                playerAudio.clip = walkOnSnow;
                playerAudio.PlayOneShot(walkOnSnow);
                StartCoroutine(playSnowSound());
            }
            return;
        }
        
        if (hit.gameObject.tag == "SnowBall")
        {
            Vector3 colliderTransform = hit.transform.position;
            Vector3 colliderDirection = (transform.position - colliderTransform).normalized;
            colliderDirection.y = 0;
            SkatingVector = colliderDirection * 2;
            skatingSpeed = 5;
            startKnockBackCooldown();
        }
       
    }

    private void startBoostCoolDown()
    {
        StartCoroutine(BoostCoolDown());
    }
    private IEnumerator BoostCoolDown()
    {
        yield return new WaitForSeconds(5);
        boostCoolDown = false;
    }

    private void startKnockBackCooldown()
    {
        StartCoroutine(KnockBackCooldown());
    }
    private IEnumerator KnockBackCooldown()
    {
        ableSkate = false;
        yield return new WaitForSeconds(2);
        ableSkate = true;
    }
    private IEnumerator playIceSound()
    {
        yield return new WaitForSeconds(30);
    }
    private IEnumerator playSnowSound()
    {
        yield return new WaitForSeconds(3);
    }
}
