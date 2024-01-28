using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Collider beakCollider;

    private void Start()
    {
        beakCollider.enabled = false;
    }

    public void SideWays()
    {
        animator.SetBool("Sideways", true);
    }

    public void StandStraight()
    {
        animator.SetBool("Sideways", false);
    }

    public IEnumerator EatAnim()
    {
        animator.SetBool("Eat", true);
        yield return new WaitForSeconds(0.3f);
        beakCollider.enabled=true;
        yield return new WaitForSeconds(0.3f);
        beakCollider.enabled = false;
        animator.SetBool("Eat", false);
    }

    public void Eat()
    {
        animator.SetBool("Eat", true) ;
    }

    public void StopEating()
    {
        animator.SetBool("Eat", false);
    }
}
