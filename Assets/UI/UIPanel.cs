using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [Header("Base")]
    public GameObject panelObject;

    [Header("Sounds")]
    public AudioClip openSound;
    public AudioClip closeSound;

    [SerializeField]private AudioSource source;


    void Awake()
    {
        Debug.Log("Awake UIPanel");
        this.source = GetComponent<AudioSource>();
    }

    public virtual void SetUI() { }

    public void PanelSetup()
    {
        OpenPanel();

        SetUI();
    }

    public void PlaySound(AudioClip sound)
    {
        this.source.PlayOneShot(sound, 1F);
    }

    private void OpenPanel()
    {
        this.panelObject.SetActive(true);
        PlaySound(openSound);

    }

    public void ClosePanel()
    {
        PlaySound(closeSound);
    }

    private void ResetPanel()
    {
        this.panelObject.SetActive(false);
    }
}