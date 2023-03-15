using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool inDialogue;
    private bool isColliding;

    void Start()
    {
        inDialogue = false;
        isColliding = false;
    }

    void Update()
    {
        // starts the dialogue
        if (Input.GetKeyDown(KeyCode.E) && !inDialogue && isColliding)
        {
            Debug.Log("Dialog started");
            inDialogue = true;
            TriggerDialogue();
        }
        // the player chooses to play the game
        else if (Input.GetKeyDown(KeyCode.E) && inDialogue && isColliding)
        {
            inDialogue = false;
            isColliding = false;

            switch(this.gameObject.tag)
            {
                case "CC_Tent":
                    SceneManager.LoadScene("Can Crashers");
                    break;
                case "RR_Tent":
                    SceneManager.LoadScene("Rowdy Racers");
                    break;
                case "HH_Tent":
                    SceneManager.LoadScene("Hammer Hitter");
                    break;
                case "DD_Tent":
                    SceneManager.LoadScene("Drum Duelist");
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyUp("space") && inDialogue && isColliding)
        {
            Debug.Log("space pressed");
            inDialogue = false;
            FindObjectOfType<DialogueManager>().endDialogue();
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
