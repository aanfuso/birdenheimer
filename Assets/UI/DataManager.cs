using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("Pidgeon Stats")]
    [SerializeField] private int bounces = 0;
    [SerializeField] private int ckals = 5;
    [SerializeField] private int hunger = 50;

    void OnEnable()
    {
        EventManager.StartListening(UIEvents.ACTION_ATE, OnAte);
        EventManager.StartListening(UIEvents.ACTION_BOUNCED, OnBounced);
        EventManager.StartListening(UIEvents.ACTION_HUNGER, OnHunger);
    }

    void OnAte(string eventName, string message)
    {
        ckals += int.Parse(message);
        EventManager.TriggerEvent(UIEvents.CKAL_UPDATE, ckals.ToString());
    }

    void OnBounced(string eventName, string message)
    {
        bounces++;
        EventManager.TriggerEvent(UIEvents.BOUNCES_UPDATE, bounces.ToString());
    }
    void OnHunger(string eventName, string message)
    {
        hunger += int.Parse(message);
        EventManager.TriggerEvent(UIEvents.HUNGER_UPDATE, hunger.ToString());
    }
}
