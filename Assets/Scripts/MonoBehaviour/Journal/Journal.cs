using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public List<Quest> quests;

    public void QuestCompleted(Quest curQuest)
    {
        if(curQuest.isCompleted == false)
        {
            curQuest.isCompleted = true;
        }
    }
}
