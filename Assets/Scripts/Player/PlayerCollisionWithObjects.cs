using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithObjects : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] MouseMovement mouseMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object" || collision.gameObject.tag == "Vehicle")
        {
            PlayerCollides(this.gameObject, collision.gameObject);
            mouseMovement.DisableMouseForSeconds(1f, Time.time);
        }   
    }

    public void PlayerCollides(GameObject player, GameObject enemyObject)
    {
        float forceMagnitude = Random.Range(minForce, maxForce);
        mouseMovement.ResetDestinations();
        rb.velocity = Vector3.zero;
        rb.AddForce((player.transform.position - enemyObject.transform.position).normalized * forceMagnitude, ForceMode.Impulse);

    } 
}
