using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private Camera _camera;
    private double speed;
    private Vector3 direction = new Vector3(0,0,0);

    // Start is called before the first frame update
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        //_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = _camera.transform.localRotation;

    }
}
