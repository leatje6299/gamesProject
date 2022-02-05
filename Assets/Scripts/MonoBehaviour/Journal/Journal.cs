using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public List<Quest> quests;
    public List<Quest> activeQuests;
    public int curPhase = 1;
    private bool allQuestCompleted;
    public Quest quest1;

    public void Start()
    {
        activeQuests.Clear();
        QuestCompleted(quest1);
        print("start" + activeQuests.Count);
    }

    public void QuestCompleted(Quest curQuest)
    {
        if(curQuest.isCompleted == false && curQuest.isActive == true)
        {
            curQuest.isCompleted = true;
        }
        IsPhaseCompleted();
    }

    public void IsPhaseCompleted()
    {
        getActiveQuests();

        foreach(Quest quest in activeQuests)
        {
            if(quest.isCompleted == false)
            {
                print("Phase not completed");
                allQuestCompleted = false;
                return;
            }
            else
            {
                allQuestCompleted = true;
            }
        }

        NextPhase();
    }

    public void NextPhase()
    {
        if (allQuestCompleted)
        {
            curPhase += 1;
            foreach (Quest quest in activeQuests)
            {
                quest.isActive = false;
            }
            foreach (Quest quest in quests)
            {
                if (quest.phase == curPhase)
                {
                    quest.isActive = true;
                    activeQuests.Clear();
                    activeQuests.Add(quest);
                }
            }
        }
    }

    public void getActiveQuests()
    {
        for(int i = 0; i < quests.Count; i++)
        {
            if(quests[i].isActive)
            {
                activeQuests.Add(quests[i]);
            }    
        }
    }
}
