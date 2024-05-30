using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;
    public float heavyAttackCooldown = 2f;

    float nextAttackTime = 0f;
    public GameObject inventory;
    private HashSet<Enemy> hitEnemiesSet = new HashSet<Enemy>();

    void Update()
    {
        if (!PauseMenu.isPaused && !inventory.activeSelf)
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    HeavyAttack();
                    nextAttackTime = Time.time + heavyAttackCooldown;
                }
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        DealDamage(attackDamage, false);
    }

    void HeavyAttack()
    {
        animator.SetTrigger("HeavyAttack");
        DealDamage(attackDamage * 2, true);
    }

    void DealDamage(int damage, bool applyKnockback)
    {
        hitEnemiesSet.Clear(); // Clear the set at the start of each attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
            if (enemyScript != null && !hitEnemiesSet.Contains(enemyScript))
            {
                hitEnemiesSet.Add(enemyScript); // Add enemy to the set
                enemyScript.takeDamage(damage);
                if (applyKnockback)
                {
                    Rigidbody2D enemyRb = enemyCollider.GetComponent<Rigidbody2D>();
                    KnockbackFeedback knockbackFeedback = enemyCollider.GetComponent<KnockbackFeedback>();
                    if (enemyRb != null)
                    {
                        knockbackFeedback.rb2d = enemyRb;
                        knockbackFeedback.PlayFeedback(gameObject);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
