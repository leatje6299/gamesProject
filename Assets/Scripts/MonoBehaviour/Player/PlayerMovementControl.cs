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
        skating = true;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _characterController = gameObject.GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool shifted = Input.GetButton("Fire3"); 
        bool boosting = Input.GetButtonDown("Fire1");

        if(boosting && !boostCoolDown)
        {
            stats.setStaminaPlayer(-10f);
        }

        transform.rotation = Quaternion.Euler(0,_camera.transform.localRotation.eulerAngles.y, 0);
        if (!ableSkate)
        {
            horizontal = 0;
            vertical = 0;
            shifted = false;
            boosting = false;
        }
        if (skating) skatingCalculator(horizontal, vertical, shifted, boosting);
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
            print("Yay");
            boostCoolDown = true;
            skatingSpeed += 10f;
            startBoostCoolDown();
        }

        if (skatingSpeed > 0 && shifted) //Guard Statement for rapid Slow
        {
            skatingSpeed -= 0.025f;
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
}
