using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem warningEffect;
    [SerializeField] private ParticleSystem geyser;
    [SerializeField] private ParticleSystem geyserActiveWarning;
    [SerializeField] private CapsuleCollider collider;
    private int inactiveTime;
    public bool _enabled = false;

    // Update is called once per frame

    public void enableScript()
    {
        StartCoroutine(inactiveTimer(Random.Range(0, inactiveTime)));
    }
    public void disableScript()
    {
        StopAllCoroutines();
    }
    private void Awake()
    {
        inactiveTime = Random.Range(5, 15);
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
        geyserActiveWarning.Play();
        yield return new WaitForSeconds(5);
        collider.enabled = false;
        StartCoroutine(inactiveTimer(inactiveTime));
    }

}
