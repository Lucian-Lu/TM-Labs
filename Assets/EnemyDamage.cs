using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth player;
    private Coroutine damageCoroutine;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerHealth>();
            damageCoroutine = StartCoroutine(DealDamage());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
            animator.SetBool("isAttacking", false);
        }
    }

    private IEnumerator DealDamage()
    {
        while (true)
        {
            animator.SetTrigger("Attack");
            animator.SetBool("isAttacking", true);
            player.takeDamage(damage);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
