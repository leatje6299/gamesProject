using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    public float playerTemp;
    public int playerHunger;
    public int playerWater;

   
    void Start()
    {
        playerTemp = 37.0f;
        playerHunger = 100;
        playerWater = 100;

        StartCoroutine(statTick());
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= 0.2f;
        playerHunger -= 1;
        playerWater -= 1;

        yield return new WaitForSeconds(4);
        StartCoroutine(statRestart());
    }
    private IEnumerator statRestart()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(statTick());
    }

    public float getPlayerTemp()
    {
        return playerTemp;
    }

    public float getPlayerHunger()
    {
        return playerHunger;
    }

    public float getPlayerThirst()
    {
        return playerWater;
    }
}
