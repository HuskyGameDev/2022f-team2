using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tent_Interact : MonoBehaviour
{
    bool cc = false;
    bool rr = false;

    void Update()
    {
        if(cc && Input.GetKeyDown(KeyCode.E))
        {
            cc = false;
            SceneManager.LoadScene("Can Crashers");
        }
        if(rr && Input.GetKeyDown(KeyCode.E))
        {
            rr = false;
            SceneManager.LoadScene("Rowdy Racers");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // when the player "collects" a gem, the score increases
        if(other.gameObject.tag.Equals("CC_Tent"))
        {
            cc = true;
        }

        if(other.gameObject.tag.Equals("RR_Tent"))
        {
            rr = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        cc = false;
        rr = false;
    }

    void OnGUI()
    {
        if(cc)GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"Play Can Crashers? [E]");
        if(rr)GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"Play Rowdy Racers? [E]");
    }
}
