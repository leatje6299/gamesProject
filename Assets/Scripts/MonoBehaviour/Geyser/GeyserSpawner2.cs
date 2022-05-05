using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserSpawner2 : MonoBehaviour
{
    private float spawnSizeArea = 10f;
    [SerializeField] private BoxCollider bc;
    [SerializeField] private GameObject geyserSpawn;

    Vector3 cubeSize;
    Vector3 cubeCenter;
    // Start is called before the first frame update
    void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
        cubeSize.z = cubeTrans.localScale.z * bc.size.z;

        for (int i = 0;i<100;i++)
        {
            SpawnGeyserSpwner();
        }
    }

    // Update is called once per frame

    private void SpawnGeyserSpwner()
    {
        //change rotation
        Instantiate(geyserSpawn, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
        // Right now, the center of the prefab could be right on the extents of the box
        Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2), Random.Range(-cubeSize.z / 2, cubeSize.z / 2));

        return cubeCenter + randomPosition;
    }
}
