using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondSceneCollider : MonoBehaviour
{
    [SerializeField] private RespawnManageer respawnMan;
    [SerializeField] private Note note;
    private Collider collider;
    private ParticleSystem particles;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        particles = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if(note.order >= 3)
        {
            particles.Play();
            collider.enabled = true;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            respawnMan.level2Ugrade();
            respawnMan.respawn();
        }
    }
}
