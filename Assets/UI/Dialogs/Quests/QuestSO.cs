using UnityEngine;

[CreateAssetMenu(fileName = "QuestScriptableObject", menuName = "ScriptableObjects/QuestScriptableObject")]
public class QuestSO : ScriptableObject
{
    public string textBody;
    public Sprite sprite;
    public AudioClip sound;
}
