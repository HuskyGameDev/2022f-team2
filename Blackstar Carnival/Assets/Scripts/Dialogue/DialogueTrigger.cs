using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool inDialogue;
    private bool isColliding;
    public GameObject exclamation;
    public GameObject prompt;

    void Start()
    {
        exclamation = GameObject.Find("notification");
        prompt = GameObject.Find("prompt");
        exclamation.SetActive(true);
        prompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (inDialogue == false) && isColliding)
        {
            exclamation.SetActive(false);
            prompt.SetActive(false);
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
            exclamation.SetActive(false);
            prompt.SetActive(true);
            Debug.Log("Colliding with Player");
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
        exclamation.SetActive(false);
        prompt.SetActive(false);
    }

}
