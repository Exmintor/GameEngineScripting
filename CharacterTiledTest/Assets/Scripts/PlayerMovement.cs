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

    PlayerController controller;
    PlayerState playerState;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateJump();
    }

    private void UpdateMovement()
    {
        float horizontalInput = controller.GetHorizontal();
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        //Doesn't use physics system
        //transform.Translate(0.1f * horizontalInput, 0, 0);
    }
    private void UpdateJump()
    {
        if (controller.IsPressedOnce("Jump") && playerState.GetState() == PlayerStates.OnGround)
        {
            Jump();
            playerState.SetState(PlayerStates.InAir);
        }
        else if(controller.IsPressedOnce("Jump") && playerState.GetState() == PlayerStates.InAir)
        {
            Jump();
            playerState.SetState(PlayerStates.DoubleAir);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }
}
