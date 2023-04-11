using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prizeTent : MonoBehaviour
{
    private bool isColliding;

    void Start()
    {
        isColliding = false;
    }

    void Update()
    {
        if(isColliding && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Prize Tent");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Colliding with player");
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
    }
}
