using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCOllectedNumberUI : MonoBehaviour
{
    private Text text;
    [SerializeField] private Note note;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =note.order.ToString() + "/3";
        if (note.order == 3 || note.order == 6)
        {
            text.color = Color.green;
            
        } else
        {
            text.color = Color.white;
        }
    }
}
