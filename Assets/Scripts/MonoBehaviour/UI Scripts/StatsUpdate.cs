using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
    //temperature
    public float updatedTemperature;
    public Image temperatureBar;
    public float maxTemperature;

    //hunger
    public float updatedStamina;
    public Image staminaBar;
    public float maxStamina;

    //thirst
    public float updatedThirst;
    public Image thirstBar;
    public float maxThirst;

    public PlayerStatManagement stat;

    private void Start()
    {
        maxStamina = 100f;
    }

    private void Update()
    {
        //temp
        updatedTemperature = stat.getPlayerTemp();
        temperatureBar.fillAmount = updatedTemperature / maxTemperature;

        //stamina 
        updatedStamina = stat.getPlayerStamina();
        staminaBar.fillAmount = updatedStamina / maxStamina;

        //thirst
        //updatedThirst = stat.getPlayerThirst();
        //thirstBar.fillAmount = updatedThirst / maxThirst;
    }
}
