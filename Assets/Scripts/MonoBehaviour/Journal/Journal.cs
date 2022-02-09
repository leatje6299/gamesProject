using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//SCRIPT BY LEA
public class Journal : MonoBehaviour
{
    public List<Quest> quests;
    public List<Quest> activeQuests;
    public int curPhase = 1;
    private bool allQuestCompleted;

    [SerializeField]
    private Text quest1;
    [SerializeField]
    private Text quest2;
    [SerializeField]
    private Text quest3;

    public void Start()
    {
        activeQuests.Clear();
        getActiveQuests();
    }

    public void Update()
    {
        showActiveQuests();
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

    public void showActiveQuests()
    {
        print("size" + activeQuests.Count);
        for (int i = 0; i < activeQuests.Count; i += 3)
        {
            if (activeQuests[i] != null)
            {
                quest1.text = activeQuests[i].description;
            }
            if (activeQuests[i + 1] != null)
            {
                quest2.text = activeQuests[i + 1].description;
            }
            if (activeQuests[i + 2] != null)
            {
                quest3.text = activeQuests[i + 2].description;
            }
        }
    }
}
