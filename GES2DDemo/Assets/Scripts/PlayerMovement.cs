using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { OnGround, InAir }
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform groundDetectPoint;
    [SerializeField]
    private float groundDetectRadius = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float jumpVelocity = 10f;
    private PlayerStates currentState;

    PlayerController controller;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        //UpdateGroundState();
        UpdateMovement();
        UpdateJump();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(currentState == PlayerStates.InAir)
    //    {
    //        currentState = PlayerStates.OnGround;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateGroundState();
    }
    private void UpdateGroundState()
    {
        Vector2 colliderPoint = new Vector2(groundDetectPoint.position.x, groundDetectPoint.position.y);
        Collider2D[] objects = Physics2D.OverlapCircleAll(colliderPoint, groundDetectRadius ,groundLayer);
        if(objects.Length > 0 && currentState == PlayerStates.InAir)
        {
            currentState = PlayerStates.OnGround;
        }
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
        if (controller.IsPressedOnce("Jump") && currentState == PlayerStates.OnGround)
        {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                currentState = PlayerStates.InAir;
        }
    }
}
