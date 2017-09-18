using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpVelocity;

    PlayerController controller;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        movementSpeed = 10f;
        jumpVelocity = 10f;

        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        float horizontalInput = controller.GetHorizontal();
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        //Doesn't use physics system
        //transform.Translate(0.1f * horizontalInput, 0, 0);

        if(controller.IsPressedOnce("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }
}
