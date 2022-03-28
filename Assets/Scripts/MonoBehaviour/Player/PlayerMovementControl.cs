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
    private float maxSpeed = 5f;
 

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
        maxSpeed = stats.playerTemp / 2;
        bool shifted = playerControls.Game.Slow.ReadValue<float>() > 0;
        bool boosting = playerControls.Game.Boost.ReadValue<float>() > 0;
        Vector2 moveDirection = playerControls.Game.Move.ReadValue<Vector2>();
        float mV = moveDirection.x;
        float mH = moveDirection.y;
        
        if(boosting && !boostCoolDown)
        {
            stats.setStaminaPlayer(4f);  
        }

        //print(shifted);

        transform.rotation = Quaternion.Euler(0,_camera.transform.localRotation.eulerAngles.y, 0);
        if (skating) skatingCalculator(mV, mH, shifted, boosting);
        else _characterController.Move(transform.forward * mH * Time.deltaTime * 3+ transform.right * mV * Time.deltaTime * 3);
    }

    void skatingCalculator(float mH, float mV, bool shifted, bool boost)
    {
        if (!skating) return; //Guard Statement for Skating

        Vector3 temp = (transform.forward * mV + transform.right * mH * 0.1f);
        SkatingVector.Normalize();
        SkatingVector *= 30;
        SkatingVector += temp;
        

        if (boostCoolDown == false && boost == true && stats.playerStamina > 0)
        {
            boostCoolDown = true;
            skatingSpeed += 10f;
            playerAudio.PlayOneShot(boostSound);
            startBoostCoolDown();
        }

        if (skatingSpeed > 0 && shifted) //Guard Statement for rapid Slow
        {
            print("SLOW");
            skatingSpeed -= 0.1f;
            skatingMove();
            return;
        } //if Shift pressed, slow down Quickly

        if (skatingSpeed > 20)
        {
            skatingSpeed -= 0.003f;
            skatingMove();
            return;
        } //if speed is at max, slow down

        if (skatingSpeed < 0.1 &&(mV > 0 || mH > 0))
        {
            skatingSpeed += 4f;
            skatingMove();
            return;
        }

        if (mV > 0 || mH > 0)
        {
            skatingSpeed += 0.03f;
            skatingMove();
            return;
        } //if pressing forward, move forward


        if (skatingSpeed < 0)return;

        skatingSpeed -= 0.005f;  //default Slow Down
        skatingMove(); 
    }
    void skatingMove()
    {
        skatingSpeed = Mathf.Clamp(skatingSpeed, 0, maxSpeed);
        _characterController.Move(new Vector3(SkatingVector.normalized.x * skatingSpeed * Time.deltaTime, -9.8f ,SkatingVector.normalized.z * skatingSpeed * Time.deltaTime));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.tag == "Ice")
        {
            skating = true;
            /* this is broken...
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
            */
        }
            if (hit.gameObject.tag == "Snow")
        {
            skating = false;
            skatingSpeed = 0;
            /*
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                playerAudio.clip = walkOnSnow;
                playerAudio.PlayOneShot(walkOnSnow);
                StartCoroutine(playSnowSound());
            }
            return;
            */
        }
        
        if (hit.gameObject.tag == "SnowBall")
        {
            Vector3 colliderTransform = hit.transform.position;
            Vector3 colliderDirection = (transform.position - colliderTransform).normalized;
            colliderDirection.y = 0;
            SkatingVector = colliderDirection * 2;
            skatingSpeed = 5;
            stats.playerTemp-=2;
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
