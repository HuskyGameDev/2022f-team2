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
    public GameObject inventory;

    public AudioSource footsteps;
    public bool IsMoving;


    // Start is called before the first frame update
    void Start()
    {
        ProcessInputs();
    }

    // Update is called once per frame
    void Update()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy) && !(inventory.activeInHierarchy))
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
        if(!(pauseMenu.activeInHierarchy) && !(inventory.activeInHierarchy))
        {
            // Physics Calculations
            Move();
        }
    }

    void ProcessInputs()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy)&& !(inventory.activeInHierarchy))
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if(moveX != 0 || moveY != 0) { IsMoving = true; }
            else { IsMoving = false; }

            if (IsMoving && !footsteps.isPlaying) { footsteps.Play(); }
            if (!IsMoving) { footsteps.Stop(); }

            moveDirection = new Vector2(moveX, moveY).normalized;
        }
    }

    void Move()
    {
        // only move if the pause menu is not up lol
        if(!(pauseMenu.activeInHierarchy)&& !(inventory.activeInHierarchy))
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}
