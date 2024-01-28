using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Beak : MonoBehaviour
{
    [SerializeField] Eating eating;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        eating.TryEating(other.gameObject);
    }


}
