using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List <Quest> questList = new List<Quest>(); //MASTER QUESTLIST
    public List <Quest> currentList = new List<Quest>();

    


    //private var for our Questobject
    void Awake()
    {

        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void QuestRequest(QuestObject NPCQuestObject) 
    {
        if(NPCQuestObject.availableQuestIDs.Count > 0)
        {
            for(int i =0; i< questList.Count; i++)
            {
                for(int j = 0; j< NPCQuestObject.availableQuestIDs.Count; j++)
                {
                    if(questList[i].id == NPCQuestObject.availableQuestIDs[j]&& questList[i].progress == Quest.QuestProgress.AVAILABLE)
                    {
                        Debug.Log("Quest ID:"+ NPCQuestObject.availableQuestIDs[j]+ " "+ questList[i].progress);
                        //TESTING
                        //AcceptQuest(NPCQuestObject.availableQuestIDs[j]);

                        //quest ui manager
                        QuestUIManager.uiManager.questAvailable = true;
                        QuestUIManager.uiManager.availableQuests.Add(questList[i]);

                    }
                }
            }
        }   
        //ACTIVE QUESTS
        for(int i =0;i < currentList.Count; i++)
        {
            for (int j = 0; j< NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if(currentList[i].id == NPCQuestObject.receivableQuestIDs[j] && (currentList[i].progress == Quest.QuestProgress.ACCEPTED || currentList[i].progress == Quest.QuestProgress.COMPLETED))
                {
                    //quest ui manager
                    Debug.Log("Quest ID:" + NPCQuestObject.receivableQuestIDs[j] + " " + questList[i].progress);
                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                }
            }
        }
    }
    //ACCEPT
    public void AcceptQuest(int questID)
    {
        for(int i = 0; i< questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                currentList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
            }
        }
    }

    //Complete

    public void CompleteQuest(int questID)
    {
        for(int i = 0; i <currentList.Count; i++)
        {
            if(currentList[i].id == questID && currentList[i].progress == Quest.QuestProgress.COMPLETED)
            {
                currentList[i].progress = Quest.QuestProgress.DONE;
                //ADD TO DONE LIST FOR REFERENCE
                currentList.Remove(currentList[i]);
                //REWARD


            }
        }
        CheckChainQuest(questID);
    }
    //Check Chain Quest
    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        for (int i = 0; i<questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].nextQuest > 0)
            {
                tempID = questList[i].nextQuest;
            }
        }
        if(tempID > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                if(questList[i].id == tempID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVAILABLE;
                }
            }
        }

    }


    //ADD ITEMS
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i< currentList.Count; i++)
        {
            if(currentList[i].questObjective == questObjective && currentList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentList[i].questObjectiveCount += itemAmount;
            }
            if (currentList[i].questObjectiveCount >= currentList[i].questObjectiveRequirement && currentList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentList[i].progress = Quest.QuestProgress.COMPLETED;
            }

        }
    }

    //REMOVE ITEMS

    // Requests
    public bool RequestAvailableQuest(int questID)
    {
        for(int i = 0; i< questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;

    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETED)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckAvailableQuest(QuestObject NPCQuestObject)
    {
        for(int i =0; i < questList.Count; i++)
        {
            for(int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
            {
                 if(questList[i].id == NPCQuestObject.availableQuestIDs[j]&& questList[i].progress == Quest.QuestProgress.AVAILABLE){
                    return true;
                 }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuest(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool CheckCompletedQuest(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.COMPLETED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ShowQuestLog(int questID)
    {
        for(int i =0;i< currentList.Count;i++)
        {
            if(currentList[i].id == questID)
            {
                QuestUIManager.uiManager.ShowQuestLog(currentList[i]);
            }
        }
    }
}
