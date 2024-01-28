using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDialogPanel : MonoBehaviour
{
    [Header("Dialog UI")]
    public List<QuestSO> dialogOptions;
    public Button nextButton;
    public TextMeshProUGUI text;
    public Image image;

    private int index = 0;

    [SerializeField] private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        nextButton.onClick.AddListener(Next);
    }

    public void Next()
    {
        if (index >= dialogOptions.Count - 1)
        {
            index = 0;
        } else
        {
            index++;
        }

        QuestSO dialog = dialogOptions[index];

        text.text = dialog.textBody;
        image.sprite = dialog.sprite;

        source.PlayOneShot(dialog.sound, 1F);
    }
}


