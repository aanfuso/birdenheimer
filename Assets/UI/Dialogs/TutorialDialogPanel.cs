using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDialogPanel : MonoBehaviour
{
    [Header("Dialog UI")]
    public List<TutorialSO> dialogOptions;
    public Button nextButtonA;
    public Button nextButtonB;
    public TextMeshProUGUI text;
    public Image image;
    public Image visualAid;

    private int index = 0;

    [SerializeField] private AudioSource source;

    void Awake()
    {
        nextButtonA.onClick.AddListener(Next);
        nextButtonB.onClick.AddListener(Next);
        source = GetComponent<AudioSource>();
    }

    public void Next()
    {
        if (index >= dialogOptions.Count - 1)
        {
            index = 0;
            EventManager.TriggerEvent(UIEvents.CONTINUE);
            EventManager.TriggerEvent(UIEvents.PAUSE);
        }
        else
        {
            index++;
        }

        TutorialSO dialog = dialogOptions[index];

        text.text = dialog.textBody;
        image.sprite = dialog.sprite;
        visualAid.sprite = dialog.visualAid;

        source.PlayOneShot(dialog.sound, 1F);
    }
}


