using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject DialogueBox1;
    public GameObject DialogueBox2;
    private Dialogue dialogue;
    public GameObject music1;
    public GameObject music2;

    void Start()
    {
        dialogue = DialogueBox2.GetComponent<Dialogue>();
    }

    public void playGame()
    {
        music1.SetActive(false);
        music2.SetActive(true);
        DialogueBox1.SetActive(true);
        DialogueBox2.SetActive(true);
        dialogue.startDialogue();
        StartCoroutine(WaitForDialoguesToEnd());
    }

    private IEnumerator WaitForDialoguesToEnd()
    {
        while (!dialogue.dialogueCompleted)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}