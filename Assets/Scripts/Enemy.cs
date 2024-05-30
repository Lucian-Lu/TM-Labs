using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Inventory.Model;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public Animator animator;
    
    private bool isDying = false;
    private AIPath aiPath;
    private EnemyDamage enemyDamage;
    private FloatingHealthBar healthBar;
    private GameObject floatingTextPrefab;

    public List<ItemSO> dropItems;
    public float dropChance = 0.5f;
    [SerializeField] AIDestinationSetter aIDestinationSetter;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        aIDestinationSetter.target = player.transform;
        currentHealth = maxHealth;
        aiPath = GetComponent<AIPath>();
        enemyDamage = GetComponent<EnemyDamage>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        floatingTextPrefab = Resources.Load<GameObject>("DamagePopupParent");
    }

    public void takeDamage(int damage)
    {
        if (isDying)
            return;
        ShowDamage(damage.ToString());
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
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
        DropItems();
    }

    public void DropItems()
    {
        foreach (ItemSO item in dropItems)
        {
            if (Random.value <= dropChance)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }


    private IEnumerator DestroyAfterAnimation()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float waitTime = animatorStateInfo.length;

        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
