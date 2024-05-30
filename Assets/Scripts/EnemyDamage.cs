using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public float maxAttackDistance = 12f;
    public float attackCooldown = 1.5f;
    private PlayerHealth player;
    private Animator animator;
    private bool isCollidingWithPlayer = false;
    private float nextAttackTime = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && IsWithinAttackRange(collision.gameObject.transform.position))
        {
            player = collision.gameObject.GetComponent<PlayerHealth>();
            isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            animator.SetBool("isAttacking", false);
        }
    }

    private void Update()
    {
        if (isCollidingWithPlayer && IsWithinAttackRange(player.transform.position))
        {
            if (Time.time >= nextAttackTime)
            {
                DealDamage();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        else
        {
            isCollidingWithPlayer = false;
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsWithinAttackRange(Vector2 targetPosition)
    {
        float distance = Vector2.Distance(transform.position, targetPosition);
        return distance <= maxAttackDistance;
    }

    private void DealDamage()
    {
        animator.SetTrigger("Attack");
        animator.SetBool("isAttacking", true);
        player.takeDamage(damage);
    }
}
