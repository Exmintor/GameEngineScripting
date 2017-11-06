using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWay : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rb;

    private bool isOnOneWayPlatform = false;
    private bool isPhasing = false;
	// Use this for initialization
	void Start ()
    {
        controller = gameObject.GetComponent<PlayerController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(rb.IsSleeping())
        {
            rb.WakeUp();
        }
        if (controller.IsPressedOnce("OneWay") && isOnOneWayPlatform == true)
        {
            isPhasing = true;
        }
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isPhasing && collision.gameObject.layer ==LayerMask.NameToLayer("OneWay"))
        {
            collision.collider.isTrigger = true;
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("OneWay"))
        {
            isOnOneWayPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("OneWay"))
        {
            isOnOneWayPlatform = false;
            isPhasing = false;
            collision.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("OneWay"))
        {
            isOnOneWayPlatform = false;
            isPhasing = false;
            collision.collider.isTrigger = false;
        }
    }
}
