using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    public float playerTemp;
    private int playerHunger;
    private float playerWater;
    private float playerStamina;

    private float tempTick;
    private int hungerTick;
    private float waterTick;
    private float staminaTick;

    void Start()
    {
        playerTemp = 37.0f;
        playerHunger = 100;
        playerWater = 100f;
        playerStamina = 100f;

        tempTick = 2f;
        hungerTick = 1;
        waterTick = 1f;
        staminaTick = 10f;

        StartCoroutine(statTick());
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= tempTick;
        playerHunger -= hungerTick;
        playerWater -= waterTick;
        playerStamina -= staminaTick;

        print(playerStamina);

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

    public float getPlayerStamina()
    {
        return playerStamina;
    }

    public void setStaminaTick(float newStaminaTick)
    {
        staminaTick = newStaminaTick;
    }

    public void setStaminaPlayer(float staminaAmount)
    {
        playerStamina -= staminaAmount;
    }
}
