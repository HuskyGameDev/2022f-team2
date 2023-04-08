using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    
    private Vector2 moveDirection;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        ProcessInputs();
    }

    // Update is called once per frame
    void Update()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy))
        {
            ProcessInputs();

            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }
        
    }

    void FixedUpdate()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy))
        {
            // Physics Calculations
            Move();
        }
    }

    void ProcessInputs()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy))
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;
        }
    }

    void Move()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy))
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}
