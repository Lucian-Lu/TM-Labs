using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool isLineComplete;

    public bool dialogueCompleted;
    
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueCompleted = false;
        index = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isLineComplete)
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                isLineComplete = true;
                StartCoroutine(WaitAndProceed());
            }
            else
            {
                nextLine();
            }
        }
    }

    public void startDialogue()
    {
        textComponent.text = string.Empty;
        dialogueCompleted = false;
        index = 0;
        StartCoroutine(typeLine());
    }

    IEnumerator typeLine()
    {
        isLineComplete = false;
        textComponent.text = string.Empty;
        
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isLineComplete = true;
        StartCoroutine(WaitAndProceed());
    }

    IEnumerator WaitAndProceed()
    {
        yield return new WaitForSeconds(0.5f);
        if (isLineComplete)
        {
            nextLine();
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(typeLine());
        }
        else
        {
            dialogueCompleted = true;
            gameObject.SetActive(false);    
        }
    }
}
