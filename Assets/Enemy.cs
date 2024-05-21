using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    
    private bool isDying = false;
    private AIPath aiPath; // Assuming you're using the Pathfinding library for AI movement
    private EnemyDamage enemyDamage; // Reference to the EnemyDamage component

    void Start()
    {
        currentHealth = maxHealth;
        aiPath = GetComponent<AIPath>();
        enemyDamage = GetComponent<EnemyDamage>();
    }

    public void takeDamage(int damage)
    {
        if (isDying)
            return;

        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDying = true;
        animator.SetBool("IsDead", true);

        if (aiPath != null)
        {
            aiPath.enabled = false;
        }
        if (enemyDamage != null)
        {
            enemyDamage.enabled = false;
        }
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float waitTime = animatorStateInfo.length;

        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
