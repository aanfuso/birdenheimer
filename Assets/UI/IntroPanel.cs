using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
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
        EventManager.TriggerEvent(UIEvents.CONTINUE);
        EventManager.TriggerEvent(UIEvents.PAUSE);
    }
}
