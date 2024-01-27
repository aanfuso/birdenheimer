using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDialogPanel : UIPanel
{
    [Header("Dialog UI")]
    public List<TutorialSO> dialogOptions;
    public Button nextButton;
    public TextMeshProUGUI text;
    public Image image;
    public Image visualAid;

    private int index = 0;

    void Awake()
    {
        nextButton.onClick.AddListener(Next);
    }

    public void Next()
    {
        if (index >= dialogOptions.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        text.text = dialogOptions[index].textBody;
        image.sprite = dialogOptions[index].sprite;
        visualAid.sprite = dialogOptions[index].visualAid;
    }
}


