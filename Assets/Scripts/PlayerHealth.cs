using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;
    public GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            gameManager.gameOver();
        }
    }

    public void addHealth(int health)
    {
        if (currentHealth + health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else 
        {
            currentHealth += health;
        }

        healthBar.setHealth(currentHealth);
    }

    public void setMaxHealth(int amount)
    {
        if ((currentHealth + amount - maxHealth) > 0)
        {
            currentHealth += amount - maxHealth;
        }
        else
        {
            currentHealth = 1;
        }
        maxHealth = amount;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
    }
}
