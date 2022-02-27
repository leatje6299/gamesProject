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
    public float updatedHunger;
    public Image hungerBar;
    public float maxHunger;

    //thirst
    public float updatedThirst;
    public Image thirstBar;
    public float maxThirst;

    public PlayerStatManagement tempStat;

    private void Update()
    {
        //temp
        updatedTemperature = tempStat.getPlayerTemp();
        temperatureBar.fillAmount = updatedTemperature / maxTemperature;

        //hunger 
        updatedHunger = tempStat.getPlayerHunger();
        hungerBar.fillAmount = updatedHunger / maxHunger;

        //thirst
        updatedThirst = tempStat.getPlayerThirst();
        thirstBar.fillAmount = updatedThirst / maxThirst;
    }
}
