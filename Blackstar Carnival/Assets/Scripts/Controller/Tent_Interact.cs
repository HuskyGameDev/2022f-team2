using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tent_Interact : MonoBehaviour
{
    // can crashers
    bool cc = false;
    // rowdy racers
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

    // https://www.youtube.com/watch?v=MfKyUkZb1V4
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when the player "collects" a gem, the score increases
        if(collision.gameObject.tag.Equals("CC_Tent"))
        {
            cc = true;
        }

        if(collision.gameObject.tag.Equals("RR_Tent"))
        {
            rr = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
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
