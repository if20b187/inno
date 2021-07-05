using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript1 : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        
        QuestManager.questManager.AddQuestItem("Goal2", 1);
      

    }
}