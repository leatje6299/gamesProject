using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementControl : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    //SOUND
    private AudioSource playerAudio;
    private AudioClip walkOnSnow;
    private AudioClip iceSkate;
    private AudioClip boostSound;
    public AudioClip hitSound;
    public AudioClip steam;

    protected CharacterController _characterController;
    [SerializeField] private PlayerStatManagement stats;
    private Transform _camera;

    public bool skating = false;
    private bool ableSkate = true;
    private Vector3 SkatingVector = new Vector2(0, 0);
    private float skatingSpeed = 0f;
    private float maxSpeed = 5f;
 
    public float mouseSensitivity = 1000f;

    //BOOST
    private bool boostCoolDown = false;
    private float staminaBoost;

    private void Awake()
    {
        skating = true;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _characterController = gameObject.GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        staminaBoost = 4f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        maxSpeed = stats.playerTemp / 2;
        bool slow = playerInput.actions["Slow"].ReadValue<float>() > 0;
        bool boosting = playerInput.actions["Boost"].ReadValue<float>() > 0;
        Vector2 moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
        float mV = moveDirection.x;
        float mH = moveDirection.y;

        
        if(boosting && !boostCoolDown)
        {
            stats.setStaminaPlayer(staminaBoost);  
        }


        transform.rotation = Quaternion.Euler(0,_camera.transform.localRotation.eulerAngles.y, 0);
        if (skating)
        {
            skatingCalculator(mV, mH, slow, boosting);
            skatingMove();
        }
        else
        {
            
            Vector3 tempVec = (transform.forward * mH * Time.deltaTime * 3 + transform.right * mV * Time.deltaTime * 3);
            tempVec.y = -1 * Time.deltaTime;
            _characterController.Move(tempVec);
        }
    }

    void skatingCalculator(float mH, float mV, bool slow, bool boost)
    {
        if (!skating) return; //Guard Statement for Skating
        if (skatingSpeed < 0.1) SkatingVector = new Vector3(0, 0, 0);
        Vector3 temp = (transform.forward * mV + transform.right * mH * 0.1f);
        SkatingVector.Normalize();
        SkatingVector *= 32;
        SkatingVector += temp;
        

        if (boostCoolDown == false && boost == true && stats.playerStamina > 0)
        {
            SkatingVector = transform.forward + transform.right;
            boostCoolDown = true;
            skatingSpeed += 10f;
            playerAudio.PlayOneShot(boostSound);
            startBoostCoolDown();
        }

        if (skatingSpeed > 0 && slow) //Guard Statement for rapid Slow
        {
            skatingSpeed -= 0.5f;
            return;
        } //if Shift pressed, slow down Quickly

        if (skatingSpeed > 20)
        {
            skatingSpeed -= 0.003f;
            return;
        } //if speed is at max, slow down

        if (skatingSpeed < 0.1 &&(mV > 0 || mH > 0))
        {
            skatingSpeed += 4f;
            return;
        }

        if (mV > 0 || mH > 0)
        {
            skatingSpeed += 0.03f;
            return;
        } //if pressing forward, move forward


        if (skatingSpeed < 0)return;

        skatingSpeed -= 0.005f;  //default Slow Down
        
    }
    void skatingMove()
    {
        if (SkatingVector.y > -0.01f)
        {
            SkatingVector.y -= 0.01f;
            print(SkatingVector.y);
        }
        skatingSpeed = Mathf.Clamp(skatingSpeed, 0, maxSpeed);
        _characterController.Move(new Vector3(SkatingVector.normalized.x * skatingSpeed * Time.deltaTime, SkatingVector.y ,SkatingVector.normalized.z * skatingSpeed * Time.deltaTime));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Tree")
        {
            SkatingVector = new Vector3(0,0,0);
            skatingSpeed = 0;
        }
        if (hit.gameObject.tag == "Snow")
        {
            SkatingVector = new Vector3(0, 0, 0);
            skating = false;
            skatingSpeed = 0;
        }
        if (hit.gameObject.tag == "Ice")
        {
            if (!skating) skatingSpeed = 3;
            skating = true;      
        }

        if (hit.gameObject.tag == "SnowBall")
        {
            Vector3 colliderTransform = hit.transform.position;
            Vector3 colliderDirection = (transform.position - colliderTransform).normalized;
            colliderDirection.y = 0;
            SkatingVector = colliderDirection * 2;
            skatingSpeed = 5;
            stats.playerTemp-=2;
            playerAudio.PlayOneShot(hitSound);
            startKnockBackCooldown();
        }
    }
    public void geyserHit(GameObject hit)
    {
        if (ableSkate)
        {
            Vector3 colliderTransform = hit.transform.position;
            Vector3 colliderDirection = (transform.position - colliderTransform).normalized;
            SkatingVector = colliderDirection * 1.5f;
            SkatingVector.y = 10f;
            skatingSpeed = 0;
            print(SkatingVector);
            skatingMove();
            stats.playerTemp -= 2;
            stats.setStaminaPlayer(10);
            playerAudio.PlayOneShot(steam);
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

    public void setStaminaBoost(float newStamBoost)
    {
        staminaBoost = newStamBoost;
    }
}
