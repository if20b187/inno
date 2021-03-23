using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QuestProgress {NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETED, DONE}

    public string title; //quest title
    public int id;
    public QuestProgress progress; //state of the quest
    public string description;
    public string hint;
    public string congratulation;
    public string summery;
    public int nextQuest; //id of next quest

    public string questObjective; //Questitems
    public int questObjectiveCount; //counter
    public int questObjectiveRequirement;

    public string itemReward;
}
