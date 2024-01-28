using UnityEngine;

[CreateAssetMenu(fileName = "TutorialSO", menuName = "ScriptableObjects/TutorialSO")]
public class TutorialSO: ScriptableObject
{
    public string textBody;
    public Sprite sprite;
    public Sprite visualAid;
    public AudioClip sound;
}
