using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public static bool isGameOver;

    public void gameOver()
    {
        isGameOver = true;
        gameOverScript.setup();
    }
}
