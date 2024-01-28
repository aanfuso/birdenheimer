using UnityEngine;

[CreateAssetMenu]
public class GrowthWave : ScriptableObject
{
    public float upMass;
    public float downMass;

    public float currMass;
    public CameraSetUp currCamera;

    public float size;
    public float speed;
    public float hungerPerSecond;
}
