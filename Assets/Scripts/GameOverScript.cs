using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    private GameObject player;
    private PlayerHealth playerHealth;
    public HealthBar healthBar;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    public void setup()
    {
        gameObject.SetActive(true);
    }

    public void restartButton()
    {
        gameObject.SetActive(false);
        PauseMenu.isPaused = false;
        GameManager.isGameOver = false;
        healthBar.setHealth(playerHealth.maxHealth);
        playerHealth.currentHealth = playerHealth.maxHealth;
        Time.timeScale = 1f;
        player.transform.position = new Vector3(0, 0, player.transform.position.z); 
    }

    public void exitButton()
    {
        PauseMenu.isPaused = false;
        GameManager.isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

