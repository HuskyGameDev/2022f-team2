using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;

    void Start()
    {
        sentences = new Queue<string>();
        characterNameText.enabled = false;
        dialogueText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyUp("space") && (DialogueTrigger.inDialogue == true))
        {
            nextLine();
        }
    }

    public void startDialogue (Dialogue dialogue)
    {
        Debug.Log("conversation started");

        characterNameText.enabled = true;
        dialogueText.enabled = true;

        sentences.Clear();
        characterNameText.text = dialogue.characterName;

        foreach(string line in dialogue.lines)
        {
            sentences.Enqueue(line);
        }
        nextLine();
    }

    public void nextLine()
    {
        Debug.Log("next line");

        if(sentences.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void endDialogue()
    {
        Debug.Log("conversation ended");
        DialogueTrigger.inDialogue = false;
        characterNameText.enabled = false;
        dialogueText.enabled = false;
    }
}
