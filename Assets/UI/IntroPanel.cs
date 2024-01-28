using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : UIPanel
{
    public Button continueButton;

    void Start()
    {
        this.continueButton.onClick.RemoveAllListeners();
        this.continueButton.onClick.AddListener(ContinueGame);
    }

    void ContinueGame()
    {
        EventManager.TriggerEvent(UIEvents.QUEST_SHOW);
    }
}
