using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishingSystem : MonoBehaviour
{ /*
    public Inventory inventory;
   // public GameObject pole;
  // public Transform fishlineStart; //where the fishing line will start from raycast

    
    //create min and max of fishing (too close to fish - scaring them! OR too far - out of range to fish!)
    public int minFishingDist;
    public int maxFishingDist;

    public bool isInterrupted;
    public bool fishOn;
    public bool canBeFished; //using a tag or smthg? 
    public bool playerCanFish = true;

    private RaycastHit hit; //info about what the raycast that we made hit

    // Update is called once per frame
    void Update()
    {
        //check that we have a pole and a line start set
        if(inventory == 0)
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
        if(inventory)
        {
            return;
        }

        //reset state and stop other coroutine before fishing
        BeforeFishing();

        //create Raycast
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //check if the ray hitting water (water isTrigger = yes)
        if(Physics.Raycast(_ray, fwd, 5))
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
        if (inventory.invFull == false)
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
        float randomTime = Random.Range(5, 10);
        yield return new WaitForSeconds(randomTime);

        //Add UI for !
        StartCoroutine(FishingTimer());
        int keyNum = 0;
        if (Input.GetKeyDown(KeyCode.F))
        {
            keyNum++;
        }

        if (keyNum >= 15)
        {
            StopCoroutine(FishingTimer());
            //start fishing animation
        }

        //create fishing timer

    }
    private IEnumerator FishingTimer()
    {
        yield return new WaitForSeconds(3);
    }
}

 */

    public SphereCast sphereCastScript;
    private bool fishingStatus = false; //could use an integer for this or enum
    private bool reaction = false;
    private int reeling = 0;
    void Update()
    {
        //check that we have a fishing pole
        //
        //
        //

        if (Input.GetKeyDown(KeyCode.F) && fishingStatus == false && sphereCastScript.currentHitObj != null)
        {
            //Debug.Log("F detected");
            if (sphereCastScript.currentHitObj.tag == "Water")
            {
                InitiateFishing();
            }
        }
        if (fishingStatus)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (reaction)
                {
                    reaction = false;
                    StopCoroutine(ReactTime());
                    Debug.Log("Fish Inbound, SPAM F!");
                    reeling++;
                    StartCoroutine(ReelTime());
                }
                if (reeling > 0)
                {
                    if(reeling < 15)
                    {
                        reeling++;
                    } else
                    {
                        Debug.Log("You Caught A Fish");
                        StopCoroutine(ReelTime());
                        reeling = 0;
                        fishingStatus = false;

                    }
                }
            }
            
        }
    }

    private void InitiateFishing()
    {
        Debug.Log("Fishing" );
        fishingStatus = true;
        StartCoroutine(BiteWait(5));
    }

    private IEnumerator BiteWait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log(time);
        StartCoroutine(ReactTime());
    }
    private IEnumerator ReactTime()
    {
        reaction = true;
        yield return new WaitForSeconds(1f);

        if (reaction == true)
        {
            Debug.Log("You Left It too long");
        }

        reaction = false;
    }
    private IEnumerator ReelTime()
    {
        reeling = 1;
        yield return new WaitForSeconds(6);
        Debug.Log("the fish got away");
        reeling = 0;
        fishingStatus = false;
    }

}