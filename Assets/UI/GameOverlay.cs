using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI bouncesStreak;
    public Slider ckalBar;
    public Slider hungerBar;

    private int _ckals = 0;
    private float _hunger = 0;
    private int _bounces = 0;

    void OnEnable()
    {
        EventManager.StartListening(UIEvents.CKAL_UPDATE, OnUpdateCkal);
        EventManager.StartListening(UIEvents.BOUNCES_UPDATE, OnUpdateBounces);
        EventManager.StartListening(UIEvents.HUNGER_UPDATE, OnUpdateHunger);
        EventManager.StartListening(UIEvents.HUNGER_RESET, OnResetHunger);
        EventManager.StartListening(UIEvents.ACTION_HUNGER_SET, SetHunger);

    }

    void OnDisable()
    {
        EventManager.StopListening(UIEvents.CKAL_UPDATE, OnUpdateCkal);
        EventManager.StopListening(UIEvents.BOUNCES_UPDATE, OnUpdateBounces);
        EventManager.StopListening(UIEvents.HUNGER_UPDATE, OnUpdateHunger);
        EventManager.StopListening(UIEvents.HUNGER_RESET, OnResetHunger);
        EventManager.StopListening(UIEvents.ACTION_HUNGER_SET, SetHunger);
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

    private void OnUpdateHunger(string eventName, string message)
    {
        _hunger = float.Parse(message);
        hungerBar.value = _hunger;
    }

    private void OnResetHunger(string eventName, string message)
    {
        string[] integerStrings = message.Split(',');
        hungerBar.minValue = float.Parse(integerStrings[0]);
        hungerBar.maxValue = float.Parse(integerStrings[1]);
    }

    private void SetHunger(string eventName, string message)
    {
        _hunger = float.Parse(message);
        hungerBar.value = _hunger;
    }
}
