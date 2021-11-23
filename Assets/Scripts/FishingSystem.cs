using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class FishingSystem : MonoBehaviour
{
    public GameObject pole;
    public Transform fishlineStart; //where the fishing line will start from raycast

    //create min and max of fishing (too close to fish - scaring them! OR too far - out of range to fish!)
    public int minFishingDist;
    public int maxFishingDist;

    public bool isInterrupted;
    public bool fishOn;
    public bool canBeFished; //using a tag or smthg? 

    private RaycastHit hit; //info about what the raycast that we made hit

    // Update is called once per frame
    void Update()
    {
        //check that we have a pole and a line start set
        if(pole == null || fishlineStart == null)
        {
            return;
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            ActionListener();
        }
    }

    public void ActionListener()
    {
        //Make sure the player is not doing something else (eating/sitting/photographing)
        if(!playerCanFish)
        {
            return;
        }
        //Make sure the pole is in the hands of player
        if(inventory != fishingPole)
        {
            return;
        }

        //reset state and stop other coroutine before fishing
        BeforeFishing();

        //create Raycast
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //check if the ray hitting water (water isTrigger = yes)
        if()
        {
            Check();
        }
        else
        {
            return;
        }
    }

    private void BeforeFishing()
    {
        //resets state 
        isInterrupted = false;
        fishOn = false;

        StopAllCoroutines();
    }

    private void Check()
    {
        //check that the water is fishable (for example if we had water inside house or smthg
        if(hit.transform.GetComponent<FishingSystem>().canBeFished == false)
        {
            return;
        }
        
        //check that the inventory is not full
        if()
        {
            return;
        }

        //create bobber properties
        GameObject bobberTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bobberTarget.transform.position = hit.point; //The impact point in world space where the ray hit the collider.

        float _dist = Vector3.Distance(transform.position, hit.point);
        if(_dist < minFishingDist)
        {
            Debug.Log("Too close");
            return;
        }
        if(_dist > maxFishingDist)
        {
            Debug.Log("Too far");
            return;
        }

        //Add UI text here? 
        StartCoroutine(Fishing());
    }

    private IEnumerator Fishing()
    {
        //create fishing timer
        havent figured this stuff out yet
    }
}

*/