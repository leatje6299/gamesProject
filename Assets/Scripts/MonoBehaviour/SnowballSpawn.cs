using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawn : MonoBehaviour
{
    //area of spawn 
    private float spawnSizeArea = 10f;
    [SerializeField]
    private GameObject snowball;
    
    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1,100) < 7)
        {
            SpawnSnowBall();
        }
    }

    private void SpawnSnowBall()
    {
        Vector2 randPos = Random.insideUnitCircle * spawnSizeArea;
        Vector3 newPos = new Vector3(randPos.x, 0, randPos.y) + transform.position;
        
        //change rotation
        Instantiate(snowball,newPos,Quaternion.identity);
    }
}
