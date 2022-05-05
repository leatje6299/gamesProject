using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA -- Modified By Sam to edit materials and changed lerp function

public class SnowballScript : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private Vector3 baseScale;
    private Vector3 targetScale;
    private float age = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        //set base scale and target scale
        baseScale = transform.localScale;
        targetScale = baseScale * 30;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        age++;
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetFloat("_node_363", age / 40);
        _renderer.SetPropertyBlock(_propBlock);
        transform.localScale = Vector3.Lerp(baseScale, targetScale, age/1000);
        if (age > 1000) Destroy(gameObject);
    }
}
