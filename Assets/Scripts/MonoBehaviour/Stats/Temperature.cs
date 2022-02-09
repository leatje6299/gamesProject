using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//SCRIPT BY LEA

public class Temperature : MonoBehaviour
{
    public float updatedTemperature;
    public Image temperatureBar;
    public float maxTemperature;

    public PlayerStatManagement tempStat;

    private void Update()
    {
        updatedTemperature = tempStat.getPlayerTemp();
        print(updatedTemperature);
        temperatureBar.fillAmount = updatedTemperature / maxTemperature;
    }
}
