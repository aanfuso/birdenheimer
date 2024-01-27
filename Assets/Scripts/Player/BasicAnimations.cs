using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;

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
        yield return new WaitForSeconds(1);
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
