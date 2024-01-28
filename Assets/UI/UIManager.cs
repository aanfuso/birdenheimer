using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverlay;
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject questPanel;

    [Header("Game Status")]
    [SerializeField] private bool isPause = false;

    void OnEnable()
    {
        EventManager.StartListening(UIEvents.HELP_SHOW, OnHelp);
        EventManager.StartListening(UIEvents.QUEST_SHOW, OnQuest);
        EventManager.StartListening(UIEvents.SETTINGS_SHOW, OnSettings);
    }

    void OnDisable()
    {
        EventManager.StopListening(UIEvents.HELP_SHOW, OnHelp);
        EventManager.StopListening(UIEvents.QUEST_SHOW, OnQuest);
        EventManager.StopListening(UIEvents.SETTINGS_SHOW, OnSettings);
    }

    void OnHelp(string eventName, string message)
    {
        this.helpPanel.SetActive(true);
    }

    void OnQuest(string eventName, string message)
    {
        this.questPanel.SetActive(true);
    }

    void OnSettings(string eventName, string message)
    {
        this.settingsPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventManager.TriggerEvent(UIEvents.ACTION_ATE);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            EventManager.TriggerEvent(UIEvents.ACTION_BOUNCED);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            EventManager.TriggerEvent(UIEvents.HELP_SHOW);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.TriggerEvent(UIEvents.QUEST_SHOW);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            EventManager.TriggerEvent(UIEvents.SETTINGS_SHOW);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;

            Time.timeScale = isPause ? 1 : 0;
        }
    }
}
