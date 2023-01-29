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
        if (Input.GetKeyDown(KeyCode.E) && (inDialogue == false) && isColliding)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Colliding with Player");
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
    }

}
