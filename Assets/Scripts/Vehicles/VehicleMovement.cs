using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        startPosition = transform.position;
        startRotation = transform.rotation;

        rb.velocity = (transform.forward * 20f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if((transform.position - startPosition).magnitude > 300f)
        {
            Respawn();
        }
        else if(rb.velocity.magnitude < 4f)
        {
            StartCoroutine(RespawnInSeconds(5));
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation; 
        rb.velocity = (transform.forward * 20f);
    }

    public IEnumerator RespawnInSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Respawn();
    }
}
