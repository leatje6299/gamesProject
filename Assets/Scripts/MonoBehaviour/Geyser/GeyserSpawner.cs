using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem warningEffect;
    [SerializeField] private ParticleSystem geyser;
    private CapsuleCollider collider;
    private int inactiveTime;

    // Update is called once per frame

    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        inactiveTime = Random.Range(5,15);
        StartCoroutine(inactiveTimer(Random.Range(0,inactiveTime)));
    }

    private IEnumerator inactiveTimer(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(warningTimer());
        
    }
    private IEnumerator warningTimer()
    {
        warningEffect.Play();
        yield return new WaitForSeconds(5);
        StartCoroutine(geyserTimer());
    }
    private IEnumerator geyserTimer()
    {
        collider.enabled = true;
        geyser.Play();
        yield return new WaitForSeconds(5);
        collider.enabled = false;
        StartCoroutine(inactiveTimer(inactiveTime));
    }

}
