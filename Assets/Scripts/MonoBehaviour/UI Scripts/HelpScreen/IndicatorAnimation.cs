using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorAnimation : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;

    private void OnEnable()
    {
        LeanTween.moveX(gameObject,transform.position.x, duration).setLoopPingPong();
    }
}
