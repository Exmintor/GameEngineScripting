using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float dashSpeed = 10f;
    [SerializeField]
    private float maxSpeed = 20f;

    private PlayerController controller;
    private PlayerState playerState;
    private Rigidbody2D rb;

    private bool hasDashed;
    private bool canDash;
	// Use this for initialization
	private void Start ()
    {
        controller = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        CheckForDashInput();
	}

    private void FixedUpdate()
    {
        UpdateDash();
        ResetDash();
    }

    private void CheckForDashInput()
    {
        if(controller.IsPressedOnce("Dash") && canDash)
        {
            hasDashed = true;
            canDash = false;
        }
    }

    private void UpdateDash()
    {
        if(hasDashed)
        {
            hasDashed = false;
            Dash();
        }
    }

    private void Dash()
    {
        rb.velocity = new Vector2(rb.velocity.x + dashSpeed, rb.velocity.y);
    }

    private void ResetDash()
    {
        if(playerState.GetState() == PlayerStates.OnGround)
        {
            canDash = true;
        }
    }
}
