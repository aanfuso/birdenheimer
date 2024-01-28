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

    private AudioSource source;

    // Animation variables
    private RectTransform window;
    private Vector3 originalPosition;
    private float animationDistance;

    void Awake()
    {
        this.source = GetComponent<AudioSource>();

        this.animationDistance = Screen.height * 2f;
        this.window = panelObject.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        this.originalPosition = this.window.anchoredPosition3D;
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
        this.window.anchoredPosition3D += new Vector3(0f, -this.animationDistance, 0f);
        this.panelObject.SetActive(true);
        PlaySound(openSound);

        LeanTween
            .moveY(this.window, this.window.anchoredPosition3D.y + this.animationDistance, 0.2f)
            .setEase(LeanTweenType.easeOutSine);
    }

    public void ClosePanel()
    {
        PlaySound(closeSound);

        LeanTween
            .moveY(this.window, this.originalPosition.y - this.animationDistance, 0.2f)
            .setEase(LeanTweenType.easeOutSine)
            .setDelay(0.2f)
            .setOnComplete(ResetPanel);
    }

    private void ResetPanel()
    {
        this.window.anchoredPosition3D = this.originalPosition;

        this.panelObject.SetActive(false);
    }
}