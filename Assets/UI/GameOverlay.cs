using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI bouncesStreak;
    public Slider ckalBar;

    private int _ckals = 0;
    private int _bounces = 0;

    void OnEnable()
    {
        EventManager.StartListening(UIEvents.CKAL_UPDATE, OnUpdateCkal);
        EventManager.StartListening(UIEvents.BOUNCES_UPDATE, OnUpdateBounces);
    }

    void OnDisable()
    {
        EventManager.StopListening(UIEvents.CKAL_UPDATE, OnUpdateCkal);
        EventManager.StopListening(UIEvents.BOUNCES_UPDATE, OnUpdateBounces);
    }

    private void OnUpdateCkal(string eventName, string message)
    {
        _ckals = int.Parse(message);
        ckalBar.value = _ckals;
    }

    private void OnUpdateBounces(string eventName, string message)
    {
        _bounces = int.Parse(message);
        bouncesStreak.text = string.Format("<color=\"red\">Bounce Streak:</color> {0}", _bounces);
    }
}
