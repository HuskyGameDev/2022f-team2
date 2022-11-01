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
    }

    public void startDialogue (Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string line in dialogue.lines)
        {
            sentences.Enqueue(line);
        }
    }

    public void nextLine()
    {
        if(sentences.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
    }

    public void endDialogue()
    {

    }

  
}
