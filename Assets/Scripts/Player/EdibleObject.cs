using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleObject : MonoBehaviour
{
    public NutritionFacts edible;
    Eating eating;

    Color dangerousColor;
    Color safeColor;

    private void Start()
    {
        eating = GameObject.Find("Beak").GetComponent<Eating>();

        dangerousColor = Color.red;
        dangerousColor.a = 0.1f;

        safeColor = Color.white;
    }

    void Update()
    {
        if(edible.mass > eating.mass)
        {
            ChangeColorInChildren(this.transform, dangerousColor);
        }
        else
        {
            ChangeColorInChildren(this.transform, safeColor);
        }
    }

    void ChangeColorInChildren(Transform parent, Color color)
    {
        // Change color for the current object's renderer
        Renderer renderer = parent.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }

        // Recursively search for children
        foreach (Transform child in parent)
        {
            ChangeColorInChildren(child, color);
        }
    }
}
