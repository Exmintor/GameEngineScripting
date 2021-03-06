﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float jumpVelocity = 10f;

    private PlayerController controller;
    private PlayerState playerState;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
	private AudioSource audioSource;

    private float horizontalInput;
    private bool hasJumped;

    private Vector3 startPosition;
    private Checkpoint currentCheckpoint;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
		audioSource = GetComponent<AudioSource>();
        startPosition = this.transform.position;

        playerState.PlayerChangedStates += HandleStateChange;
    }

    private void Update()
    {
        GetMovementInput();
        GetJumpInput();
    }
    private void FixedUpdate()
    {
        UpdateMovement();
        UpdateJump();
    }

    private void GetMovementInput()
    {
        horizontalInput = controller.GetHorizontal();
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

    private void UpdateMovement()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        //rb.AddForce(new Vector2(horizontalInput * movementSpeed, 0), ForceMode2D.Impulse);
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
		audioSource.Play();
        //Gameplay is more realistic
        //rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        //Gameplay is more fun
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private void HandleStateChange(PlayerStates previous, PlayerStates newState)
    {
        if(previous == PlayerStates.OnGround && newState == PlayerStates.InAir)
        {
            boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y + 0.6f);
            Vector3 position = playerState.groundDetectPoint.transform.position;
            playerState.groundDetectPoint.transform.position = new Vector3(position.x, position.y + 0.4f);
        }
        else if((previous == PlayerStates.InAir || previous == PlayerStates.DoubleAir) && newState == PlayerStates.OnGround)
        {
            boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y - 0.6f);
            Vector3 position = playerState.groundDetectPoint.transform.position;
            playerState.groundDetectPoint.transform.position = new Vector3(position.x, position.y - 0.4f);
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return startPosition;
    }
    public void ChangeSpawnPoint(Checkpoint newCheckpoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.DeactivateCheckpoint();
        }
        currentCheckpoint = newCheckpoint;
        startPosition = newCheckpoint.GetSpawnPoint();
    }
}
