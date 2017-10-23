using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float jumpVelocity = 10f;
    [SerializeField]
    private float dashSpeed = 5f;

    private PlayerController controller;
    private PlayerState playerState;
    private Rigidbody2D rb;

    private float horizontalInput;
    private bool hasJumped;
    private bool hasDashed;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMovementInput();
        GetJumpInput();
    }
    private void FixedUpdate()
    {
        UpdateMovement();
        ResetDash();
        UpdateJump();
    }

    private void GetMovementInput()
    {
        horizontalInput = controller.GetHorizontal();
        if (controller.IsPressedOnce("Dash") && !hasDashed)
        {
            hasDashed = true;
        }
    }
    private void GetJumpInput()
    {
        if (controller.IsPressedOnce("Jump") && playerState.GetState() == PlayerStates.OnGround)
        {
            hasJumped = true;
        }
        else if (controller.IsPressedOnce("Jump") && playerState.GetState() == PlayerStates.InAir)
        {
            hasJumped = true;
        }
    }

    private void ResetDash()
    {
        if(playerState.GetState() == PlayerStates.OnGround)
        {
            hasDashed = false;
        }
    }

    private void UpdateMovement()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        if(hasDashed)
        {
            rb.velocity = new Vector2(horizontalInput * movementSpeed + dashSpeed * horizontalInput, rb.velocity.y);
        }
        //Doesn't use physics system
        //transform.Translate(0.1f * horizontalInput, 0, 0);
    }
    private void UpdateJump()
    {
        if (hasJumped && playerState.GetState() == PlayerStates.OnGround)
        {
            Jump();
            hasJumped = false;
            playerState.SetState(PlayerStates.InAir);
        }
        else if(hasJumped && playerState.GetState() == PlayerStates.InAir)
        {
            Jump();
            hasJumped = false;
            playerState.SetState(PlayerStates.DoubleAir);
        }
    }

    private void Jump()
    {
        //Gameplay is more realistic
        //rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        //Gameplay is more fun
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }
}
