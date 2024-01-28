using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] BasicAnimations animations;



    [Header("Player's stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [Header("Internal")]
    public List<Vector3> destinations = new List<Vector3>();
    [SerializeField] GameObject testCube;
    bool rightMouseEnabled;
    float timeOfDisable;
    float timer;

    float speedMultiplier;

    //bool isGoing = false;

#if UNITY_STANDALONE
    void Start()
    {
        speedMultiplier = 1.0f;
        rightMouseEnabled = true;      
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && rightMouseEnabled)
        {
            Debug.Log("Press right click");
            SurfaceClick();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Eat();
        }

        if(destinations.Count > 0)
        {
            MoveAndRotateTowardsPoint(destinations[destinations.Count - 1]);
        }

        if((Time.time - timeOfDisable) > timer)
        {
            rightMouseEnabled = true;
        }
        else
        {
            rightMouseEnabled = false;
        }
    }

    public void SurfaceClick()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

     
        foreach (RaycastHit hit in hits)
        {
            
            if (hit.collider.CompareTag("Surface"))
            {
                Debug.Log("Mouse Cursor World Position: " + hit.point);
                testCube.transform.position = hit.point;
                ResetDestinations();
                destinations.Add(hit.point);
                break;
            }
        }
    }

    public void MoveAndRotateTowardsPoint(Vector3 destination)
    {
        Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
        targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0);

        Vector3 targetVelocity = destination - transform.position;
        targetVelocity = new Vector3(targetVelocity.x , 0f, targetVelocity.z).normalized * moveSpeed * speedMultiplier;

        if (Quaternion.Angle(playerRb.rotation, targetRotation) > 0.5f)
        {
            playerRb.MoveRotation(Quaternion.Slerp(playerRb.rotation, targetRotation, rotateSpeed));
        }

        if((transform.position - destination).magnitude > 0.5 * this.transform.localScale.x)
        {

           
            playerRb.velocity = targetVelocity;
             
            animations.SideWays();
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            animations.StandStraight();
        }

        if(Quaternion.Angle(playerRb.rotation, targetRotation) <= 0.5f && (transform.position - destination).magnitude < 0.5 * this.transform.localScale.x)
        {
            ResetDestinations();
        }
      
        
    }

    public void ChangeSpeedMultyplier(float value)
    {
        speedMultiplier = value;
    }

    public void DisableMouseForSeconds(float seconds, float timeSnap)
    {
        timeOfDisable = timeSnap;
        timer = seconds;
    }

    public void ResetDestinations()
    {
        destinations.Clear();
    }

    public void Eat()
    {
        StartCoroutine(animations.EatAnim());
        //animations.Eat();
        //animations.StopEating();
    }

# endif

}
