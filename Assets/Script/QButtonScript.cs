using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QButtonScript : MonoBehaviour
{
    public int questID;
    public Text questTitle;

    private GameObject acceptButton;
    //private GameObject giveUpButton;
    private GameObject completeButton;

    public bool showConsole;
    public string input;
    /*
    private QButtonScript acceptButtonScript;
    private QButtonScript giveUpButtonScript;
    private QButtonScript completeButtonScript;

    void Start()
    {
        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Accept").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        giveUpButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("GiveUp").gameObject;
        giveUpButtonScript = giveUpButton.GetComponent<QButtonScript>();

        completeButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Complete").gameObject;
        completeButtonScript = completeButton.GetComponent<QButtonScript>();

        acceptButton.SetActive(false);
        giveUpButton.SetActive(false);
        completeButton.SetActive(false);

    }*/
    

    //JULIAN 
    public void OnToggleDebug()
    {
        showConsole = !showConsole;
    }
    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        if (Event.current.isKey && Event.current.keyCode == KeyCode.Return)
        {
            //if (input.Equals("asd")) { Debug.Log("LOL"); }
            SpawnManager.spawnManager.HandleInput(input);
            input = "";
        } 
    }
    //ENDE JULIAN

    // Show all
    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);

        if (QuestManager.questManager.RequestAvailableQuest(questID))
        {
            QuestUIManager.uiManager.acceptButton.SetActive(true);
            QuestUIManager.uiManager.acceptButtonScript.questID = questID;

        }
        else
        {
            QuestUIManager.uiManager.acceptButton.SetActive(false);
        }


        /*if (QuestManager.questManager.RequestAcceptedQuest(questID))
        {
            QuestUIManager.uiManager.giveUpButton.SetActive(true);
            QuestUIManager.uiManager.giveUpButtonScript.questID = questID;

        }
        else
        {
            QuestUIManager.uiManager.giveUpButton.SetActive(false);
        }*/


        if (QuestManager.questManager.RequestCompleteQuest(questID))
        {
            QuestUIManager.uiManager.completeButton.SetActive(true);
            QuestUIManager.uiManager.completeButtonScript.questID = questID;

        }
        else
        {

            QuestUIManager.uiManager.completeButton.SetActive(false);
        }
    }
    
    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.acceptButton.SetActive(false);
        QuestUIManager.uiManager.HideQuestPanel();

        QuestObject[] currentQuestsNPCS = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestsNPCS)
        {
            obj.SetQuestMarker();
        }
    }
    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        QuestObject[] currentQuestsNPCS = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestsNPCS)
        {
            obj.SetQuestMarker();
        }
        QuestUIManager.uiManager.completeButton.SetActive(false);
    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestPanel();
        QuestUIManager.uiManager.acceptButton.SetActive(false);
        //QuestUIManager.uiManager.giveUpButton.SetActive(false);
        QuestUIManager.uiManager.completeButton.SetActive(false);

    }

    public void ToggleActiveQuestPanel()
    {
        QuestUIManager.uiManager.ToggleActiveQPanel();
    }
    public void ToggleActiveBuchPanel()
    {
        QuestUIManager.uiManager.ToggleActiveBPanel();
    }
    
}
