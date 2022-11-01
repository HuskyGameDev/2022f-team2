using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool inDialogue;

    void Update()
    {
        if (Input.GetKeyUp("e") && (inDialogue == false))
        {
            inDialogue = true;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

}
