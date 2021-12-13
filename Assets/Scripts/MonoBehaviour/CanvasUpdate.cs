using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour
{
    public Text playerTempText;
    public Text playerHungerText;
    public Text playerWaterText;
    public Text interactText;
    public PlayerStatManagement stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        playerTempText.text = ((double)stats.playerTemp).ToString();
        playerHungerText.text = stats.playerHunger.ToString();
        playerWaterText.text = stats.playerWater.ToString();
    }
}
