using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject questPanel;
    public GameObject gameOverlay;

    [Header("Game Status")]
    [SerializeField] private bool isPause = true;

    void Start()
    {
        Time.timeScale = 0;
    }

    void OnEnable()
    {
        EventManager.StartListening(UIEvents.PAUSE, OnPause);
        EventManager.StartListening(UIEvents.CONTINUE, OnContinue);

        EventManager.StartListening(UIEvents.HELP_SHOW, OnHelp);
        EventManager.StartListening(UIEvents.QUEST_SHOW, OnQuest);
        EventManager.StartListening(UIEvents.SETTINGS_SHOW, OnSettings);
    }

    void OnPause(string eventName, string message)
    {
        isPause = !isPause;

        Time.timeScale = isPause ? 1 : 0;
    }

    void OnContinue(string eventName, string message)
    {
        this.helpPanel.SetActive(false);
        this.gameOverlay.SetActive(true);
    }

    void OnHelp(string eventName, string message)
    {
        this.questPanel.SetActive(false);
        this.helpPanel.SetActive(true);
    }

    void OnQuest(string eventName, string message)
    {
        this.introPanel.SetActive(false);
        this.questPanel.SetActive(true);
    }

    void OnSettings(string eventName, string message)
    {
        this.settingsPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventManager.TriggerEvent(UIEvents.PAUSE);
        }
    }
}
