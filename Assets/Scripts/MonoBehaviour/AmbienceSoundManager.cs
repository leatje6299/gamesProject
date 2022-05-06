using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip ambience1;
    [SerializeField] private AudioClip ambience2;
    [SerializeField] private AudioClip ambience3;
    [SerializeField] private AudioClip ambience4;
    [SerializeField] private AudioClip ambience5;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.015f;
    }
    void Start()
    {
        
        StartCoroutine(startMusic(1));
    }
  
    private IEnumerator startMusic(float n)
    {
        yield return new WaitForSeconds(n);
        audioSource.clip = getRandAudio();
        audioSource.Play();
        StartCoroutine(waitTime());
    }
    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(Random.Range(45,80));
        audioSource.PlayOneShot(getRandAudio());
        StartCoroutine(startMusic(5));
    }

    private AudioClip getRandAudio()
    {
        switch((int)Random.Range(1,6f)) {
            case 1:
                return ambience1;
            case 2:
                return ambience2;
            case 3:
                return ambience3;
            case 4:
                return ambience4;
            default:
                return ambience5;
        }
    }
}
