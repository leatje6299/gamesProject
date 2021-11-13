using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManagement : MonoBehaviour
{
    public double playerTemp;
    public int playerHunger;
    public int playerWater;
    public CanvasUpdate canvas;
   // private enum Utenisls {FishingPole, Food, Water, None};
    private List<int> inventory;
    // Start is called before the first frame update
    void Start()
    {
        playerTemp = 37.0f;
        playerHunger = 100;
        playerWater = 100;
 /*
        inventory[0] = 0;
        inventory[1] = 0;
        inventory[3] = 0;
        inventory[4] = 0;
        inventory[5] = 0;
        inventory[6] = 0;
        inventory[7] = 0;
        inventory[8] = 0;
        inventory[9] = 0;
 */

        StartCoroutine(statTick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator statTick()
    {
        playerTemp -= 0.2f;
        playerHunger -= 1;
        playerWater -= 1;
        canvas.UpdateText();
        yield return new WaitForSeconds(4);
        StartCoroutine(statRestart());
    }
    private IEnumerator statRestart()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(statTick());
    }
}
