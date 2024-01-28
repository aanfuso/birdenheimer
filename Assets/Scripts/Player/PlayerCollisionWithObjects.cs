using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCollisionWithObjects : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Eating eating;
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
            if (collision.gameObject.GetComponent<EdibleObject>() != null)
            {
                EdibleObject edible = collision.gameObject.GetComponent<EdibleObject>();

                if (eating.mass < edible.edible.mass)
                {
                    PlayerCollides(this.gameObject, collision.gameObject);
                    mouseMovement.DisableMouseForSeconds(1f, Time.time);
                }
                else
                {

                }
            }
        }   
    }

    public void PlayerCollides(GameObject player, GameObject enemyObject)
    {
        float forceMagnitude = Random.Range(minForce, maxForce);
        mouseMovement.ResetDestinations();
        rb.velocity = Vector3.zero;
        rb.AddForce((player.transform.position - enemyObject.transform.position).normalized * forceMagnitude, ForceMode.Impulse);
        EventManager.TriggerEvent(UIEvents.ACTION_BOUNCED);

    }
}
