using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestObject : MonoBehaviour
{
    private bool inTrigger = false;
    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();
    public GameObject questMarker;

    public GameObject npc;
    public GameObject questAvailableSprite;
    public GameObject questReceivableSprite;
    private GameObject questionm;
    private GameObject ruf;

    // Start is called before the first frame update
    void Start()
    {
        questionm = Instantiate(questAvailableSprite, new Vector3(npc.transform.position.x, npc.transform.position.y + 3, npc.transform.position.z), Quaternion.identity);
        ruf = Instantiate(questReceivableSprite, new Vector3(npc.transform.position.x, npc.transform.position.y + 3, npc.transform.position.z), Quaternion.identity);
        questionm.SetActive(false);
        ruf.SetActive(false);
        SetQuestMarker();

    }
    public void SetQuestMarker()
    {
        if (QuestManager.questManager.CheckCompletedQuest(this))
        {
            //questMarker.SetActive(true);
            //questMarker = questReceivableSprite;
            questionm.SetActive(false);
            ruf.SetActive(true);
            
        }
        else if(QuestManager.questManager.CheckAvailableQuest(this))
        {
            //questMarker.SetActive(true);
            //questMarker = questAvailableSprite;
            ruf.SetActive(false);
            questionm.SetActive(true);

        }
        else if (QuestManager.questManager.CheckAcceptedQuest(this))
        {
            //questMarker.SetActive(true);
            //questMarker = questReceivableSprite;
            questionm.SetActive(false);
            ruf.SetActive(true);

        }
        else
        {
            questMarker.SetActive(false);
            questionm.SetActive(false);
            ruf.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(inTrigger && Input.GetKeyDown("space"))
        {
            //questmanager
            //QuestManager.questManager.QuestRequest(this);
            if (!QuestUIManager.uiManager.questPanelActive)
            {
                QuestUIManager.uiManager.CheckQuests(this);
            }
        }
        if (inTrigger && Input.GetKeyDown(KeyCode.B))
        {
            QuestManager.questManager.AddQuestItem("Ziel", 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false; ;
        }
    }
}
