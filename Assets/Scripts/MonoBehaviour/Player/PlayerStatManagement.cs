using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    public float playerTemp;
    public float playerStamina;

    private float tempTick;
    private float staminaTick;
    [SerializeField]private RespawnManageer respawnMan;

    void Start()
    {
        playerTemp = 37.0f;
        playerStamina = 100f;

        tempTick = 2f;
        staminaTick = 10f;

        StartCoroutine(statTick());
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= tempTick;
        playerStamina -= staminaTick;

        if (playerStamina <= 0)
        {
            respawnMan.respawn();
            playerStamina = 70f;
            playerTemp = 35.0f;
        }

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
        if (playerStamina <= 0)
        {
            respawnMan.respawn();
            playerStamina = 70f;
            playerTemp = 35.0f;
        }
    }
}
