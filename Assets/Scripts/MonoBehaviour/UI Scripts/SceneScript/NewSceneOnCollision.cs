using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneOnCollision : MonoBehaviour
{
    [SerializeField] private Note note;
    private Collider _collider;
    private ParticleSystem _particles;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _particles = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (note.order >= 6)
        {
            _particles.Play();
            _collider.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //end scene
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
