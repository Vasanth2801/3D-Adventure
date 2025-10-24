using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Questgiver : MonoBehaviour
{
    public Quest quest;
    public UnityEvent onQuestGiven;
    public PlayerMovement player;
    public bool isInRange;
    public GameObject questWindow;
    public TextMeshProUGUI tittleText;
    public TextMeshProUGUI descriptionText;


    void Update()
    {
       if(isInRange && Input.GetKeyDown(KeyCode.Q))
        {
            onQuestGiven.Invoke();
        }
    }

    public void GiveQuest()
    {       
            questWindow.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            tittleText.text = quest.tittle;
            descriptionText.text = quest.description;
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}