using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex == 4)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex == 5)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                popUpIndex += 1;
            }
        }
    }
}
