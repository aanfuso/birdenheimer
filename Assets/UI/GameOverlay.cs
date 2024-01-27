using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [Header("Pidgeon Stats")]
    public int bounces = 0;
    public int ckals = 5;

    [Header("UI")]
    public TextMeshProUGUI bouncesStreak;
    public Slider ckalBar;

    private void Update()
    {
        // Triggers an update of the pidgeon calories bar.
        if (Input.GetKeyDown(KeyCode.C))
        {
            ckals += 5;
            ckalBar.value = ckals;
            //EventManager.TriggerEvent(UIEvents.GET_CHARACTER);
        }

        // Triggers an update of the bounce streak counter.
        if (Input.GetKeyDown(KeyCode.B))
        {
            string text = string.Format("<color=\"red\">Bounce Streak:</color> {0}", bounces++);
            bouncesStreak.text = text;
            //EventManager.TriggerEvent(UIEvents.GET_CHARACTER);
        }
    }
}
