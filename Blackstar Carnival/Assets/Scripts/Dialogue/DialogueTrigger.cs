using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool inDialogue;
    private bool isColliding;

    void Update()
    {
        if (Input.GetKeyUp("e") && (inDialogue == false) && isColliding)
        {
            Debug.Log("Dialog started");
            inDialogue = true;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Colliding with Player");
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

}
