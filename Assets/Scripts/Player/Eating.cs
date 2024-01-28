using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public float mass;
    public float calories;

    [SerializeField] List<GrowthWave> waves;
    [SerializeField] CameraFollow cameraFollow;

    [SerializeField] GameObject playerObject;
    [SerializeField] MouseMovement movementScript;
    Vector3 initialSize;

    int waveIndex = 0;
    float hungerCost;

    void Start()
    {
        initialSize = playerObject.transform.localScale;
        SetNewSize(waves[waveIndex]);
    }

    void Update()
    {
        if(mass > waves[waveIndex].upMass)
        {
            waveIndex += 1;
            if(waveIndex<waves.Count-1)
            {
                SetNewSize(waves[waveIndex]);

            }
            else
            {
                print("You won the game!!!!!!!!!!");
            }
        }
        else if(mass < waves[waveIndex].downMass)
        {
            if(waveIndex == 0)
            {
                DeathOfHunger();
            }
            else
            {
                waveIndex -= 1;
                SetNewSize(waves[waveIndex]);
            }
        }

        mass -= hungerCost * Time.deltaTime;
    }

    public void TryEating(GameObject target)
    {
       if(target.GetComponent<EdibleObject>() != null)
        {
            print("Trying to eat the edible!");
            EdibleObject edible = target.GetComponent<EdibleObject>();

            if((mass * 0.8f) > edible.edible.mass)
            {
                EatObject(edible);
            }
        }
    }

    public void EatObject(EdibleObject edible)
    {
        mass += edible.edible.mass;
        calories += edible.edible.calories;

        Destroy(edible.gameObject);
    }

    public void SetNewSize(GrowthWave wave)
    {
        playerObject.transform.localScale = initialSize * wave.size; 
        mass = wave.currMass;
        cameraFollow.SwitchOffset(wave.currCamera);

        movementScript.ChangeSpeedMultyplier(wave.speed);

        hungerCost = wave.hungerPerSecond;
    }

    public void DeathOfHunger()
    {
        print("Dieeeed, DeathOfHunger noooooooooooooooooo!!!!!!!!!!!!!!!!");
    }
}

[CreateAssetMenu]
public class NutritionFacts: ScriptableObject
{
    public float mass;
    public float calories;
}

[CreateAssetMenu]
public class GrowthWave: ScriptableObject
{
    public float upMass;
    public float downMass;

    public float currMass;
    public CameraSetUp currCamera;

    public float size;
    public float speed;
    public float hungerPerSecond;
}
