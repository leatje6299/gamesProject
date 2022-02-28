using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    private float playerTemp;
    private int playerHunger;
    private float playerWater;

    private float tempTick;
    private int hungerTick;
    private float waterTick;

    void Start()
    {
        playerTemp = 37.0f;
        playerHunger = 100;
        playerWater = 100f;

        tempTick = 2f;
        hungerTick = 1;
        waterTick = 1f;

        StartCoroutine(statTick());
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= tempTick;
        playerHunger -= hungerTick;
        playerWater -= waterTick;

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

    public void setPlayerThirst(float thirstAmount)
    {
        playerWater += thirstAmount;
    }

    public void setTempTick(float newTempTick)
    {
        tempTick = newTempTick;
    }
}
