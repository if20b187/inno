using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //QuestManager.questManager.AddQuestItem("Neue", 1);
        QuestManager.questManager.AddQuestItem("Ziel", 1);
    }
}