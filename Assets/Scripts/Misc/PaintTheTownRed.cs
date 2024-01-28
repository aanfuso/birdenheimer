using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTheTownRed : MonoBehaviour
{
    void Start()
    {
        // Recursive function to change color in children
       
    }
    void Update()
    {
        ChangeColorInChildren(transform);
    }

    void ChangeColorInChildren(Transform parent)
    {
        // Change color for the current object's renderer
        Renderer renderer = parent.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red;
        }

        // Recursively search for children
        foreach (Transform child in parent)
        {
            ChangeColorInChildren(child);
        }
    }
}
