using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    float move;
    bool facingRight = true;

    PlayerController controller;
    PlayerState playerState;
    Rigidbody2D rb;
    Animator anim;
	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        anim.SetFloat("vSpeed", rb.velocity.y);
        UpdateGround();
        UpdateMovement();
	}

    private void UpdateGround()
    {
        if(playerState.GetState() == PlayerStates.OnGround)
        {
            anim.SetBool("Grounded", true);
        }
        else if(playerState.GetState() == PlayerStates.InAir)
        {
            anim.SetBool("Grounded", false);
        }
    }

    private void UpdateMovement()
    {
        move = controller.GetHorizontal();
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
