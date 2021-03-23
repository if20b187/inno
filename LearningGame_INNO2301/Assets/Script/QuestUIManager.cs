using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager uiManager;

    //BOOLS
    public bool questAvailable = false;
    public bool questRunning = false;
    public bool questPanelActive = false;
    public bool questLogPanelActive = false;
    public bool buchPanelActive = false;

    //Panels
    public GameObject questPanel;
    public GameObject questLogPanel;
    public GameObject buchPanel;
    //QuestObject
    private QuestObject currentQuestObject;
    

    //Questlists
    public List<Quest> availableQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();

    //Buttons
    public GameObject qButton;
    public GameObject qLogButton;
    private List<GameObject> qButtons = new List<GameObject>();

    public GameObject acceptButton;
    public GameObject giveUpButton;
    public GameObject completeButton;

    //Spacer
    public Transform qButtonSpacer1;//available
    public Transform qButtonSpacer2;//active
    public Transform qLogButtonSpacer;//active in qLog

    //INFOS
    public Text questTitle;
    public Text questDescription;
    public Text questSummary;
    public GameObject rewardsTag;
    public GameObject rewardsLogTag;
    //Log INFOS
    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;
    //
    public QButtonScript acceptButtonScript;
    //public QButtonScript giveUpButtonScript;
    public QButtonScript completeButtonScript;

    void Start()
    {
        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Accept").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        giveUpButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("GiveUp").gameObject;
        giveUpButton.SetActive(false);
        //giveUpButtonScript = giveUpButton.GetComponent<QButtonScript>();

        completeButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Complete").gameObject;
        completeButtonScript = completeButton.GetComponent<QButtonScript>();

        acceptButton.SetActive(false);
        //giveUpButton.SetActive(false);
        completeButton.SetActive(false);

        rewardsTag.SetActive(false);
        rewardsLogTag.SetActive(false);

        questLogTitle.text = "";
        questLogDescription.text = "";
        questLogSummary.text = "";

    }
    void Awake()
    {
        if(uiManager == null)
        {
            uiManager = this;
        }else if (uiManager != this)
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);
        HideQuestPanel();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HideBuchPanel();
            ToggleActiveQPanel();
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            HideQuestLogPanel();
            HideQuestPanel();
            ToggleActiveBPanel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideQuestPanel();
            HideQuestLogPanel();
            HideBuchPanel();
            acceptButton.SetActive(false);
            completeButton.SetActive(false);
        }


    }

    public void ToggleActiveQPanel()
    {
        questLogPanelActive = !questLogPanelActive;
        ShowQuestLogPanel();
    }
    public void ToggleActiveBPanel()
    {
        buchPanelActive = !buchPanelActive;
        buchPanel.SetActive(buchPanelActive);
    }
   
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if((questRunning || questAvailable) && !questPanelActive)
        {
            ShowQuestPanel();
        }
        else
        {
            Debug.Log("No Quests Available");
        }
    }
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        //FILL DATA
        FillQuestButton();
    }
    public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(questLogPanelActive);
        if(questLogPanelActive && !questPanelActive)
        {
            foreach (Quest currQuest in QuestManager.questManager.currentList)
            {
                GameObject questButton = Instantiate(qLogButton);
                QLogButtonScript qbutton = questButton.GetComponent<QLogButtonScript>();
                qbutton.questID = currQuest.id;
                qbutton.questTitle.text = currQuest.title;
                questButton.transform.SetParent(qLogButtonSpacer, false);
                qButtons.Add(questButton);
            }
        }
        else if(!questLogPanelActive && !questPanelActive)
        {
            HideQuestLogPanel();
        }
    }
    public void ShowQuestLog(Quest activeQuest)
    {
        questLogTitle.text = activeQuest.title;
        if (activeQuest.progress == Quest.QuestProgress.ACCEPTED)
        {
            questLogDescription.text = activeQuest.hint;

        }else if (activeQuest.progress == Quest.QuestProgress.COMPLETED) {
            questLogDescription.text = activeQuest.congratulation;
        }
    

    }

    //HIDEQuestPanel
    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        questTitle.text = "";
        questDescription.text = "";
        //questSummary.text="";

        availableQuests.Clear();
        activeQuests.Clear();
        for(int i = 0; i< qButtons.Count; i++)
        {
            Destroy(qButtons[i]);

        }
        qButtons.Clear();
        questPanel.SetActive(questPanelActive);

          
    }
    public void HideBuchPanel()
    {
        buchPanel.SetActive(false);

    }
    public void HideQuestLogPanel()
    {
        questLogPanelActive = false;
        questLogTitle.text = "";
        questLogDescription.text = "";
        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);

        }
        qButtons.Clear();
        questLogPanel.SetActive(questLogPanelActive);

    }

    void FillQuestButton()
    {
        foreach(Quest availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.title;
            questButton.transform.SetParent(qButtonSpacer1, false);
            qButtons.Add(questButton);
        }
        foreach (Quest activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.title;
            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }
    }
    public void ShowSelectedQuest(int questID)
    {
        for (int i= 0; i < availableQuests.Count; i++)
        {
            if(availableQuests[i].id == questID)
            {
                questTitle.text = availableQuests[i].title;
                if(availableQuests[i].progress == Quest.QuestProgress.AVAILABLE)
                {
                    questDescription.text = availableQuests[i].description;
                    //questSummary.text = availableQuests[i].questObjective + " : " + availableQuests[i].questObjectiveRequirement;


                }
            }
        }
        for (int i = 0; i< activeQuests.Count; i++)
        {
            if(activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].title;
                if(activeQuests[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    questDescription.text = activeQuests[i].hint;
                    //questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + "/" + activeQuests[i].questObjectiveRequirement;
                }else if (activeQuests[i].progress == Quest.QuestProgress.COMPLETED)
                {
                    questDescription.text = activeQuests[i].congratulation;
                    //questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + "/" + activeQuests[i].questObjectiveRequirement;

                }
            }
        }
    }
}
