using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollect : MonoBehaviour
{
    public AudioSource collectSource;
    public AudioClip collectSound;
    // Start is called before the first frame update
    void Start()
    {
        collectSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        collectSource.clip = collectSound;
        collectSource.PlayOneShot(collectSound);
        NoteSystem.notes += 1;
        Destroy(gameObject);
    }
}
